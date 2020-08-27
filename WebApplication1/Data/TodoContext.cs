using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data {
  public class TodoContext : DbContext { 
    public TodoContext(): base(){ }  
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options) {
    }
    public DbSet<TodoItem> TodoItems { get; set; }
  }
}
