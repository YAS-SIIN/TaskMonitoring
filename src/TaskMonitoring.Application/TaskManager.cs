
using System.Collections.Concurrent;
using TaskMonitoring.Application.Models;

namespace TaskMonitoring.Application;

public class TaskManager : ITaskManager
{

    private readonly ConcurrentDictionary<int, TaskInfo> _tasks = new();
}