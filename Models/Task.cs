using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public enum TaskStatus
{
    Created,
    Started,

    Finshed
}

[Index("Id", IsUnique =true)]
public class SheduledTask
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }

    public TaskStatus Status {get; set;}
}