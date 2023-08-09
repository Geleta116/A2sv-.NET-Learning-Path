using Microsoft.EntityFrameworkCore;
using PostgresDb.Data;
using PostgresDb.Models;

public class PostManager
{
    private readonly ApiDbContext _context;
    public PostManager(ApiDbContext context)
    {
        _context = context;
    }

    public Post? CreatePost(string title, string content)
    {
        try {
        Post post = new Post
        {
            Title = title,
            Content = content,
            CreatedAt = DateTime.Now.ToUniversalTime()
        };

        _context.Posts.Add(post);
        _context.SaveChanges();

        return post;
        } catch ( Exception e) {
            Console.WriteLine($"An error occured while Creating a post: {e.Message}");
            return null;
        }
    }

    public Post? GetPostById(int postId)
    {
        try {
        return _context.Posts.Find(postId);
        } catch ( Exception e) {
            Console.WriteLine($"An error occured while finding the post: {e.Message}");
            return null;
        }
    }

    public Post? UpdatePost(int postId, string title, string content)
    {
        try {
        var post = GetPostById(postId);

        if (post == null)
        {
            return null;
        }
        else
        {
            post.Title = title;
            post.Content = content;
            _context.SaveChanges();
            return post;
        }
        } catch ( Exception e) {
            Console.WriteLine($"An error occured while Updating the  post: {e.Message}");
            return null;
        }
    }

    public bool DeletePost(int postId)
    {
        try {
        var post = GetPostById(postId);

        if (post == null)
        {
            return false;
        }
        else
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return true;
        }
        } catch ( Exception e) {
            Console.WriteLine($"An error occured while Deleting the post: {e.Message}");
            return false;
        }
    }

    public Post? GetPostWithComment(int postid)
    {
        try
        {
            Post? post = _context.Posts
                .Include(p => p.Comments)
                .FirstOrDefault(c => c.PostId == postid);

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

}