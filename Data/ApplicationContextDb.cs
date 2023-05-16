using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;

namespace ToDo.Persistence
{
    public class ApplicationContextDb : DbContext
    {
        public ApplicationContextDb(DbContextOptions option) : base(option)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoTask> ToDoTasks { get; set; }
    }
}
