namespace Infrastructure.Repositories.DbContext.ModelBuilders;
using Microsoft.EntityFrameworkCore;


public static class TaskModelBuilder
{
    public static void MapTask(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Task.Entities.Task>(i =>
        {
            i.Property(o=> o.Id).ValueGeneratedOnAdd();
            i.Property(o => o.Title).HasMaxLength(60).IsRequired();
            i.Property(o => o.Assigne).HasMaxLength(100).IsRequired();
        });
    }
}