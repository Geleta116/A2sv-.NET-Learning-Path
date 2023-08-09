using Microsoft.EntityFrameworkCore;

public class BlogDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public BlogDbContext(DbContextOptions<BlogDbContext> options)
        : base(options)
    {
         options.use UseSqlServer(@"Server=.\;Database=EFCoreDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}
