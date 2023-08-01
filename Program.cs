// Program.cs
using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        IUserInterface userInterface = new ConsoleUserInterface();
        ITaskManager taskManager = new TaskManager();

        bool exit = false;

        while (!exit)
        {
            userInterface.DisplayTasks(taskManager.GetTasks());

            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Mark Task as Completed");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Exit");
            int choice = userInterface.GetUserChoice();

            switch (choice)
            {
                case 1:
                    string taskName = userInterface.GetUserInput("Enter task name:");
                    taskManager.AddTask(taskName);
                    break;
                case 2:
                    int taskId = userInterface.GetUserChoice();
                    bool isCompleted = userInterface.GetUserInput("Mark as completed? (Y/N)").ToUpper() == "Y";
                    taskManager.UpdateTaskStatus(taskId, isCompleted);
                    break;
                case 3:
                    int taskIdToDelete = userInterface.GetUserChoice();
                    taskManager.DeleteTask(taskIdToDelete);
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
