namespace LuftbornCodeTest;

[Route("api/[controller]")]
[ApiController]
public class TodoListTasksController(ITodoListTaskRepository _todoListTaskRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoListTask>>> GetTasks()
    {
        IEnumerable<TodoListTask> tasks = await _todoListTaskRepository.Get();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoListTask>> GetTask(int id)
    {
        var TodoListTask = await _todoListTaskRepository.Get(id);

        if (TodoListTask == null)
        {
            return NotFound();
        }

        return Ok(TodoListTask);
    }

    [HttpPut]
    public async Task<IActionResult> PutTask(TodoListTaskDtos todoListTaskDtos)
    {
            TodoListTask updatedToDoTask = await _todoListTaskRepository.UpdatePartially(todoListTaskDtos);

        return CreatedAtAction("GetTask", new { id = updatedToDoTask.Id }, updatedToDoTask);
    }


    [HttpPost]
    public async Task<ActionResult<TodoListTask>> PostTask(TodoListTask todoListTask)
    {
        await _todoListTaskRepository.Add(todoListTask);

        return CreatedAtAction("GetTask", new { id = todoListTask.Id }, todoListTask);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await _todoListTaskRepository.Remove(id);

        return NoContent();
    }

    [HttpGet("FinishedTasks")]
    public async Task<ActionResult<IEnumerable<TodoListTask>>> GetFinishedTasks()
    {
        IEnumerable<TodoListTask> tasks = await _todoListTaskRepository.GetFinishedTasks(); 
        return Ok(tasks);
    }

    [HttpGet("InProgressTasks")]
    public async Task<ActionResult<IEnumerable<TodoListTask>>> GetInProgressTasks()
    {
        IEnumerable<TodoListTask> tasks = await _todoListTaskRepository.GetInProgresTasks();
        return Ok(tasks);
    }
}