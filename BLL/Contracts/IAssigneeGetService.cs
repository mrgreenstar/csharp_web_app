using System.Threading.Tasks;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface IAssigneeGetService
    {
        Task ValidateAsync(IAssigneeContainer assigneeContainer);
    }
}