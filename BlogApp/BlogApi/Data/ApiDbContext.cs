using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostgresDb.Models;

namespace PostgresDb.Data
{

public class ApiDbContext: DbContext
{
    public virtual DbSet<Post> Posts { get; set; } = null!;
    public virtual DbSet<Comment> Comments { get; set; } = null!;
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>(entity =>
        {
              entity.HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(x => x.PostId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Comment_Post");
        });
    }
}
    
}
