using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Common.Interfaces;
using ToDo.Domain.Entities;

namespace ToDo.Persistence
{
    public class ApplicationContextDb : IdentityDbContext<IdentityUser>, IApplicationContextDb
    {
        public ApplicationContextDb(DbContextOptions<ApplicationContextDb> option) : base(option)
        {

        }

        public DbSet<ToDoTask> ToDoTasks { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
