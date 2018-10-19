using kenjiuno.LibProgressMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace kenjiuno.LibProgressMonitor.Utils
{
    public class NullProgressMonitor : IProgressMonitor
    {
        bool canceled = false;

        public void beginTask(string name, int totalWork)
        {

        }
        public void done()
        {

        }
        public void internalWorked(double work)
        {

        }
        public bool isCanceled()
        {
            return canceled;
        }
        public void setCanceled(bool value)
        {
            canceled = value;
        }
        public void setTaskName(string name)
        {

        }
        public void subTask(string name)
        {

        }
        public void worked(int work)
        {

        }
    }
}
