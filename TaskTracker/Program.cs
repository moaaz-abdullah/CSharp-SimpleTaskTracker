namespace TaskTracker
{
    internal class Program
    {
        static List<string> tasks = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Task Tracker");
            Console.WriteLine("-----------------------");

            while (true)
            {
                ShowMenu();

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;

                    case "2":
                        ViewTasks();
                        break;

                    case "3":
                        MarkAsCompleted();
                        break;

                    case "4":
                        DeleteTask();
                        break;

                    case "5":
                        Console.WriteLine("Quitting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\nSelect a choice...\n");
            Console.WriteLine("1 - Add task");
            Console.WriteLine("2 - View all tasks");
            Console.WriteLine("3 - Mark task as complete");
            Console.WriteLine("4 - Delete task");
            Console.WriteLine("5 - Quit");
        }

        static void AddTask()
        {
            Console.Write("Task name: ");

            string? taskTitle = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(taskTitle))
            {
                Console.WriteLine("Task cannot be empty");
                return;
            }

            tasks.Add(taskTitle);

            Console.WriteLine("Task has been added!");
        }

        static void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks yet");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}- {tasks[i]}");
            }
        }

        static void MarkAsCompleted()
        {
            ViewTasks();

            Console.Write("Task ID: ");

            if (!int.TryParse(Console.ReadLine(), out int taskId))
            {
                Console.WriteLine("Invalid number");
                return;
            }

            taskId--;

            if (taskId < 0 || taskId >= tasks.Count)
            {
                Console.WriteLine("Task not found");
                return;
            }

            tasks[taskId] += " -- COMPLETED";

            Console.WriteLine("Task marked as completed");
        }

        static void DeleteTask()
        {
            ViewTasks();

            Console.Write("Task ID: ");

            if (!int.TryParse(Console.ReadLine(), out int taskId))
            {
                Console.WriteLine("Invalid number");
                return;
            }

            taskId--;

            if (taskId < 0 || taskId >= tasks.Count)
            {
                Console.WriteLine("Task not found");
                return;
            }

            tasks.RemoveAt(taskId);

            Console.WriteLine("Task deleted successfully");
        }
    }
}