using Application.Task;


namespace WebApi.Controllers;
using Domain.Task.Entities;
using Domain.Task.Dtos;
using Domain.Task;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TaskController: ControllerBase
{
    private readonly ITaskProcess _taskProcess;
    private readonly ILogger<TaskController> _logger;

    public TaskController(ILogger<TaskController> logger, ITaskProcess taskProcess)
    {
        _taskProcess = taskProcess;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Domain.Task.Entities.Task?>> Get() => await _taskProcess.GetTasksAsync();
    
    [HttpGet("id")]
    [ProducesResponseType(typeof(Domain.Task.Entities.Task), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var issue = await _taskProcess.GetTaskByIdAsync(id);
        return issue == null ? NotFound() : Ok(issue);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(Domain.Task.Entities.Task), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(TaskDto task)
    {
        var id = await _taskProcess.AddTaskAsync(Domain.Task.Entities.Task.FromIssueDtoToIssue(task));
        return CreatedAtAction(nameof(GetById), new { id}, id);
    }
}