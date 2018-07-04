using AloliaProject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AloliaProject.Controllers
{
    public class OneModuleController : ApiController
    {
        DataManager DM = new DataManager();
        DataApi api = new DataApi();
        public JObject Get()
        {
            //return (JObject)DM.GetModule("OneModule")["OneModule"];
            return api.GetOneModule();
        }
    }
}
