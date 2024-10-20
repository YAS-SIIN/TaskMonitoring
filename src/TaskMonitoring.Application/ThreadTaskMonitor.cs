

using TaskMonitoring.Application.Models;

namespace TaskMonitoring.Application;

public class ThreadPoolMonitor : IThreadPoolMonitor
{
    public int GetActiveThreadCount()
    {
        return ThreadPool.ThreadCount;
    }
    public ThreadPoolStatus GetThreadPoolStatus()
    {
        ThreadPool.GetAvailableThreads(out int workerThreads, out int ioThreads);
        return new ThreadPoolStatus { WorkerThreadsAvailable = workerThreads, IoThreadsAvailable = ioThreads };
    }
}