# Task Monitoring Library

## Overview

**Task Monitoring** is a C# library designed to monitor and manage `Task` and `ThreadPool` usage in .NET applications. It provides an API to expose runtime statistics, such as the number of active threads and tasks, and detailed task execution information.

This library is useful for debugging, performance monitoring, and gaining insights into how tasks and threads are managed in your application.

## Features

- Track the number of currently active `ThreadPool` threads.
- Monitor the number of scheduled, running, and completed tasks.
- Expose detailed information about tasks, including their status, start time, and duration.
- Provides an API to access task monitoring data, which can be extended to visualize metrics in charts.

## Installation

You can install this package from NuGet using the .NET CLI:

```bash
dotnet add package TaskMonitoring
```

Or, through the NuGet Package Manager in Visual Studio:

- Right-click on your project in Solution Explorer.
- Select Manage NuGet Packages.
- Search for TaskMonitoring.
- Click Install.

NuGet Package: [TaskMonitoring](https://www.nuget.org/packages/TaskMonitoring/)

## Usage
Monitoring ThreadPool and Tasks
To monitor thread and task activity, you can use the ThreadTaskMonitor class, which provides methods to track task execution and thread pool status.


### Example:

```csharp
using TaskMonitoring;

var monitor = new ThreadTaskMonitor();

// Get the current number of active ThreadPool threads
var activeThreads = monitor.GetActiveThreadCount();
Console.WriteLine($"Active ThreadPool Threads: {activeThreads}");

// Track a task and get detailed task info
var task = Task.Run(() => {
    Thread.Sleep(1000); // Simulate some work
});

monitor.TrackTask(task);

// Get task details
var taskDetails = monitor.GetTaskDetails();
foreach (var taskInfo in taskDetails)
{
    Console.WriteLine($"Task ID: {taskInfo.TaskId}, Status: {taskInfo.Status}");
}
```

## Custom Task Scheduler
The library includes a custom TaskScheduler called MonitoringTaskScheduler that tracks tasks as they are scheduled and executed.

### Example:

```csharp
var monitoringScheduler = new MonitoringTaskScheduler();
var taskFactory = new TaskFactory(monitoringScheduler);

// Start a task using the custom task scheduler
taskFactory.StartNew(() => {
    Thread.Sleep(1000); // Simulate task work
});

taskFactory.StartNew(() => {
    Thread.Sleep(500); // Another task
});
// Get the count of scheduled tasks
int scheduledTaskCount = monitoringScheduler.GetScheduledTaskCount();
Console.WriteLine($"Currently scheduled tasks: {scheduledTaskCount}");
```

## Contributing
Contributions are welcome! If you would like to contribute, please follow these steps:

Fork the repository.
- Create a new feature branch (git checkout -b feature/your-feature-name).
- Commit your changes (git commit -m 'Add some feature').
- Push to the branch (git push origin feature/your-feature-name).
- Create a pull request.
