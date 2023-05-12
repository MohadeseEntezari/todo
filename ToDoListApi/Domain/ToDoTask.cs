using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApi.Domain;
public class ToDoTask
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid UserId { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public DateTime TaskDate { get; set; }

    [Required]
    public TaskStatus Status { get; set; } = TaskStatus.ToDo;
    public virtual User User { get; set; }

    public void Update(string title, DateTime taskeDate)
    {
        Title = title;
        TaskDate = taskeDate;
    }

    public void UpdateStatus(TaskStatus status)
    {
        Status = status;
    }
}


