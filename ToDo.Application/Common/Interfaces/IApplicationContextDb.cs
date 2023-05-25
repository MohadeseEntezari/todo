using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;

namespace ToDo.Application.Common.Interfaces
{
    public interface IApplicationContextDb
    {
         DbSet<ToDoTask> ToDoTasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);


    }
}
