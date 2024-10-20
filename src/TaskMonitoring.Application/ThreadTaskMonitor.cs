

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

    /// <summary>
    /// Sets the minimum number of threads that the thread pool maintains for worker and IO threads.
    /// </summary>
    /// <param name="threadPoolStatus">The minimum number of worker threads and the minimum number of IO threads.</param>
    public void SetMinThreads(ThreadPoolStatus threadPoolStatus)
    {
        ThreadPool.SetMinThreads(threadPoolStatus.WorkerThreadsAvailable, threadPoolStatus.IoThreadsAvailable);
    }

    /// <summary>
    /// Sets the maximum number of threads that the thread pool can maintain for worker and IO threads.
    /// </summary>
    /// <param name="workerThreads">The maximum number of worker threads and the maximum number of IO threads.</param>
    public void SetMaxThreads(ThreadPoolStatus threadPoolStatus)
    {
        ThreadPool.SetMaxThreads(threadPoolStatus.WorkerThreadsAvailable, threadPoolStatus.IoThreadsAvailable);
    }
}