namespace Todo_PB202.Models;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public bool IsCompleted { get; set; } = false;
}