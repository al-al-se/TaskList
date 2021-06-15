using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

enum TaskState
{
    Created,
    Started,

    Finshed
}

[Index("Id", IsUnique =true)]
class Task
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }

    public TaskState State {get; set;}
}