using Domain.Contracts;

namespace Domain.Models
{
    public class TaskIdentityModel : ITaskIdentity
    {
        public int Id { get; }

        public TaskIdentityModel(int id)
        {
            Id = id;
        }
    }
}