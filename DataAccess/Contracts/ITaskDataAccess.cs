using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models;

namespace DataAccess.Contracts
{
    public interface ITaskDataAccess
    {
        Task<Domain.Task> InsertAsync(TaskUpdateModel task);
        Task<IEnumerable<Domain.Task>> GetAsync();
        Task<Domain.Task> GetAsync(ITaskIdentity employeeId);
        Task<Domain.Task> UpdateAsync(TaskUpdateModel employee);
    }
}