﻿
using System.Collections.Concurrent;
using TaskMonitoring.Application.Models;

namespace TaskMonitoring.Application;

public class TaskManager : ITaskManager
{

    private readonly ConcurrentDictionary<int, TaskInfo> _tasks = new();

    /// <summary>
    /// Retrieves the count of pending tasks, which are either waiting to run or currently running.
    /// </summary>
    /// <returns>The count of pending tasks.</returns>
    public int GetPendingTaskCount()
    {
        return _tasks.Values.Count(t => t.Status == TaskStatus.WaitingToRun || t.Status == TaskStatus.Running);
    }

    /// <summary>
    /// Returns a list of details about all tracked tasks, including their ID, status, and duration.
    /// </summary>
    /// <returns>A list of TaskInfo objects representing the tracked tasks.</returns>
    public List<TaskInfo> GetTaskDetails()
    {
        return _tasks.Values.ToList();
    }

    /// <summary>
    /// Tracks the specified task, capturing its start time and status, and updates the information when the task completes.
    /// </summary>
    /// <param name="task">The task to track.</param>
    /// <returns>A TaskInfo object containing details about the task.</returns>
    public TaskInfo TrackTask(Task task)
    {
        var taskInfo = new TaskInfo
        {
            TaskId = task.Id,
            Status = task.Status,
            StartTime = DateTime.Now
        };

        _tasks.TryAdd(task.Id, taskInfo);

        task.ContinueWith(t =>
        {
            taskInfo.Status = t.Status;
            taskInfo.EndTime = DateTime.Now;
            if (t.IsFaulted && t.Exception != null)
            {
                taskInfo.Exception = t.Exception;
            }
        });

        return taskInfo;
    }
}