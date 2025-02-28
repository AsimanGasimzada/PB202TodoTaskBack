namespace Todo_PB202.Dtos;

public class TodoGetDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public bool IsCompleted { get; set; } = false;
}