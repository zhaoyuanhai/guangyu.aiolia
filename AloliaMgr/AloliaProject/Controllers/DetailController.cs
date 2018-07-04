using AloliaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace AloliaProject.Controllers
{
    public class DetailController : ApiController
    {
        DataApi api = new DataApi();

        public JObject Get()
        {
            return api.GetDetail();
        }
    }
}