using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskMonitoring.Application;

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


}
