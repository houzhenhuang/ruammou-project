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

namespace MyAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void DoSometingDelegate(string name);
        private void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine("*******************btnAsync_Click Start {0}*****************************", Thread.CurrentThread.ManagedThreadId);

            DoSometingDelegate method = new DoSometingDelegate(DoSometingLong);
            //method.Invoke("btnAsync_Click1");
            //method.Invoke("btnAsync_Click2");

            IAsyncResult asyncResult = null;

            asyncResult = method.BeginInvoke("btnAsync_Click3", p =>
            {
                Console.WriteLine(p.Equals(asyncResult));

                Console.WriteLine(p.AsyncState);
                Console.WriteLine("这里是回调函数{0}", Thread.CurrentThread.ManagedThreadId);
            }, "状态参数");
            //int i = 0;
            //while (!asyncResult.IsCompleted)
            //{
            //    Console.WriteLine("正在计算，{0}%", 10 * i++);
            //    Thread.Sleep(200);
            //}

            asyncResult.AsyncWaitHandle.WaitOne();
            asyncResult.AsyncWaitHandle.WaitOne(-1);


            Console.WriteLine("*******************btnAsync_Click End {0}*****************************", Thread.CurrentThread.ManagedThreadId);
        }

        private void DoSometingLong(string name)
        {
            Console.WriteLine("*******************DoSometingLong Start {0}*****************************", Thread.CurrentThread.ManagedThreadId);
            int iResult = 0;
            for (int i = 0; i < 10000000; i++)
            {
                iResult += 1;
            }
            Thread.Sleep(2000);
            Console.WriteLine("*******************DoSometingLong End {0}*****************************", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
