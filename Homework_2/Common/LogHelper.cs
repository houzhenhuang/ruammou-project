using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Configuration;

namespace Common
{
    public class LogHelper
    {
        private static readonly string LogPath = ConfigurationManager.AppSettings["LogPath"];
        public static void WriteLog(string msg)
        {
            StreamWriter sw = null;
            try
            {
                string fileName = "log.txt";
                string totalPath = Path.Combine(LogPath, fileName);

                if (!Directory.Exists(LogPath))
                {
                    Directory.CreateDirectory(LogPath);
                }
                sw = File.AppendText(totalPath);
                sw.WriteLine(string.Format("{0}:{1}", DateTime.Now, msg));
                sw.WriteLine("*******************************************");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}
