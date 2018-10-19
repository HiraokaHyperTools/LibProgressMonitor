using System;
using System.Collections.Generic;
using System.Text;

namespace kenjiuno.LibProgressMonitor.Interfaces
{
    public interface IRunnableWithProgress
    {
        void run(IProgressMonitor monitor);
    }
}
