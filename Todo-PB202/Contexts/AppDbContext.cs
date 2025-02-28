using Microsoft.EntityFrameworkCore;
using Todo_PB202.Models;

namespace Todo_PB202.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)   
    {
        
    }
    public required DbSet<Todo > Todos{ get; set; }
}
