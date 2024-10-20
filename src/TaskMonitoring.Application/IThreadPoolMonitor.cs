

using TaskMonitoring.Application.Models;

namespace TaskMonitoring.Application;

public interface IThreadPoolMonitor
{
    int GetActiveThreadCount();
    ThreadPoolStatus GetThreadPoolStatus();
    void SetMinThreads(ThreadPoolStatus threadPoolStatus);
    void SetMaxThreads(ThreadPoolStatus threadPoolStatus);

}