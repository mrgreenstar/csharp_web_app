using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Assignee
    {
        public Assignee()
        {
            TaskList = new HashSet<Domain.Task>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Domain.Task> TaskList { get; set; }
    }
}