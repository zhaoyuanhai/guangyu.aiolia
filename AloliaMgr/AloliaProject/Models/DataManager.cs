using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace AloliaProject.Models
{
    public class DataManager
    {
        JObject toJson(XElement element)
        {
            XmlDocument doc = new XmlDocument();
            var str = element.ToString();
            doc.LoadXml(str);
            string json = JsonConvert.SerializeXmlNode(doc);
            return JObject.Parse(json);
        }

        public JArray HomeIamges()
        {
            var xelment = DataDal.GetCollection("HomeImages");
            var jobj = toJson(xelment);
            return (JArray)jobj["HomeImages"]["Item"];
        }

        public JObject GetModule(string value)
        {
            var xelment = DataDal.GetCollection(value);
            return toJson(xelment);
        }

        public bool AddHomeImage(string path)
        {
            DataDal.Document.Root.Elements().First(e => e.Name == "HomeImages").Add(new XElement("Item", path));
            DataDal.Save();
            return true;
        }

        //添加第二部分内容
        public bool AddSecondModule(string path, string title)
        {
            DataDal.Document.Root.Elements().First(e => e.Name == "SecondModule")
                                     .Add(new XElement("Item", new XAttribute("Id", Guid.NewGuid()), new XAttribute("Title", title), path));
            //DataDal.Document.Root.Elements().First(e => e.Name == "SecondModule")..SetAttributeValue("Title",title);
            DataDal.Save();
            return true;

        }

        //修改第二部分内容
        public bool UpdateSecondModule(string strId, string title, string content)
        {
            var info = DataDal.Document.Root.Elements().First(e => e.Name == "SecondModule").Elements().FirstOrDefault(e => e.Attribute("Id").Value == strId);
            info.SetAttributeValue("Title", title);
            info.SetValue(content);
            DataDal.Save();
            return true;

        }

        public bool UpdateInfo(string CollectoinName, string title, string content)
        {
            var info = DataDal.Document.Root.Elements().First(e => e.Name == CollectoinName);
            info.SetAttributeValue("Title", title);
            info.SetValue(content);
            DataDal.Save();
            return true;
        }

        //添加第三部分
        public bool AddThreeModule(string title, string content)
        {
            DataDal.Document.Root.Elements().First(e => e.Name == "Message")
                               .Add(new XAttribute("Title", title), content);
            DataDal.Save();
            return true;

        }

        //修改第三部分
        public bool updateMessage(string CollectoinName, string msg)
        {
            var info = DataDal.Document.Root.Elements().First(e => e.Name == CollectoinName);
            info.SetValue(msg);
            DataDal.Save();
            return true;
        }
    }
}