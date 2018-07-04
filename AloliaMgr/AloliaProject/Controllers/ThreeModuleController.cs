using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AloliaProject.Models;

namespace AloliaProject.Controllers
{
    public class ThreeModuleController : ApiController
    {
        DataManager DM = new DataManager();
        DataApi api = new DataApi();
        public JArray Get()
        {
            return api.GetThreeModuleAll();
            //var data = DM.GetModule("ThreeModule")["ThreeModule"]["Item"];
            //if (data is JArray)
            //    return data as JArray;
            //else
            //    return new JArray(new object[] { data });
        }
    }
}
