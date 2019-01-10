using Homework_3.Model;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace Homework_3.Common.Serialize
{
    public class XmlHelper
    {
        private static string CurrentXMLPath = ConfigurationManager.AppSettings["CurrentXMLPath"];
        /// <summary>
        /// 通过XmlSerializer序列化实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToXml<T>(T t) //where T : new()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(t.GetType());
            Stream stream = new MemoryStream();
            xmlSerializer.Serialize(stream, t);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            return text;

            //string fileName = Path.Combine(CurrentXMLPath, @"NovelLead.xml");//文件名称与路径
            //using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            //{
            //    XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
            //    xmlFormat.Serialize(fStream, t);
            //}
            //string[] lines = File.ReadAllLines(fileName);
            //return string.Join("", lines);
        }

        /// <summary>
        /// XML序列化器
        /// </summary>
        public static void XmlSerialize()
        {
            ////使用XML序列化对象
            //string fileName = Path.Combine(CurrentXMLPath, @"Student.xml");//文件名称与路径
            //using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            //{
            //    List<NovelLead> pList = DataFactory.BuildProgrammerList();
            //    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<NovelLead>));//创建XML序列化器，需要指定对象的类型
            //    xmlFormat.Serialize(fStream, pList);
            //}
        }
        /// <summary>
        /// XML反序列化
        /// </summary>
        public static T XmlDeSerialize<T>() 
            where T:new ()
        {
            T t = new T();
            string fileName = Path.Combine(CurrentXMLPath, @"NovelLead.xml");//文件名称与路径
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));//创建XML序列化器，需要指定对象的类型
                //使用XML反序列化对象
                fStream.Position = 0;//重置流位置
                t = (T)xmlFormat.Deserialize(fStream);
            }
            return t;
        }
    }
}
