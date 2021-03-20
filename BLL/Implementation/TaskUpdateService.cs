using BLL.Contracts;
using System.Threading.Tasks;
using DataAccess.Contracts;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class TaskUpdateService : ITaskUpdateService
    {
        private ITaskDataAccess TaskDataAccess { get; }
        private IAssigneeGetService AssigneeGetService { get; }

        public TaskUpdateService(ITaskDataAccess taskDataAccess, IAssigneeGetService assigneeGetService)
        {
            TaskDataAccess = taskDataAccess;
            AssigneeGetService = assigneeGetService;
        }

        public async Task<Domain.Task> UpdateAsync(TaskUpdateModel task)
        {
            await AssigneeGetService.ValidateAsync(task);
            return await TaskDataAccess.UpdateAsync(task);
        }
    }
}