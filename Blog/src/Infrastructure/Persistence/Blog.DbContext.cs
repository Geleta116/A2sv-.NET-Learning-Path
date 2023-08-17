using Blog.src.Core.Domain.Entity;
using Blog.src.Core.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;

namespace Blog.src.Infrastructure.Persistance
{
    public class BlogDbContext : DbContext
    {
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>(entity =>
            {
                entity
                    .HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(x => x.PostId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Comment_Post");
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseDomainEntity>()){
                

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

       
    }
}