using Domain.Task.Dtos;

namespace Domain.Task;
using Entities;

public interface ITaskProcess
{
    public Task<int> AddTaskAsync(Entities.Task task);
    public Task<int> DeleteTaskAsync(int id);
    public Task<IList<Entities.Task>> GetTasksAsync();
    public Task<Entities.Task?> GetTaskByIdAsync(int id);
    public Task<int> UpdateTaskAsync(Entities.Task task, TaskDto taskDto);
}