using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace IOSerialize.IO
{
    /// <summary>
    /// 文件夹  文件管理
    /// </summary>
    public class MyIO
    {
        /// <summary>
        /// 配置绝对路径
        /// </summary>
        private static string LogPath = ConfigurationManager.AppSettings["LogPath"];
        private static string LogMovePath = ConfigurationManager.AppSettings["LogMovePath"];
        /// <summary>
        /// 获取当前程序路径
        /// </summary>
        private static string LogPath2 = AppDomain.CurrentDomain.BaseDirectory;


        public static void Show()
        {
            {//check
                if (!Directory.Exists(LogPath))//检测文件夹是否存在
                {

                }
                DirectoryInfo directory = new DirectoryInfo(LogPath);//不存在不报错
                Console.WriteLine("{0} {1} {2}", directory.FullName, directory.CreationTime, directory.LastWriteTime);

                if (!File.Exists(Path.Combine(LogPath, "info.txt")))//检测文件是否存在
                {

                }
                FileInfo fileInfo = new FileInfo(Path.Combine(LogPath, "info.txt"));
                Console.WriteLine("{0} {1} {2}", fileInfo.FullName, fileInfo.CreationTime, fileInfo.LastWriteTime);
            }
            { //Directory
                if (!Directory.Exists(LogPath))
                {
                    DirectoryInfo directoryInfo = Directory.CreateDirectory(LogPath);//一次性创建全部的子路径
                    Directory.Move(LogPath, LogMovePath);//移动  原文件夹就不存在了
                    Directory.Delete(LogMovePath);
                }
            }

            { //File
                string fileName = Path.Combine(LogPath, "log.txt");
                string fileNameCopy = Path.Combine(LogPath, "logCopy.txt");
                string fileNameMove = Path.Combine(LogPath, "logMove.txt");

                bool isExists = File.Exists(fileName);
                if (!isExists)
                {
                    Directory.CreateDirectory(LogPath);
                    using (FileStream fileStream = File.Create(fileName))//打开文件流，创建并写入
                    {
                        string name = "6172468134687322";
                        byte[] bytes = Encoding.Default.GetBytes(name);
                        fileStream.Write(bytes, 0, bytes.Length);
                        fileStream.Flush();
                    }
                    using (FileStream fileStream = File.Create(fileName))//打开文件流，创建并写入
                    {
                        StreamWriter sw = new StreamWriter(fileStream);
                        sw.WriteLine("6172468134687322");
                        sw.Flush();
                    }
                    using (StreamWriter sw = File.AppendText(fileName))//流写入器（创建/打开文件并写入）
                    {
                        sw.WriteLine("今天天气不错！");
                        sw.Flush();
                    }
                    using (StreamWriter sw = File.AppendText(fileName))//流写入器（创建/打开文件并写入）
                    {
                        string name = "今天天气不错，一起吃了顿饭!";
                        byte[] bytes = Encoding.UTF8.GetBytes(name);
                        sw.BaseStream.Write(bytes, 0, bytes.Length);
                        sw.Flush();
                    }

                    foreach (string item in File.ReadAllLines(fileName))
                    {
                        Console.WriteLine(item);
                    }

                    string sResult = File.ReadAllText(fileName);
                    byte[] byteContent = File.ReadAllBytes(fileName);
                    string sResultByte = System.Text.Encoding.UTF8.GetString(byteContent);

                    using (FileStream stream = File.OpenRead(fileName))
                    {
                        int lenth = 5;
                        int result = 0;
                        do
                        {
                            byte[] bytes = new byte[lenth]; //1024byte==1kb
                            result = stream.Read(bytes, 0, lenth);
                            for (int i = 0; i < result; i++)
                            {
                                Console.WriteLine(bytes[i].ToString());
                            }
                        } while (lenth == result);
                    }
                }

            }

        }


    }
}
