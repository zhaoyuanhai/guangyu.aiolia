using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Web;

namespace AloliaProject.Models
{
    //读取文件 写入文件
    public static class DataDal
    {
        //文件路径
        static string Path { get { return "~/data/data.xml"; } }

        static object olock;

        static DataDal()
        {
            olock = new object();
        }

        public static XDocument Document
        {
            get
            {
                XDocument document;
                lock (olock)
                {
                    var fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath(Path), FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    document = XDocument.Load(fs);
                    fs.Close();
                }
                return document;
            }
        }

        //读取数据
        public static XElement GetCollection(string collectionName)
        {
            var element = Document.Root.Elements().FirstOrDefault(e => e.Name == collectionName);

            return element;
        }
        public static void Save()
        {
            Document.Save(Path);
        }
    }
}