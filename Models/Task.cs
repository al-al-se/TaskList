using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

enum TaskStatus
{
    Created,
    Started,

    Finshed
}

[Index("Id", IsUnique =true)]
class SheduledTask
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }

    public TaskStatus Status {get; set;}
}