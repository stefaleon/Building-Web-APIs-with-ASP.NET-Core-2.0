using Microsoft.EntityFrameworkCore;

namespace CoreWebApiFromEmpty.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
    }
}
