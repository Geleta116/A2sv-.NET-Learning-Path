using BlogApi.Data;
using BlogApi.models;

public class CommentManager
{
    private readonly ApiDbContext _context;

    public CommentManager(ApiDbContext context)
    {
        _context = context;
    }

    public Comment? CreateComment(string text, int postid)
    {
        try
        {
            Comment comment = new Comment
            {
                Text = text,
                PostId = postid,
                CreatedAt = DateTime.Now.ToUniversalTime()
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured while Creating a comment: {e.Message}");
            return null;
        }
    }

    public Comment? UpdateComment(int id, string text)
    {
        try
        {
            Comment? foundComment = GetCommentById(id);

            if (foundComment == null)
            {
                return null;
            }
            else
            {
                foundComment.Text = text;
                _context.SaveChanges();
                return foundComment;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured while updating a comment: {e.Message}");
            return null;
        }
    }

    public Comment? GetCommentById(int id)
    {
        try
        {
            return _context.Comments.Find(id);
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured while Creating a comment: {e.Message}");
            return null;
        }
    }

    public bool DeleteCommentById(int id)
    {
        try
        {
            Comment? comment = GetCommentById(id);

            if (comment == null)
            {
                return false;
            }
            else
            {
                _context.Remove(comment);
                _context.SaveChanges();
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured while Creating a comment: {e.Message}");
            return false;
        }
    }
}
