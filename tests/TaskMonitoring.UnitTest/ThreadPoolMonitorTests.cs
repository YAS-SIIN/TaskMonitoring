using TaskMonitoring.Application;
using TaskMonitoring.Application.Models;

namespace TaskMonitoring.UnitTest;

public class ThreadPoolMonitorTests
{
    private readonly ThreadPoolMonitor threadPoolMonitor;
    public ThreadPoolMonitorTests()
    {
        threadPoolMonitor = new ThreadPoolMonitor();
    }

    [Fact]
    public void GetActiveThreadCount_ShouldReturnValidCount()
    {
        var activeThreadCount = threadPoolMonitor.GetActiveThreadCount();

        Assert.True(activeThreadCount >= 0);
    }

    [Fact]
    public void GetThreadPoolStatus_ShouldReturnCorrectThreadAvailability()
    { 
        ThreadPoolStatus status = threadPoolMonitor.GetThreadPoolStatus();
         
        Assert.NotNull(status);
        Assert.True(status.WorkerThreadsAvailable >= 0);
        Assert.True(status.IoThreadsAvailable >= 0);
    }

}