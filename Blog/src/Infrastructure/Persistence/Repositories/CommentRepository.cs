using Microsoft.EntityFrameworkCore;
using Blog.src.Core.Domain.Entity;
using Blog.src.Infrastructure.Persistance.Repositories;
using Blog.src.Infrastructure.Persistance;
using Blog.src.Core.Application.Persistance.Contracts;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    private readonly BlogDbContext _context;

    public CommentRepository(BlogDbContext context)
        : base(context)
    {
        _context = context;
    }

   

    // public Comment? UpdateAsync(int id, string text)
    // {
    //     try
    //     {
    //         Comment? foundComment = GetCommentAsync(id);

    //         if (foundComment == null)
    //         {
    //             return null;
    //         }
    //         else
    //         {
    //             foundComment.Text = text;
    //             _context.SaveChanges();
    //             return foundComment;
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine($"An error occured while updating a comment: {e.Message}");
    //         return null;
    //     }
    // }

    // public Comment? GetCommentAsync(int id)
    // {
    //     try
    //     {
    //         return _context.Comments.Find(id);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine($"An error occured while Creating a comment: {e.Message}");
    //         return null;
    //     }
    // }

    // public async Task DeleteCommentAsync(int id)
    // {
    //     try
    //     {
    //         Comment? comment = GetCommentAsync(id);

    //         if (comment == null)
    //         {
    //             return ;
    //         }
    //         else
    //         {
    //             _context.Remove(comment);
    //             _context.SaveChanges();
    //             return ;
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine($"An error occured while Creating a comment: {e.Message}");
    //         return ;
    //     }
    // }

    public async Task AddCommentAsync(int postId, string text)
    {
        try
        {
            Comment comment = new Comment
            {
                Text = text,
                PostId = postId,
                CreatedAt = DateTime.Now.ToUniversalTime()
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
           
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured while Creating a comment: {e.Message}");
            throw new Exception($"An error occured while creating a comment: {e.Message}");
            
        }
    }

    // public async Task UpdateCommentAsync(int Id, string Text)
    // {
    //     try
    //     {
    //         Comment? foundComment = GetCommentAsync(Id);

    //         if (foundComment == null)
    //         {
                
    //         }
    //         else
    //         {
    //             foundComment.Text = Text;
    //             _context.SaveChanges();
               
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine($"An error occured while updating a comment: {e.Message}");
    //         throw new Exception($"An error occured while updating a comment: {e.Message}");
    //     }
    // }
}
