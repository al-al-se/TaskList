using System.Net;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
public class TaskContext : DbContext, ITaskRepository
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

    public  async Task<SheduledTask> Create(string name, DateTime begin, DateTime end)
    {
        var n = new SheduledTask(){
            Id = System.Guid.NewGuid().ToString(),
            Name = name,
            Begin = begin,
            End = end,
            Status = TaskStatus.Created
        };
        await Tasks.AddAsync(n);
        await SaveChangesAsync();
        return n;
    }

    public async Task<SheduledTask> SetFinished(string id)
    {
        var t = await Tasks.FirstAsync(i => i.Id == id);
        t.Status = TaskStatus.Finshed;
        await SaveChangesAsync();
        return t;
    }
}