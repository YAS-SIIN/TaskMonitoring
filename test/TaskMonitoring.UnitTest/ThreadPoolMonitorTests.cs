using TaskMonitoring.Application;
using TaskMonitoring.Application.Models;

namespace TaskMonitoring.UnitTest;

public class ThreadPoolMonitorTests
{
    private readonly ThreadPoolMonitor _threadPoolMonitor;
    public ThreadPoolMonitorTests()
    {
        _threadPoolMonitor = new ThreadPoolMonitor();
    }

    [Fact]
    public void GetActiveThreadCount_ShouldReturnValidCount()
    {
        var activeThreadCount = _threadPoolMonitor.GetActiveThreadCount();

        Assert.True(activeThreadCount >= 0);
    }

    [Fact]
    public void GetThreadPoolStatus_ShouldReturnCorrectThreadAvailability()
    { 
        ThreadPoolStatus status = _threadPoolMonitor.GetThreadPoolStatus();
         
        Assert.NotNull(status);
        Assert.True(status.WorkerThreadsAvailable >= 0);
        Assert.True(status.IoThreadsAvailable >= 0);
    }

    [Fact]
    public void SetMinThreads_ShouldSetMinimumThreadPoolThreads()
    {
        var threadPoolStatus = new ThreadPoolStatus
        {
            IoThreadsAvailable = 4,
            WorkerThreadsAvailable = 4
        };

        _threadPoolMonitor.SetMinThreads(threadPoolStatus);


        ThreadPool.GetMinThreads(out int workerThreads, out int ioThreads);
        Assert.Equal(threadPoolStatus.WorkerThreadsAvailable, workerThreads);
        Assert.Equal(threadPoolStatus.IoThreadsAvailable, ioThreads);
    }

    [Fact]
    public void SetMaxThreads_ShouldSetMaximumThreadPoolThreads()
    { 
        var threadPoolStatus = new ThreadPoolStatus
        {
            IoThreadsAvailable = 10,
            WorkerThreadsAvailable = 10
        };

        _threadPoolMonitor.SetMaxThreads(threadPoolStatus);


        ThreadPool.GetMaxThreads(out int workerThreads, out int ioThreads);
        Assert.Equal(threadPoolStatus.WorkerThreadsAvailable, workerThreads);
        Assert.Equal(threadPoolStatus.IoThreadsAvailable, ioThreads);
    }

}