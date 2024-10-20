
namespace TaskMonitoring.Application.Models;

public class TaskInfo
{
    public int TaskId { get; set; }
    public TaskStatus Status { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public TimeSpan? Duration => EndTime.HasValue && StartTime.HasValue ? EndTime.Value - StartTime.Value : null;
    public Exception? Exception { get; set; }
}

