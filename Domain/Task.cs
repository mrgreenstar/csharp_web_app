
using Domain.Contracts;

namespace Domain
{
    public class Task : IAssigneeContainer
    {
        public int Id { get; set; }
        public string Project { get; set; }
        public string Description { get; set; }
        public State TaskState { get; set; }

        public Assignee Assignee { get; set; }
        
        public int? AssigneeId => this.Assignee.Id;
    }
}