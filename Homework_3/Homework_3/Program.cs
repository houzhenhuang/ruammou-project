using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Homework_3.Common.Serialize;
using Homework_3.Model;
using System.Speech.Synthesis;

namespace Homework_3
{
    class Program
    {
        private static object obj = new object();
        private static bool flag = true;
        static CancellationTokenSource cts = new CancellationTokenSource();
        static void Main(string[] args)
        {
            try
            {
                #region 可配置方式
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();

                    List<NovelLead> nList = XmlHelper.XmlDeSerialize<List<NovelLead>>();//获取人物信息
                    TaskFactory taskFactory = new TaskFactory();
                    List<Task> taskList = new List<Task>();
                    foreach (NovelLead item in nList)
                    {
                        taskList.Add(taskFactory.StartNew(s =>
                        {
                            GetStoryContent(item);
                        }, item.Name, cts.Token));
                    }
                    MonitorThread(taskFactory);
                    WaitThread(watch, taskFactory, taskList);    
                }
                #endregion
                #region 普通方式
                {
                    //Stopwatch watch = new Stopwatch();
                    //watch.Start();
                    //Console.WriteLine("******************天龙八部故事拉开序幕*************************");
                    //List<Task> taskList = new List<Task>();
                    //TaskFactory taskFactory = new TaskFactory();
                    //Task taskQiaofeng = taskFactory.StartNew(s => Qiaofeng(), "乔峰");
                    //taskList.Add(taskQiaofeng);
                    //Task taskXuzu = taskFactory.StartNew(s => Xuzu(), "虚竹");
                    //taskList.Add(taskXuzu);
                    //Task taskDuanyu = taskFactory.StartNew(s => Duanyu(), "段誉");
                    //taskList.Add(taskDuanyu);
                    //taskFactory.ContinueWhenAny(taskList.ToArray(), t => Console.WriteLine("{0}已经做好准备啦。。。。", t.AsyncState));//执行的线程等待任何一个任务完成

                    //taskFactory.ContinueWhenAll(taskList.ToArray(), t => Console.WriteLine("中原群雄大战辽兵，忠义两难一死谢天"));//执行的线程等待全部任务完成

                    //Task.WaitAll(taskList.ToArray());
                    //watch.Stop();
                    //Console.WriteLine("******************天龙八部故事完美结束，本故事耗时{0}毫秒*************************", watch.ElapsedMilliseconds);
                }
                #endregion
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 等待线程
        /// </summary>
        /// <param name="watch"></param>
        /// <param name="taskFactory"></param>
        /// <param name="taskList"></param>
        private static void WaitThread(Stopwatch watch, TaskFactory taskFactory, List<Task> taskList)
        {
            taskFactory.ContinueWhenAny(taskList.ToArray(), t =>//当一个线程数组中任意一个线程执行完成后执行以下内容
            {
                if (!cts.IsCancellationRequested)
                {
                    Console.ForegroundColor = System.ConsoleColor.Gray;
                    CommonLog.WriteLogText(string.Format("{0}已经做好准备啦。。。。", t.AsyncState));
                }
            });
            taskFactory.ContinueWhenAll(taskList.ToArray(), t =>//当一个线程数组中全部线程执行完成后执行以下内容
            {
                if (!cts.IsCancellationRequested)
                    CommonLog.WriteLogText("中原群雄大战辽兵，忠义两难一死谢天");
                else
                    CommonLog.WriteLogText("天降雷霆灭世，天龙八部的故事就此结束....");
                watch.Stop();
                CommonLog.WriteLogText(string.Format("******************天龙八部故事完美结束，本故事耗时{0}毫秒*************************", watch.ElapsedMilliseconds));
            });
        }
        /// <summary>
        /// 监控线程
        /// </summary>
        /// <param name="taskFactory"></param>
        private static void MonitorThread(TaskFactory taskFactory)
        {
            taskFactory.StartNew(() =>//监控线程
            {
                while (true)
                {
                    Random random = new Random();
                    int n = random.Next(1, 10000);
                    if (n == DateTime.Now.Year)
                    {
                        cts.Cancel();
                        break;
                    }
                }
            });
        }
        /// <summary>
        /// 获取故事情节
        /// </summary>
        /// <param name="item"></param>
        private static void GetStoryContent(NovelLead item)
        {
            try//目的是为了，不允许线程内部异常
            {
                string[] storyArray = item.Story.Split('|');
                for (int i = 0; i < storyArray.Length; i++)
                {
                    if (flag)//表示是第一个事件
                    {
                        lock (obj)
                        {
                            WriteStory(item, storyArray[i]);
                            if (flag)
                            {
                                Console.ForegroundColor = System.ConsoleColor.Gray;
                                CommonLog.WriteLogText("天龙八部就此拉开序幕。。。。");
                                flag = false;
                            }
                        }
                    }
                    else
                    {
                        WriteStory(item, storyArray[i]);
                    }
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                CommonLog.WriteLogText(ex.Message);
            }
        }
        /// <summary>
        /// 输出故事情节
        /// </summary>
        /// <param name="item"></param>
        /// <param name="story"></param>
        private static void WriteStory(NovelLead item, string story)
        {
            if (!cts.IsCancellationRequested)
            {
                Console.ForegroundColor = (System.ConsoleColor)item.FontColor;//设置字体颜色
                CommonLog.WriteLogText(story);
            }
        }













        public static void Qiaofeng()
        {
            lock (obj)
            {
                Console.WriteLine("乔峰成为丐帮帮主");
                if (flag)
                {
                    Console.WriteLine("天龙八部就此拉开序幕。。。。");
                    flag = false;
                }
            }
            Thread.Sleep(1000);
            Console.WriteLine("乔峰发现自己是个契丹人");
            Thread.Sleep(1000);
            Console.WriteLine("乔峰发现自己是契丹人之后成为了南院大王");
            Thread.Sleep(1000);
            Console.WriteLine("乔峰挂印离开");
            Thread.Sleep(1000);
        }
        public static void Xuzu()
        {
            lock (obj)
            {
                Console.WriteLine("虚竹最开始是少林寺的一个小和尚");
                if (flag)
                {
                    Console.WriteLine("天龙八部就此拉开序幕。。。。");
                    flag = false;
                }
            }

            Thread.Sleep(2000);
            Console.WriteLine("虚竹下成为了逍遥派掌门");
            Thread.Sleep(2000);
            Console.WriteLine("虚竹成为了灵鹫宫宫主");
            Thread.Sleep(2000);
            Console.WriteLine("虚竹成为了西夏驸马");
            Thread.Sleep(2000);
        }
        public static void Duanyu()
        {
            lock (obj)
            {
                Console.WriteLine("段誉遇到了钟灵儿");
                if (flag)
                {
                    Console.WriteLine("天龙八部就此拉开序幕。。。。");
                    flag = false;
                }
            }
            Thread.Sleep(600);
            Console.WriteLine("段誉遇到了木婉清");
            Thread.Sleep(600);
            Console.WriteLine("段誉遇到了王语嫣");
            Thread.Sleep(600);
            Console.WriteLine("段誉成为了大理国国王");
            Thread.Sleep(600);
        }

    }
}
