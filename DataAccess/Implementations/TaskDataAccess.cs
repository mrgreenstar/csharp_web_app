using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Context;
using DataAccess.Contracts;
using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Task;

namespace DataAccess.Implementations
{
    public class TaskDataAccess : ITaskDataAccess
    {
        private TaskDirectoryContext Context { get; }
        private IMapper Mapper { get; }

        public TaskDataAccess(TaskDirectoryContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<Task> InsertAsync(TaskUpdateModel task)
        {
            var result = await Context.AddAsync(Mapper.Map<Task>(task));
            await Context.SaveChangesAsync();

            return Mapper.Map<Task>(result.Entity);
        }

        public async Task<IEnumerable<Task>> GetAsync()
        {
            return Mapper.Map<IEnumerable<Task>>(
                await Context.Tasks.Include(x => x.Assignee).ToListAsync());
        }

        public async Task<Task> GetAsync(ITaskIdentity taskId)
        {
            var result = await Get(taskId);

            return Mapper.Map<Task>(result);
        }
        
        private async Task<Task> Get(ITaskIdentity task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            
            return await this.Context.Tasks.Include(x => x.AssigneeId)
                .FirstOrDefaultAsync(x => x.Id == task.Id);
        }
        
        public async Task<Task> UpdateAsync(TaskUpdateModel task)
        {
            var existing = await Get(task);

            var result = Mapper.Map(task, existing);

            Context.Update(result);

            await Context.SaveChangesAsync();

            return Mapper.Map<Task>(result);
        }
    }
}