namespace LuftbornCodeTest;

public class TodoListTaskDtos : BaseEntity
{
    // In Case of MultiUser ToDoList 
    public int? UserId { get; set; }
    public string? Discription { get; set; }
    public DateOnly? Deadline { get; set; }
    public Status? Status { get; set; }
}
