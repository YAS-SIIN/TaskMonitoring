
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

    public TaskInfo TrackTask(Task task)
    {
        throw new NotImplementedException();
    }
}