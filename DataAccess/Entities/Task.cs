using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain;

namespace DataAccess.Entities
{
    public class Task
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Project { get; set; }
        public string Description { get; set; }
        public State TaskState { get; set; }

        public virtual Assignee Assignee { get; set; }
        public int? AssigneeId { get; set; }
    }
}