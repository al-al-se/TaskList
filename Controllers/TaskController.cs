using System;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskRepository _repository;

    public TaskController(ITaskRepository r)
    {
        _repository = r;
    }

    [Route("GetAll")]
    [HttpGet]
    public async Task<IEnumerable<SheduledTask>> GetAll()
    {
        return await _repository.GetAll();
    }

    [Route("GetUnfineshedTasksEndingBefore")]
    [HttpGet]
    public async Task<IEnumerable<SheduledTask>> GetUnfineshedTasksEndingBefore(DateTime t)
    {
        return await _repository.GetUnfineshedTasksEndingBefore(t);
    }

    public class CreateParams
    {
        public string Name {get; set;}
        public DateTime Begin {get; set;}
        public DateTime End {get; set;}
    }

    [Route("Create")]
    [HttpPost]
    public async  Task<SheduledTask> Create(CreateParams p)
    {
        return await _repository.Create(p.Name, p.Begin, p.End);
    }

    [Route("SetFinished")]
    [HttpPost]
    public async Task<SheduledTask> SetFinished(string id)
    {
        return await _repository.SetFinished(id);
    }
}
    