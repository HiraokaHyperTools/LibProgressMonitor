using kenjiuno.LibProgressMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace kenjiuno.LibProgressMonitor.Utils
{
    public class ProgressMonitorDelegateProxy : IProgressMonitor
    {
        private readonly Control uiThread;
        private readonly IProgressMonitor stub;

        public ProgressMonitorDelegateProxy(Control uiThread, IProgressMonitor stub)
        {
            this.uiThread = uiThread;
            this.stub = stub;
        }

        delegate void onBeginTask(string name, int totalWork);
        delegate void onDone();
        delegate void onInternalWorked(double work);
        delegate bool onIsCanceled();
        delegate void onSetCanceled(bool value);
        delegate void onSetTaskName(string name);
        delegate void onSubTask(string name);
        delegate void onWorked(int work);

        public void beginTask(string name, int totalWork)
        {
            uiThread.Invoke(new onBeginTask(stub.beginTask), new object[] { name, totalWork });
        }

        public void done()
        {
            uiThread.Invoke(new onDone(stub.done));
        }

        public void internalWorked(double work)
        {
            uiThread.Invoke(new onInternalWorked(stub.internalWorked), new object[] { work });
        }

        public bool isCanceled()
        {
            return (bool)uiThread.Invoke(new onIsCanceled(stub.isCanceled));
        }

        public void setCanceled(bool value)
        {
            uiThread.Invoke(new onSetCanceled(stub.setCanceled), new object[] { value });
        }

        public void setTaskName(string name)
        {
            uiThread.Invoke(new onSetTaskName(stub.setTaskName), new object[] { name });
        }

        public void subTask(string name)
        {
            uiThread.Invoke(new onSubTask(stub.subTask), new object[] { name });
        }

        public void worked(int work)
        {
            uiThread.Invoke(new onWorked(stub.worked), new object[] { work });
        }
    }
}
