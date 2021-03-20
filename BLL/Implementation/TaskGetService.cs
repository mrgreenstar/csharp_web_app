using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain.Contracts;

namespace BLL.Implementation
{
    public class TaskGetService : ITaskGetService
    {
        private ITaskDataAccess TaskDataAccess { get; }
        
        public TaskGetService(ITaskDataAccess taskDataAccess)
        {
            TaskDataAccess = taskDataAccess;
        }

        public Task<IEnumerable<Domain.Task>> GetAsync()
        {
            return TaskDataAccess.GetAsync();
        }

        public Task<Domain.Task> GetAsync(ITaskIdentity task)
        {
            return TaskDataAccess.GetAsync(task);
        }
    }
}