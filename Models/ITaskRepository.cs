using System;
using System.Collections.Generic;
using System.Threading.Tasks;
interface ITaskRepository
{
    Task<IEnumerable<SheduledTask>> GetAll();

    Task<IEnumerable<SheduledTask>> GetUnfineshedTasksEndingBefore(DateTime t);
}