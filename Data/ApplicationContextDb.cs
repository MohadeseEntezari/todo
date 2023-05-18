using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;

namespace ToDo.Persistence
{
    public class ApplicationContextDb : IdentityDbContext<IdentityUser>
    {
        public ApplicationContextDb(DbContextOptions<ApplicationContextDb> option) : base(option)
        {

        }

        public DbSet<ToDoTask> ToDoTasks { get; set; }
    }
}
