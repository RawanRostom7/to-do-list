namespace LuftbornCodeTest;

public interface ITodoListTaskRepository : IBaseRepository<TodoListTask>
{
    Task<IEnumerable<TodoListTask>> GetInProgresTasks();
    Task<IEnumerable<TodoListTask>> GetFinishedTasks();
    Task<TodoListTask> UpdatePartially(TodoListTaskDtos todoListTaskDtos); 
}