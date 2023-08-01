// IUserInterface.cs
using System.Collections.Generic;

public interface IUserInterface
{
    void DisplayTasks(List<TaskItem> tasks);
    int GetUserChoice();
    string GetUserInput(string prompt);
}
