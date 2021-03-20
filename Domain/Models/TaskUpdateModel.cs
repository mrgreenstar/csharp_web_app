using Domain.Contracts;

namespace Domain.Models
{
    public class TaskUpdateModel : ITaskIdentity, IAssigneeContainer
    {
        public int Id { get; set; }

        public string Project { get; set; }
        public string Description { get; set; }
        public State TaskState { get; set; }

        public int? AssigneeId { get; set; }
    }
}