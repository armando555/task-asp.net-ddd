using Domain.Task.Dtos;

namespace Domain.Task.Entities;
using Enums;
using Common;

public class Task : BaseEntity
{
    public string Assigne { get; set; }
    public string Title { get; set; }
    public DateTime WhenExecute { get; set; } = DateTime.Now;
    public Boolean Executed { get; set; } = false;
    public TaskType TaskType { get; set; }
    
    
    public static Task FromIssueDtoToIssue(TaskDto taskDto)
    {
        return new Task
        {
            Assigne = taskDto.Assigne,
            Title = taskDto.Title,
            WhenExecute = taskDto.WhenExecute,
            Executed = taskDto.Executed,
            TaskType = taskDto.TaskType
        };
    }

    public void Update(TaskDto taskDto)
    {
        Assigne = taskDto.Assigne;
        Title = taskDto.Title;
        WhenExecute = taskDto.WhenExecute;
        Executed = taskDto.Executed;
        TaskType = taskDto.TaskType;
    }
}