using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json.Linq;

namespace AloliaProject.Models
{
    public class DataApi
    {
        static object _obj = new object();

        static string path = "~/data/data.json";

        static JObject _data
        {
            get
            {
                lock (_obj)
                {
                    var json = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(path));
                    return JObject.Parse(json);
                }
            }
        }

        public void SaveData(JObject obj)
        {
            var json = obj.ToString();
            lock (this)
            {
                File.WriteAllText(HttpContext.Current.Server.MapPath(path), json);
            }
        }

        public string AddHomeImage(JObject homeImage)
        {
            var data = _data;
            string id = Guid.NewGuid().ToString();
            homeImage["id"] = id;
            ((JArray)data["homeImage"]).Add(homeImage);
            SaveData(data);
            return id;
        }

        public JArray GetHomeImageAll()
        {
            return _data["homeImage"] as JArray;
        }

        public JObject GetHomeImage(string id)
        {
            var data = _data;
            return data["homeImage"].FirstOrDefault(e => e["id"].ToString() == id) as JObject;
        }

        public bool DeleteHomeImage(string id)
        {
            var data = _data;
            var image = data["homeImage"].FirstOrDefault(e => e["id"].ToString() == id);
            if (image != null)
            {
                image.Remove();
                SaveData(data);
                return true;
            }
            return false;
        }

        public bool EditHomeImage(JObject homeImage)
        {
            var data = _data;
            var hi = data["homeImage"].FirstOrDefault(e => e["id"].ToString() == homeImage["id"].ToString());
            if (hi != null)
            {
                hi.Replace(homeImage);
                SaveData(data);
                return true;
            }
            return false;
        }

        public JObject GetModule()
        {
            var data = _data;
            JObject obj = new JObject();
            obj["oneModule"] = data["oneModule"];
            obj["secondModule"] = data["secondModule"];
            obj["threeModule"] = data["threeModule"];
            return obj;
        }

        public JToken GetModule(string type)
        {
            return _data[type];
        }

        public JObject GetOneModule()
        {
            return _data["oneModule"] as JObject;
        }

        public bool EditOneModule(string type, JObject obj)
        {
            var data = _data;
            data["oneModule"][type].Replace(obj);
            SaveData(data);
            return true;
        }

        public JArray GetSecondModuleAll()
        {
            var models = _data["secondModule"] as JArray;

            foreach (var model in models)
            {
                if (model["text"] == null)
                    model["text"] = string.Empty;
            }

            return models;
        }

        public JObject GetSecondModule(string id)
        {
            var model = _data["secondModule"].FirstOrDefault(e => e["id"].ToString() == id) as JObject;
            if (model["text"] == null)
                model["text"] = string.Empty;
            return model;
        }

        public string AddSecondModule(JObject obj)
        {
            var data = _data;
            string id = Guid.NewGuid().ToString();
            obj["id"] = id;
            ((JArray)data["secondModule"]).Add(obj);
            SaveData(data);
            return id;
        }

        public bool EditSecondModule(JObject obj)
        {
            var data = _data;
            var item = data["secondModule"].FirstOrDefault(e => e["id"].ToString() == obj["id"].ToString());
            if (item != null)
            {
                item.Replace(obj);
                SaveData(data);
                return true;
            }
            return false;
        }

        public bool DeleteSecondModule(string id)
        {
            var data = _data;
            var item = data["secondModule"].FirstOrDefault(e => e["id"].ToString() == id);
            if (item != null)
            {
                item.Remove();
                SaveData(data);
                return true;
            }
            return false;
        }

        public JArray GetThreeModuleAll()
        {
            return _data["threeModule"] as JArray;
        }

        public JObject GetThreeModule(string id)
        {
            return _data["threeModule"].FirstOrDefault(e => e["id"].ToString() == id) as JObject;
        }

        public string AddThreeModule(JObject obj)
        {
            var data = _data;
            var id = Guid.NewGuid().ToString();
            obj["id"] = id;
            ((JArray)data["threeModule"]).Add(obj);
            SaveData(data);
            return id;
        }

        public bool EditThreeModule(JObject obj)
        {
            var data = _data;
            var item = data["threeModule"].FirstOrDefault(e => e["id"].ToString() == obj["id"].ToString());
            if (item != null)
            {
                item.Replace(obj);
                SaveData(data);
                return true;
            }
            return false;
        }

        public bool DeleteThreeModule(string id)
        {
            var data = _data;
            var item = data["threeModule"].FirstOrDefault(e => e["id"].ToString() == id);
            if (item != null)
            {
                item.Remove();
                SaveData(data);
                return false;
            }
            return false;
        }

        public JObject GetDetail()
        {
            return (JObject)_data["detail"];
        }

        public bool EditDetail(JObject obj)
        {
            var data = _data;
            data["detail"].Replace(obj);
            SaveData(data);
            return true;
        }

        public JObject GetUser(string userName)
        {
            return _data["user"].FirstOrDefault(u => u["userName"].ToString() == userName) as JObject;
        }
    }
}