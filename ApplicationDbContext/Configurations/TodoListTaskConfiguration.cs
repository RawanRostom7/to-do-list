using Microsoft.EntityFrameworkCore;

namespace LuftbornCodeTest;

public class TodoListTaskConfiguration : IEntityTypeConfiguration<TodoListTask>
{
    public void Configure(EntityTypeBuilder<TodoListTask> builder)
    {
        builder.ToTable("ToDoListTasks");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Discription)
               .IsRequired();

        builder.Property(e => e.Deadline)
        .IsRequired();

        var todoListTasks = new List<TodoListTask>
        {
             new TodoListTask { Id = 1 , Discription = "Finish this ASP.NET Core migration", Deadline = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), Status = Status.Inprogress },
             new TodoListTask { Id = 2 , Discription = "Groceries shopping", Deadline = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), Status = Status.Finished },
             new TodoListTask { Id = 3 , Discription = "Review code for pull request", Deadline = DateOnly.FromDateTime(DateTime.Now), Status = Status.Inprogress },
             new TodoListTask { Id = 4 , Discription = "Team meeting", Deadline = DateOnly.FromDateTime(DateTime.Now.AddDays(3)), Status = Status.Finished } 
        };

        builder.HasData(todoListTasks);
    }
}

