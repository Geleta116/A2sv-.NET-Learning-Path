using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Task Manager!");
            
            TaskManager taskManager = new TaskManager();
            bool running = true;
            while (running)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. List tasks");
                Console.WriteLine("2. Add task");
                Console.WriteLine("3. Update task");
                Console.WriteLine("4. Filter tasks");
                Console.WriteLine("5. Exit");
                Console.WriteLine("----------------------");
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        var allTasks = taskManager.GetTasksAsync().GetAwaiter().GetResult();
                        Console.WriteLine("NAME - DESCRIPTION - CATEGORY - STATUS");
                       
                        foreach (Tasks task in allTasks)
                        {
                            Console.WriteLine($"{task.Name} - {task.Description} - {task.Category} - {task.IsCompleted}");
                        }
                        break;

                    case "2":
                        AddTask(taskManager);
                        break;

                    case "3":
                        UpdateTask(taskManager);
                        break;

                    case "4":
                        filterTask(taskManager);
                        break;

                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        static void AddTask(TaskManager taskManager)
        {
            Console.WriteLine("Please follow the following instructions to successfully add a Task");
            Console.WriteLine("Please enter the name of the task");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be null or empty");
                return;
            }

            Console.WriteLine("Please enter the description of the task");
            string? description = Console.ReadLine();

            Console.WriteLine("Please enter the category of the task");
            Console.WriteLine("Pick the appropriate category?");
            Console.WriteLine("0. Personal");
            Console.WriteLine("1. Work");
            Console.WriteLine("2. Shopping");
            Console.WriteLine("3. Errands");

            string? categoryInput = Console.ReadLine();
             if (!int.TryParse(categoryInput, out int categoryNumber))
            {
                Console.WriteLine("Invalid category input. Please enter a valid number.");
                return;
            }

            if (!Enum.IsDefined(typeof(TaskCategory), categoryNumber) || categoryNumber < 0 || categoryNumber > 3)
            {
                Console.WriteLine("Invalid category number. Please enter a number from 0 to 3.");
                return;
            }
            TaskCategory category = (TaskCategory)categoryNumber;

            Console.WriteLine("Please enter the status of the task");
            Console.WriteLine("1. Completed");
            Console.WriteLine("2. NotCompleted");

            string? statusInput = Console.ReadLine();

            bool status;
            if (statusInput == "1")
            {
                status = true;
            }
            else if (statusInput == "2")
            {
                status = false;
            }
            else
            {
                Console.WriteLine("Invalid status input. Please enter 1 for Completed or 2 for NotCompleted.");
                return;
            }

            Tasks task = new Tasks(name, description, category, status);
            taskManager.AddTask(task);
        }

        static   void UpdateTask(TaskManager taskManager)
        {
             Console.WriteLine("Please follow the following instructions to successfully add a Task");
            Console.WriteLine("Please enter the name of the task");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be null or empty");
                return;
            }

            Console.WriteLine("Please enter the description of the task");
            string? description = Console.ReadLine();

            Console.WriteLine("Please enter the category of the task");
            Console.WriteLine("Pick the appropriate category?");
            Console.WriteLine("0. Personal");
            Console.WriteLine("1. Work");
            Console.WriteLine("2. Shopping");
            Console.WriteLine("3. Errands");

            string? categoryInput = Console.ReadLine();
           
            if (!int.TryParse(categoryInput, out int categoryNumber))
            {
                Console.WriteLine("Invalid category input. Please enter a valid number.");
                return;
            }

            if (!Enum.IsDefined(typeof(TaskCategory), categoryNumber) || categoryNumber < 0 || categoryNumber > 3)
            {
                Console.WriteLine("Invalid category number. Please enter a number from 0 to 3.");
                return;
            }

           Console.WriteLine("yooo");
                    
            TaskCategory category = (TaskCategory)categoryNumber;
                                    


            Console.WriteLine("Please enter the status of the task");
            Console.WriteLine("1. Completed");
            Console.WriteLine("2. NotCompleted");

            string? statusInput = Console.ReadLine();

            bool status;
            if (statusInput == "1")
            {
                status = true;
            }
            else if (statusInput == "2")
            {
                status = false;
            }
            else
            {
                Console.WriteLine("Invalid status input. Please enter 1 for Completed or 2 for NotCompleted.");
                return;
            }

            Tasks task = new Tasks(name, description, category, status);
            taskManager.UpdateTask(task);
        }

        static void filterTask(TaskManager taskManager)
        {
            Console.WriteLine("Please enter the category of the task");
            Console.WriteLine("Pick the appropriate category?");
            Console.WriteLine("0. Personal");
            Console.WriteLine("1. Work");
            Console.WriteLine("2. Shopping");
            Console.WriteLine("3. Errands");

            string? categoryInput = Console.ReadLine();
            if (!Enum.TryParse<TaskCategory>(categoryInput, out TaskCategory category))
            {
                Console.WriteLine("Invalid category. Please choose a valid number.");
                return;
            }
            else
            {
                var filteredTasks = taskManager.FilterTasks(category).GetAwaiter().GetResult();
                foreach (Tasks task in filteredTasks)
                {
                    Console.WriteLine($"{task.Name} - {task.Description} - {task.Category} - {task.IsCompleted}");
                }
                if(filteredTasks.Count == 0)
                {
                    Console.WriteLine("THERE ARE NO TASKS IN THIS CATEGORY");
                }
            }
        }

    }
}
