using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Context;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class AssigneeDataAccess : IAssigneeDataAccess
    {
        private TaskDirectoryContext Context { get; }
        private IMapper Mapper { get; }
        
        public AssigneeDataAccess(TaskDirectoryContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public async Task<Assignee> GetByAsync(IAssigneeContainer assigneeContainer)
        {
            return assigneeContainer.AssigneeId.HasValue
                ? Mapper.Map<Assignee>(
                    await Context.Assignees.FirstOrDefaultAsync(x => x.Id == assigneeContainer.AssigneeId))
                : null;
        }
    }
}