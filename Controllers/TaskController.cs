using System;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

[ApiController]
[Route("[controller]")]
class TaskController : ControllerBase
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
}
    