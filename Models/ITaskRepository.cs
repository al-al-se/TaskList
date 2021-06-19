using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITaskRepository
{
    Task<IEnumerable<SheduledTask>> GetAll();

    Task<IEnumerable<SheduledTask>> GetUnfineshedTasksEndingBefore(DateTime t);

    Task<SheduledTask> Create(string name, DateTime begin, DateTime end);

    Task<SheduledTask> SetFinished(string id);
}