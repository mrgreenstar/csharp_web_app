using System.Threading.Tasks;
using Domain.Models;

namespace BLL.Contracts
{
    public interface ITaskCreateService
    {
        Task<Domain.Task> CreateAsync(TaskUpdateModel taskUpdateModel);
    }
}