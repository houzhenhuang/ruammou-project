using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Diagnostics;

namespace MyThread
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        #region btnSync_Click
        private void btnSync_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine();
            Console.WriteLine("****************btnSync_Click Start 主线程id{0}*********************", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("btnSync_Click_{0}", i);
                TestThread(name);
            }
            watch.Stop();
            Console.WriteLine("****************btnSync_Click End 主线程id{0}用时{1}毫秒*********************", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
        }
        #endregion

        #region btnAsync_Click
        private void btnAsync_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine();
            Console.WriteLine("****************btnAsync_Click Start 主线程id{0}*********************", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("btnAsync_Click{0}", i);
                Action act = () => this.TestThread(name);
                act.BeginInvoke(null, null);
            }
            watch.Stop();
            Console.WriteLine("****************btnAsync_Click End 主线程id{0}用时{1}毫秒*********************", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
        }
        #endregion

        #region btnThread_Click
        private void btnThread_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine();
            Console.WriteLine("****************btnThread_Click Start 主线程id{0}*********************", Thread.CurrentThread.ManagedThreadId);

            List<Thread> threadList = new List<Thread>();
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("btnThread_Click{0}", i);

                ThreadStart threadStart = () => this.TestThread(name);
                Thread thread = new Thread(threadStart);
                thread.IsBackground = true;
                thread.Start();

                //ThreadCallbackInvoke(() => this.TestThread(name),()=>Console.WriteLine("这里测试回调函数"));

                // threadList.Add(thread);

                //ParameterizedThreadStart rts = o => this.TestThread(o.ToString());
                //Thread thread = new Thread(rts);
                //thread.Start(name);
            }

            //foreach (var item in threadList)
            //{
            //    item.Join();
            //}

            watch.Stop();
            Console.WriteLine("****************btnThread_Click End 主线程id{0}用时{1}毫秒*********************", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
        }
        private void ThreadCallbackInvoke(ThreadStart threadStart, Action callback)
        {
            ThreadStart methodAll = new ThreadStart(new Action(() =>
            {
                threadStart.Invoke();
                callback.Invoke();
            }));
            Thread thread = new Thread(methodAll);
            thread.Start();
        }
        #endregion

        #region btnThreadPool_Click
        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine();
            Console.WriteLine("****************btnThreadPool_Click Start 主线程id{0}*********************", Thread.CurrentThread.ManagedThreadId);

            ManualResetEvent mre = new ManualResetEvent(false);
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("btnSync_Click_{0}", i);

                WaitCallback waitCallback = o =>
                {                    
                    this.TestThread(o.ToString());
                    mre.Set();
                };
                Console.WriteLine("我们来干点别的");
                Console.WriteLine("我们来干点别的");
                Console.WriteLine("我们来干点别的");
                Console.WriteLine("我们来干点别的");
                Console.WriteLine("我们来干点别的");
                mre.WaitOne();
                ThreadPool.QueueUserWorkItem(waitCallback, name);
            }

            //ManualResetEvent mre = new ManualResetEvent(false);
            //new Action(() =>
            //{
            //    Thread.Sleep(5000);
            //    Console.WriteLine("委托的异步调用");
            //    mre.Set();
            //}).BeginInvoke(null, null);

            watch.Stop();
            Console.WriteLine("****************btnThreadPool_Click End 主线程id{0}用时{1}毫秒*********************", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
        }
        #endregion

        #region btnTask_Click
        private void btnTask_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine();
            Console.WriteLine("****************btnTask_Click Start 主线程id{0}*********************", Thread.CurrentThread.ManagedThreadId);

            TaskFactory taskFactory = new TaskFactory();
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("btnTask_Click{0}", i);

                taskFactory.StartNew(() => this.TestThread(name));

                //Task task = new Task(() => this.TestThread(name));
                //task.Start();

                //Task.Run(() => this.TestThread(name));
            }

            watch.Stop();
            Console.WriteLine("****************btnTask_Click End 主线程id{0}用时{1}毫秒*********************", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
        }
        #endregion

        #region TestThread
        private void TestThread(string name)
        {
            Console.WriteLine("TestThread Start Name={0} Start 当前线程id={1},当前时间为{2}", name, Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            long sum = 0;
            for (int i = 0; i < 999999999; i++)
            {
                sum += i;
            }
            Console.WriteLine("TestThread End Name={0} End 当前线程id={1},当前时间为{2},计算结果:{3}", name, Thread.CurrentThread.ManagedThreadId, DateTime.Now, sum);
        }
        #endregion


    }
}
