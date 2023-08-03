using System;
using System.Text;
using System.Threading.Tasks;


public class TaskManager
{
    
    List<Tasks> taskList = new List<Tasks>();
    public async Task<List<Tasks>> GetTasksAsync()
    {
        string[] taskLines = await FileManager.ReadTasksFromCsvAsync();
        foreach (string taskLine in taskLines)
        {
            string[] taskDetails = taskLine.Split(',');

            if (Enum.TryParse<TaskCategory>(taskDetails[2], out TaskCategory category)
                && bool.TryParse(taskDetails[3], out bool isCompleted))
            {
                Tasks task = new Tasks(taskDetails[0], taskDetails[1], category, isCompleted);

                
                if (!taskList.Any(t => t.Name == task.Name && t.Description == task.Description))
                {
                    taskList.Add(task);
                }
            }
            else
            {
                Console.WriteLine($"Invalid Task data: {taskLine}");
            }
        }
        return taskList;
    }


    public async void AddTask(Tasks task)
    {
        taskList.Add(task);
        await SaveTasksAsync();
        
    }

    public async Task<List<Tasks>> FilterTasks(TaskCategory category)
    {
        List<Tasks>? filteredTasks = new List<Tasks>();
        List<Tasks> allTaskList = await GetTasksAsync();
        filteredTasks = allTaskList.Where(task => task.Category == category).ToList();
        return filteredTasks;
    }

    public async Task<bool> UpdateTask( Tasks updatedTask)
    {
        Tasks taskToUpdate = taskList.First(task => task.Name == updatedTask.Name);
        if (taskToUpdate != null)
        {
            taskToUpdate.Description = updatedTask.Description;
            taskToUpdate.Category = updatedTask.Category;
            taskToUpdate.IsCompleted = updatedTask.IsCompleted;

            await SaveTasksAsync(); 
            return true;
        }

        return false; 
    }

    private async Task SaveTasksAsync()
    {
        StringBuilder csvString = new StringBuilder();
        

        foreach (var task in taskList)
        {
            csvString.AppendLine($"{task.Name},{task.Description},{task.Category},{task.IsCompleted}");
        }

        await FileManager.WriteTasksToCsvAsync(csvString.ToString(), "tasks.csv");
    }
}

