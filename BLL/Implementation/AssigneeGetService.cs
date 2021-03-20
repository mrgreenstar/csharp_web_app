using System;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain.Contracts;

namespace BLL.Implementation
{
    public class AssigneeGetService : IAssigneeGetService
    {
        private IAssigneeDataAccess AssigneeDataAccess { get; }
        
        public AssigneeGetService(IAssigneeDataAccess assigneeDataAccess)
        {
            this.AssigneeDataAccess = assigneeDataAccess;
        }
        
        public async Task ValidateAsync(IAssigneeContainer assigneeContainer)
        {
            if (assigneeContainer == null)
                throw new ArgumentException(nameof(assigneeContainer));

            var assignee = await GetBy(assigneeContainer);

            if (assigneeContainer.AssigneeId.HasValue && assignee == null)
                throw new InvalidOperationException($"Assignee is not found by id {assigneeContainer.AssigneeId}");
        }

        private async Task<Domain.Assignee> GetBy(IAssigneeContainer assigneeContainer)
        {
            return await AssigneeDataAccess.GetByAsync(assigneeContainer);
        }
    }
}