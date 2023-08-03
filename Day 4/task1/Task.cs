public class Tasks
{
    public  string Name { get; set; }
        public string? Description { get; set; } 
    public TaskCategory Category { get; set; }
    public bool IsCompleted { get; set; }
    

    public Tasks(string name, string? description,TaskCategory Category, bool IsCompleted )
    {
    Name = name;

    Description = description;

    this.Category = Category;
    
    this.IsCompleted = IsCompleted;

    }
}
