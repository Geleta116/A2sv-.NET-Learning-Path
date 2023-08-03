

public class FileManager
{
    public static async Task WriteTasksToCsvAsync(string taskDetail, string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                await writer.WriteAsync(taskDetail);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to CSV file: {ex.Message}");
        }
    }

    public static async Task<string[]> ReadTasksFromCsvAsync()
    {
        try
        {
            using (StreamReader reader = new StreamReader("tasks.csv"))
            {
                string? line = await reader.ReadLineAsync();
                List<string> taskLines = new List<string>();
                while (line != null)
                {
                    taskLines.Add(line);
                    line = await reader.ReadLineAsync();
                }
                return taskLines.ToArray();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading from CSV file: {ex.Message}");
            return new string[0]; 
        }
    }
}
    