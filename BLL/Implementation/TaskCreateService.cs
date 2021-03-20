using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain.Models;

namespace BLL.Implementation
{
    public class TaskCreateService : ITaskCreateService
    {
        private ITaskDataAccess TaskDataAccess { get; }
        private IAssigneeGetService AssigneeGetService { get; }

        public TaskCreateService(ITaskDataAccess taskDataAccess, IAssigneeGetService assigneeGetService)
        {
            TaskDataAccess = taskDataAccess;
            AssigneeGetService = assigneeGetService;
        }
        
        public async Task<Domain.Task> CreateAsync(TaskUpdateModel taskUpdateModel)
        {
            await AssigneeGetService.ValidateAsync(taskUpdateModel);
            return await TaskDataAccess.InsertAsync(taskUpdateModel);
        }
    }
}