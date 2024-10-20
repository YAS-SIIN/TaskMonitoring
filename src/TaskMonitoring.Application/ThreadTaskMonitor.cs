

using TaskMonitoring.Application.Models;

namespace TaskMonitoring.Application;

public class ThreadPoolMonitor : IThreadPoolMonitor
{
    /// <summary>
    /// Retrieves the total number of active threads in the thread pool.
    /// </summary>
    /// <returns>The current active thread count in the thread pool.</returns>
    public int GetActiveThreadCount()
    {
        return ThreadPool.ThreadCount;
    }

    /// <summary>
    /// Retrieves the current status of the thread pool, including the number of available worker and IO threads.
    /// </summary>
    /// <returns>A ThreadPoolStatus object containing the number of available worker and IO threads.</returns>
    public ThreadPoolStatus GetThreadPoolStatus()
    {
        ThreadPool.GetAvailableThreads(out int workerThreads, out int ioThreads);
        return new ThreadPoolStatus { WorkerThreadsAvailable = workerThreads, IoThreadsAvailable = ioThreads };
    }
}