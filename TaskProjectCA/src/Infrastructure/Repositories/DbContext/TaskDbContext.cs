using Infrastructure.Repositories.DbContext.ModelBuilders;

namespace Infrastructure.Repositories.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class TaskDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }
    public DbSet<Domain.Task.Entities.Task> Tasks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.MapTask();
    }
}