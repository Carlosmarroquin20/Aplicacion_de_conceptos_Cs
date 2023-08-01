// ConsoleUserInterface.cs
using System;
using System.Collections.Generic;

public class ConsoleUserInterface : IUserInterface
{
    public void DisplayTasks(List<TaskItem> tasks)
    {
        Console.WriteLine("=== Tasks List ===");
        foreach (var task in tasks)
        {
            Console.WriteLine($"[{task.TaskId}] {(task.IsCompleted ? "[X]" : "[ ]")} {task.TaskName}");
        }
    }

    public int GetUserChoice()
    {
        Console.WriteLine("Enter your choice:");
        string input = Console.ReadLine();
        int choice;
        while (!int.TryParse(input, out choice))
        {
            Console.WriteLine("Invalid input. Please enter a number:");
            input = Console.ReadLine();
        }
        return choice;
    }

    public string GetUserInput(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine();
    }
}
