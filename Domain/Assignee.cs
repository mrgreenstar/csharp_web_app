using System.Collections.Generic;

namespace Domain
{
    public class Assignee
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Task> TaskList { get; set; }
    }
}