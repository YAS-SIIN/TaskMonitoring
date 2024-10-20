

using TaskMonitoring.Application.Models;

namespace TaskMonitoring.Application;

public interface IThreadPoolMonitor
{
    int GetActiveThreadCount();
    ThreadPoolStatus GetThreadPoolStatus();
}