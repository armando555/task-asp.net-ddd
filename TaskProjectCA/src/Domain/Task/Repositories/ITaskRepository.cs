namespace Domain.Task.Repositories;
using Domain.Task.Entities;
public interface ITaskRepository{
    public Task<int> AddTaskAsync(Entities.Task task);
    public Task<int> DeleteTaskAsync(Entities.Task task);
    public Task<IList<Entities.Task>> GetTasksAsync();
    public Task<Entities.Task?> GetTaskByIdAsync(int id);
    public Task<int> UpdateTaskAsync(Entities.Task task);
    
}
