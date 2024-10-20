using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMonitoring;

public class ThreadTaskMonitor
{
    public int GetActiveThreadCount()
    {
        return ThreadPool.ThreadCount;
    }
 
 
}
