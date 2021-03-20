using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface ITaskGetService
    {
        Task<IEnumerable<Domain.Task>> GetAsync();
        Task<Domain.Task> GetAsync(ITaskIdentity task);
    }
}