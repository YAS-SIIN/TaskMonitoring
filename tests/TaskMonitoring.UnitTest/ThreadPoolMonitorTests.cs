using TaskMonitoring.Application;

namespace TaskMonitoring.UnitTest;

public class ThreadPoolMonitorTests
{
    [Fact]
    public void GetActiveThreadCount_ShouldReturnValidCount()
    {
        var threadPoolMonitor = new ThreadPoolMonitor();

        var activeThreadCount = threadPoolMonitor.GetActiveThreadCount();

        Assert.True(activeThreadCount >= 0); 
    }
}