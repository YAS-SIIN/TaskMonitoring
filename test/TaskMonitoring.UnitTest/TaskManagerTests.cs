using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskMonitoring.Application;
using TaskMonitoring.Application.Models;

namespace TaskMonitoring.UnitTest;

public class TaskManagerTests
{
    private readonly TaskManager _taskManager;
    public TaskManagerTests()
    {
        _taskManager = new TaskManager();
    }

    [Fact]
    public void TrackTask_ShouldTrackTaskCorrectly()
    {
        // Create a simple task
        var task = Task.Run(() => { });

        var taskInfo = _taskManager.TrackTask(task);
        task.Wait();

        Assert.Equal(task.Id, taskInfo.TaskId);
        Assert.NotNull(taskInfo.StartTime);
        Assert.NotNull(taskInfo.EndTime);
        Assert.Equal(TaskStatus.RanToCompletion, taskInfo.Status);
        Assert.Null(taskInfo.Exception);
    }

    [Fact]
    public void GetPendingTaskCount_ShouldReturnPendingTasks()
    {
        var task1 = new Task(() => Task.Delay(1000));
        var task2 = new Task(() => Task.Delay(1000));

        _taskManager.TrackTask(task1);
        _taskManager.TrackTask(task2);


        var pendingTaskCount = _taskManager.GetPendingTaskCount();

        Assert.Equal(2, pendingTaskCount);
    }

    [Fact]
    public void GetTaskDetails_ShouldReturnAllTrackedTasks()
    {
        var task1 = Task.Run(() => { });
        var task2 = Task.Run(() => { });

        _taskManager.TrackTask(task1);
        _taskManager.TrackTask(task2);
        Task.WaitAll(task1, task2);

        var taskDetails = _taskManager.GetTaskDetails();

        Assert.Equal(2, taskDetails.Count);
        Assert.Contains(taskDetails, t => t.TaskId == task1.Id);
        Assert.Contains(taskDetails, t => t.TaskId == task2.Id);
    }

    [Fact]
    public void TrackTask_ShouldCaptureTaskExceptions()
    {
        var task = Task.Run(() => throw new InvalidOperationException());

        var taskInfo = _taskManager.TrackTask(task);

        // Check the task throws the exception
        Assert.Throws<AggregateException>(() => task.Wait());

        Assert.Equal(TaskStatus.Faulted, taskInfo.Status);
        Assert.NotNull(taskInfo.Exception);
        Assert.IsType<InvalidOperationException>(taskInfo.Exception.InnerException);
    }


    [Fact]
    public void GetCompletedTaskCount_ShouldReturnCompletedTasks()
    {

        var task1 = Task.Run(() => Task.Delay(500));
        var task2 = Task.Run(() => Task.Delay(500));

        _taskManager.TrackTask(task1);
        _taskManager.TrackTask(task2);

        Task.WaitAll(task1, task2);
         
        var completedTaskCount = _taskManager.GetTaskDetails().Count(t => t.Status == TaskStatus.RanToCompletion);
         
        Assert.Equal(2, completedTaskCount); 
    }
}
