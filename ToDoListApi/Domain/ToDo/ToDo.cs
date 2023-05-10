using System.ComponentModel.DataAnnotations;

namespace ToDoListApi.Domain.ToDo;
public class ToDo
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid UserId { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime ToDoDate { get; set; }

    [Required]
    public TaskStatus Status { get; set; } = TaskStatus.ToDo;

    public ToDo(Guid userId, string title, DateTime toDoDate)
    {
        UserId = userId;
        Title = title;
        CreatedAt = DateTime.Now;
        ToDoDate = toDoDate;
    }
}


