using System.Net;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
class TaskContext : DbContext, ITaskRepository
{
    private DbSet<SheduledTask> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options)
        : base(options)
    {
            Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SheduledTask>().ToTable("Tasks");
    }
    public  async Task<IEnumerable<SheduledTask>> GetAll()
    {
        var r = await Tasks.ToListAsync();
        return r;
    }

    public  async Task<IEnumerable<SheduledTask>> GetUnfineshedTasksEndingBefore(DateTime t)
    {
        var r = await Tasks.Where(i =>
                 i.Status != TaskStatus.Finshed && i.End < t).ToListAsync();
        return r;
    }
}