namespace Infrastructure.Repositories;
using Domain.Task.Repositories;
using Infrastructure.Repositories.DbContext;
using Microsoft.EntityFrameworkCore;

public class TaskRepository: ITaskRepository
{
    private readonly TaskDbContext _taskDbContext;

    public TaskRepository(TaskDbContext taskDbContext)
    {
        _taskDbContext = taskDbContext;
    }
    
    public async Task<int> AddTaskAsync(Domain.Task.Entities.Task task)
    {
        if (task is null)
        {
            throw new ArgumentNullException(nameof(task), "Error the task is null");
        }

        await _taskDbContext.Tasks.AddAsync(task);
        await _taskDbContext.SaveChangesAsync();
        return task.Id;
    }

    public async Task<int> DeleteTaskAsync(Domain.Task.Entities.Task task)
    {
        _taskDbContext.Remove(task);
        return await _taskDbContext.SaveChangesAsync();
    }

    public async Task<IList<Domain.Task.Entities.Task?>> GetTasksAsync()
    {
        return await _taskDbContext.Tasks.ToListAsync();
        
    }

    public async Task<Domain.Task.Entities.Task?> GetTaskByIdAsync(int id)
    {
        if (id < 0)
        {
            throw new ArgumentNullException(nameof(id), "Error the id is negative number");
        }
        return await _taskDbContext.Tasks.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<int> UpdateTaskAsync(Domain.Task.Entities.Task task)
    {
        _taskDbContext.Tasks.Entry(task).State = EntityState.Modified;
        return await _taskDbContext.SaveChangesAsync();
    }
}