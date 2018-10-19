using kenjiuno.LibProgressMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace kenjiuno.LibProgressMonitor.Utils
{
    public class SubProgressMonitor : ProgressMonitorWrapper
    {
        int ticksMax = 0;
        double ticksCur = 0;
        int level = 0;
        double scale = 0;

        public SubProgressMonitor(IProgressMonitor monitor, int ticks) : base(monitor)
        {
            this.ticksMax = ticks;
        }

        public override void beginTask(string name, int totalWork)
        {
            level++;
            if (level != 1) return;

            scale = (totalWork < 1) ? 0 : ((double)ticksMax / (double)totalWork);

            base.subTask(name);
        }
        public override void done()
        {
            if (level == 0) return;
            level--;
            if (level != 0) return;

            base.internalWorked(ticksMax - ticksCur);
        }
        public override void internalWorked(double work)
        {
            if (level != 1) return;

            work *= scale;
            ticksCur += work;
            base.internalWorked(work);
        }
        public override bool isCanceled()
        {
            return base.isCanceled();
        }
        public override void setCanceled(bool value)
        {
            base.setCanceled(value);
        }
        public override void setTaskName(string name)
        {
            base.subTask(name);
        }
        public override void subTask(string name)
        {

        }
        public override void worked(int work)
        {
            internalWorked(work);
        }
    }
}
