using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BLL.InterfacesBL;
using DTO.Classes;
using DAL.Models;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskBll _taskBll;

    public TaskController(ITaskBll taskBll)
    {
        _taskBll = taskBll;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _taskBll.GetAllAsync());
    }
        

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TaskDto task)
    {
        if (task == null)
        {
            return BadRequest("Invalid task data.");
        }

        await _taskBll.AddAsync(task);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TaskDtoGetSet task)
    {
        await _taskBll.UpdateAsync(id, task);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _taskBll.DeleteAsync(id);
        return Ok();
    }
}
