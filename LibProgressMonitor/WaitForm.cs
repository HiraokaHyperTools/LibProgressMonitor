using kenjiuno.LibProgressMonitor.Interfaces;
using kenjiuno.LibProgressMonitor.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace kenjiuno.LibProgressMonitor
{
    public partial class WaitForm : Form, IProgressMonitor
    {
        public WaitForm()
        {
            InitializeComponent();
        }

        public delegate void RunnableWithProgressDelegate(IProgressMonitor monitor);

        bool canceled = false;
        Thread thread = null;
        RunnableWithProgressDelegate runnable = null;
        ManualResetEvent evReady = new ManualResetEvent(false);

        public void beginTask(string name, int totalWork)
        {
            drawBar.nCur = 0;
            drawBar.nMax = totalWork;
            labelHint.Text = name;
            updateNow();
        }

        public void done()
        {
            drawBar.nCur = 1;
            drawBar.nMax = 1;
            setCanceled(false);
        }

        public void internalWorked(double work)
        {
            drawBar.nCur += work;
            updateNow();
        }

        public bool isCanceled()
        {
            return canceled;
        }

        public void setCanceled(bool value)
        {
            canceled = value;
            buttonCancel.Enabled = !value;
        }

        public void setTaskName(string name)
        {
            labelHint.Text = name;
            updateNow();
        }

        public void subTask(string name)
        {
            labelSubHint.Text = name;
            updateNow();
        }

        public void worked(int work)
        {
            internalWorked(work);
        }

        DrawBar drawBar = new DrawBar();

        public void progress(int cur, int max)
        {
            drawBar.nCur = cur;
            drawBar.nMax = max;
            updateNow();
        }

        public void setSub(string text)
        {
            labelSubHint.Text = text;
            updateNow();
        }

        class DrawBar
        {
            public double nCur = 0;
            public double nMax = 0;
            public Bitmap screen = null;

            public Bitmap render(Size size)
            {
                if (screen == null || screen.Size != size)
                {
                    screen = new Bitmap(size.Width, size.Height, PixelFormat.Format16bppRgb555);
                }
                Graphics canvas = Graphics.FromImage(screen);
                Rectangle rc = Rectangle.FromLTRB(0, 0, size.Width, size.Height);
                canvas.FillRectangle(Brushes.White, rc);
                if (nMax != 0)
                {
                    rc.Width = (int)((1.0 * size.Width) * nCur / nMax);
                }
                canvas.FillRectangle(Brushes.Blue, rc);

                return screen;
            }
        }

        void updateNow()
        {
            Bitmap img = drawBar.render(pictureBoxBar.Size);
            pictureBoxBar.Image = img;

            Update();
        }

        void ButtonCancelClick(object sender, System.EventArgs e)
        {
            canceled = true;
            buttonCancel.Enabled = false;
        }

        void WaitForm2Load(object sender, System.EventArgs e)
        {
            evReady.Set();
        }

        void WaitFormClosed(object sender, System.EventArgs e)
        {

        }

        public void run(bool fork, bool cancelable, IRunnableWithProgress runnable)
        {
            run(fork, cancelable, monitor => runnable.run(monitor));
        }

        public void run(bool fork, bool cancelable, RunnableWithProgressDelegate runnable)
        {
            buttonCancel.Enabled = cancelable;

            this.runnable = runnable;

            if (fork)
            {
                thread = new Thread(new ThreadStart(runAsync));
                thread.Start();

                ShowDialog();

                if (error != null)
                {
                    throw new TargetInvocationException(error);
                }
            }
            else
            {
                Show();
                this.runnable(this);
            }
        }

        delegate void onFinish(Exception err);

        Exception error = null;

        void finish(Exception err)
        {
            thread = null;
            error = err;
            Close();
        }

        void runAsync()
        {
            try
            {
                evReady.WaitOne();
                runnable(new ProgressMonitorDelegateProxy(this, this));

                Thread.Sleep(333);
                Invoke(new onFinish(this.finish), new object[] { null });
            }
            catch (Exception err)
            {
                Invoke(new onFinish(this.finish), new object[] { err });
            }
        }

        void WaitFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (thread != null && thread.IsAlive)
            {
                e.Cancel = true;
                ButtonCancelClick(sender, null);
            }
        }
    }
}
