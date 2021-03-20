using System.Threading.Tasks;
using Domain.Models;

namespace BLL.Contracts
{
    public interface ITaskUpdateService
    {
        Task<Domain.Task> UpdateAsync(TaskUpdateModel task);
    }
}