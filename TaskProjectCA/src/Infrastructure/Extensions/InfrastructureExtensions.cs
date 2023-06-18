
using Application.Task;
using Domain.Task;
using Domain.Task.Repositories;

namespace Infrastructure.Extensions;
using Infrastructure.Repositories;
using Infrastructure.Repositories.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TaskDbContext>(
            o => o.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddDbContext<TaskDbContext>();
        services.AddScoped<ITaskProcess, TaskProcess>();
        return services;
    }
}