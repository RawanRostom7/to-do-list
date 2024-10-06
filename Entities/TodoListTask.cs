namespace LuftbornCodeTest;

public class TodoListTask : BaseEntity
{
    // InCase of MultiUser ToDoList 
    public int? UserId { get; set; }
    public string Discription { get; set; }
    public DateOnly Deadline { get; set; }
    public Status Status { get; set; }
}
