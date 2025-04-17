
using TaskMonitoring.Application.Models;

namespace TaskMonitoring.Application
{
    public interface ITaskManager
    {
        TaskInfo TrackTask(Task task);
        int GetPendingTaskCount();
        List<TaskInfo> GetTaskDetails();
    }
}


