using AloliaProject.Models;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace AloliaProject.Controllers
{
    public class SecondModuleController: ApiController
    {
        DataManager DM = new DataManager();
        DataApi api = new DataApi();
        public JArray Get()
        {
            //return (JObject)DM.GetModule("SecondModule")["SecondModule"];
            return api.GetSecondModuleAll();
        }
    }
}