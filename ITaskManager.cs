// ITaksManager.cs
using System.Collections.Generic;

public interface ITaskManager
{
    void AddTask(string taskName);
    void UpdateTaskStatus(int taskId, bool isCompleted);
    void DeleteTask(int taskId);
    List<TaskItem> GetTasks();
}
