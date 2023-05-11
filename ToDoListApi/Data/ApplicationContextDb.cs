using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Domain;

namespace ToDoListApi.Data
{
    public class ApplicationContextDb: DbContext
    {
        public ApplicationContextDb(DbContextOptions option):base(option)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoTask> ToDoTasks { get; set; }
    }
}
