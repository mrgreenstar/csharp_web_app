using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace DataAccess.Contracts
{
    public interface IAssigneeDataAccess
    {
        Task<Assignee> GetByAsync(IAssigneeContainer assigneeContainer);
    }
}