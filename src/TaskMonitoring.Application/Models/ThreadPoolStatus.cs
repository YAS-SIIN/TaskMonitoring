
namespace TaskMonitoring.Application.Models;

public class ThreadPoolStatus
{
    public int WorkerThreadsAvailable { get; set; }
    public int IoThreadsAvailable { get; set; }
}
