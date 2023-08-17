using Microsoft.EntityFrameworkCore;
using Blog.src.Core.Domain.Entity;
using Blog.src.Infrastructure.Persistance.Repositories;
using Blog.src.Infrastructure.Persistance;
using Blog.src.Core.Application.Persistance.Contracts;

namespace Blog.src.Infrastructure.Persistance.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly BlogDbContext _context;

        public PostRepository(BlogDbContext context)
            : base(context)
        {
            _context = context;
        }

        // public Post? GetPostAsync(int postId)
        // {
        //     try
        //     {
        //         return _context.Posts.Find(postId);
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine($"An error occured while finding the post: {e.Message}");
        //         return null;
        //     }
        // }

        // public async Task UpdateCommentAsync(int postId, string title, string content)
        // {
        //     try
        //     {
        //         var post = GetPostAsync(postId);

        //         if (post == null)
        //         {
        //             return;
        //         }
        //         else
        //         {
        //             post.Title = title;
        //             post.Content = content;
        //             _context.SaveChanges();
        //             return;
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine($"An error occured while Updating the  post: {e.Message}");
        //         return;
        //     }
        // }

        // public async Task DeletePostAsync(int postId)
        // {
        //     try
        //     {
        //         var post = GetPostAsync(postId);

        //         if (post == null)
        //         {
        //             return;
        //         }
        //         else
        //         {
        //             _context.Posts.Remove(post);
        //             _context.SaveChanges();
        //             return ;
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine($"An error occured while Deleting the post: {e.Message}");
        //         return ;
        //     }
        // }

        public async Task<Post> GetAllCommentsOfAPostAsync(int postid)
        {
            try
            {
                Post? post = _context.Posts
                    .Include(p => p.Comments)
                    .FirstOrDefault(c => c.Id == postid);

                if (post == null)
                {
                    return null;
                }

                return post;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while finding the post: {e.Message}");
                return null;
            }
        }

        // public async Task AddPostAsync(string title, string content)
        // {
        //     try
        //     {
        //         Post post = new Post
        //         {
        //             Title = title,
        //             Content = content,
        //             CreatedAt = DateTime.Now.ToUniversalTime()
        //         };

        //         _context.Posts.Add(post);
        //         _context.SaveChanges();

               
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine($"An error occured while Creating a post: {e.Message}");
                
        //     }
        // }
    }
}
