
using System;
using System.Threading.Tasks;

namespace TaskMonitoring.Application.Models
{
    public class TaskInfo
    {
        public int TaskId { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? Duration
        {
            get
            {
                if (EndTime.HasValue && StartTime.HasValue)
                {
                    return EndTime.Value - StartTime.Value;
                }
                return null;
            }
        }
        public Exception? Exception { get; set; }
    }

}


