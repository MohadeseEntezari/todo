namespace ToDo.Application.Common.Models;

public class ToDoTaskDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string TaskDate { get; set; }
    public TaskStatus Status { get; set; }
    public UserDto User { get; set; }
}
