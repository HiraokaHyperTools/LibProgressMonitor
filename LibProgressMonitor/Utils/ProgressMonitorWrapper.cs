using kenjiuno.LibProgressMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace kenjiuno.LibProgressMonitor.Utils
{
    public class ProgressMonitorWrapper : IProgressMonitor
    {
        IProgressMonitor monitor;

        public ProgressMonitorWrapper(IProgressMonitor monitor)
        {
            this.monitor = monitor;
        }
        public virtual void beginTask(string name, int totalWork)
        {
            monitor.beginTask(name, totalWork);
        }
        public virtual void done()
        {
            monitor.done();
        }
        public virtual void internalWorked(double work)
        {
            monitor.internalWorked(work);
        }
        public virtual bool isCanceled()
        {
            return monitor.isCanceled();
        }
        public virtual void setCanceled(bool value)
        {
            monitor.setCanceled(value);
        }
        public virtual void setTaskName(string name)
        {
            monitor.setTaskName(name);
        }
        public virtual void subTask(string name)
        {
            monitor.subTask(name);
        }
        public virtual void worked(int work)
        {
            monitor.worked(work);
        }

        public IProgressMonitor getWrappedProgressMonitor()
        {
            return monitor;
        }
    }
}
