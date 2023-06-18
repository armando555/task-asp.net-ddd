using Domain.Task;
using Domain.Task.Dtos;
using Domain.Task.Repositories;

namespace Application.Task;

public class TaskProcess : ITaskProcess
{
    private readonly ITaskRepository _taskRepository;

    public TaskProcess(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<int> AddTaskAsync(Domain.Task.Entities.Task task)
    {
        return await _taskRepository.AddTaskAsync(task);
    }

    public async Task<int> DeleteTaskAsync(int id)
    {
        var task = await _taskRepository.GetTaskByIdAsync(id);
        if (task is null)
        {
            throw new ArgumentNullException(nameof(task), "The task doesn't exists");
        }
        return await _taskRepository.DeleteTaskAsync(task);
    }

    public async Task<IList<Domain.Task.Entities.Task>> GetTasksAsync()
    {
        return await _taskRepository.GetTasksAsync();
    }

    public async Task<Domain.Task.Entities.Task?> GetTaskByIdAsync(int id)
    {
        return await _taskRepository.GetTaskByIdAsync(id);
    }

    public async Task<int> UpdateTaskAsync(Domain.Task.Entities.Task task, TaskDto taskDto)
    {
        task.Update(taskDto);
        return await _taskRepository.UpdateTaskAsync(task);
    }
}