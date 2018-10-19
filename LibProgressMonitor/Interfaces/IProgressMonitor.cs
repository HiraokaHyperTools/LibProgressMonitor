using System;
using System.Collections.Generic;
using System.Text;

namespace kenjiuno.LibProgressMonitor.Interfaces
{
    public interface IProgressMonitor
    {
        void beginTask(string name, int totalWork);
        void done();
        void internalWorked(double work);
        bool isCanceled();
        void setCanceled(bool value);
        void setTaskName(string name);
        void subTask(string name);
        void worked(int work);
    }
}
