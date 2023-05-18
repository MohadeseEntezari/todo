namespace ToDo.Application.Common.Models;

public class ToDoTaskDto
{
    public string Title { get; set; }
    public string TaskDate { get; set; }
    public TaskStatus Status { get; set; }
}
