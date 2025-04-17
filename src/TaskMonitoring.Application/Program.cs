using System;
using System.Threading.Tasks;
using TaskMonitoring.Application;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var _taskManager = new TaskManager();
        var task = Task.Run(() => { });

        var taskInfo = _taskManager.TrackTask(task);
        task.Wait();

        Console.WriteLine($"TaskId: {taskInfo.TaskId}");
        Console.WriteLine($"StartTime: {taskInfo.StartTime}");
        Console.WriteLine($"EndTime: {taskInfo.EndTime}");
        Console.WriteLine($"Status: {taskInfo.Status}");
        Console.WriteLine($"Exception: {taskInfo.Exception}");

        Console.ReadLine();
    }
}