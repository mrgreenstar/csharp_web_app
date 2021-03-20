using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Context
{
    public partial class TaskDirectoryContext : DbContext
    {
        public TaskDirectoryContext(){}

        public TaskDirectoryContext(DbContextOptions<TaskDirectoryContext> contextOptions) : base (contextOptions)
        {}
        
        public virtual DbSet<Assignee> Assignees { get; set; }
        public virtual DbSet<Domain.Task> Tasks { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignee>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            });

            modelBuilder.Entity<Domain.Task>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(e => e.Project).IsRequired();

                entity.Property(e => e.TaskState).IsRequired();

                entity.HasOne(d => d.Assignee)
                    .WithMany(p => p.TaskList)
                    .HasForeignKey(d => d.AssigneeId)
                    .HasConstraintName("FK_Task_Assignee");
            });
            
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}