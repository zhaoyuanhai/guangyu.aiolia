using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AloliaProject.Models;
using Newtonsoft.Json.Linq;

namespace AloliaProject.Controllers
{
    public class HomeImageController : ApiController
    {
        DataManager DM = new DataManager();
        DataApi api = new DataApi();
        public JArray Get()
        {
            //return DM.HomeIamges();
            return api.GetHomeImageAll();
        }
    }
}
