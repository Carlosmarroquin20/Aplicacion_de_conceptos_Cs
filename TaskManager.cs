// TaskManager.cs
using System;
using System.Collections.Generic;
using System.Threading;

public class TaskItem
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public bool IsCompleted { get; set; }
}

public class TaskManager : ITaskManager
{
    private List<TaskItem> tasks;
    private int currentTaskId;
    private readonly object lockObject = new object();

    public TaskManager()
    {
        tasks = new List<TaskItem>();
        currentTaskId = 1;
    }

    public void AddTask(string taskName)
    {
        lock (lockObject)
        {
            tasks.Add(new TaskItem { TaskId = currentTaskId++, TaskName = taskName });
        }
    }

    public void UpdateTaskStatus(int taskId, bool isCompleted)
    {
        lock (lockObject)
        {
            TaskItem task = tasks.Find(t => t.TaskId == taskId);
            if (task != null)
            {
                task.IsCompleted = isCompleted;
            }
        }
    }

    public void DeleteTask(int taskId)
    {
        lock (lockObject)
        {
            tasks.RemoveAll(t => t.TaskId == taskId);
        }
    }

    public List<TaskItem> GetTasks()
    {
        return tasks;
    }
}
