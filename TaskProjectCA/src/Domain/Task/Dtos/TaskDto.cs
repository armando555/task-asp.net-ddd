namespace Domain.Task.Dtos;
using Enums;

public class TaskDto
{
    public string Assigne { get; set; }
    public string Title { get; set; }
    public DateTime WhenExecute { get; set; }
    public Boolean Executed { get; set; }
    public TaskType TaskType { get; set; }
}