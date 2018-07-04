using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AloliaProject.Models;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Web.Security;

namespace AloliaProject.Controllers
{
    [CustomAuthorize]
    public class ManagerController : Controller
    {
        DataApi api = new DataApi();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            JObject user = api.GetUser(userName);
            if (user != null && user["password"].ToString() == password)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    FormsAuthentication.FormsCookieName, DateTime.Now, DateTime.Now.AddDays(1), false, user.ToString());
                string authTicket = FormsAuthentication.Encrypt(ticket);

                HttpCookie cookie = new HttpCookie(ticket.Name, authTicket);
                cookie.HttpOnly = true;

                Response.Cookies.Add(cookie);

                return RedirectToAction("Index");
            }
            return View(JObject.FromObject(new { message = "用户名或密码错误" }));
        }

        // GET: Manager
        public ActionResult Index()
        {
            return Redirect("/html/index.html?defpath=/Manager/Default");
        }

        //首页,用户名,配置
        public ActionResult Default()
        {
            return View();
        }

        public ActionResult HomeImages()
        {
            JArray imgArray = api.GetHomeImageAll();
            return View(imgArray);
        }

        public ActionResult AddHomeImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHomeImage(HttpPostedFileWrapper file)
        {
            string fileName = DateTime.Now.ToString("yyyyMMddhhssmm");
            var vpath = Path.Combine("/img/", fileName + Path.GetExtension(file.FileName));
            string path = Server.MapPath("~" + vpath);
            file.SaveAs(path);

            JObject obj = new JObject();
            obj["path"] = vpath;
            string str = api.AddHomeImage(obj);
            return RedirectToAction("HomeImages");
        }

        public ActionResult EditHomeImage(string id)
        {
            var model = api.GetHomeImage(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditHomeImage(string id, HttpPostedFileWrapper file)
        {
            string fileName = DateTime.Now.ToString("yyyyMMddhhssmm");
            var vpath = Path.Combine("/img/", fileName + Path.GetExtension(file.FileName));
            string path = Server.MapPath("~" + vpath);
            file.SaveAs(path);

            JObject obj = new JObject();
            obj["path"] = vpath;
            obj["id"] = id;
            api.EditHomeImage(obj);
            return RedirectToAction("HomeImages");
        }

        public ActionResult DeleteHomeImage(string id)
        {
            api.DeleteHomeImage(id);
            return RedirectToAction("HomeImages");
        }

        public ActionResult OneModule()
        {
            JObject oneModule = api.GetOneModule();
            return View(oneModule);
        }

        public ActionResult EditOneModule(string type)
        {
            var data = api.GetOneModule();
            ViewBag.Type = type;
            return View(data[type]);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditOneModule(string type, string title, string content, string text)
        {
            JObject obj = new JObject();
            obj["title"] = title;
            obj["content"] = content;
            api.EditOneModule(type, obj);
            return RedirectToAction("OneModule");
        }

        public ActionResult SecondModule()
        {
            JArray secondModule = api.GetSecondModuleAll();
            return View(secondModule);
        }

        public ActionResult AddSecondModule()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddSecondModule(string id, string title, string content, string text)
        {
            JObject obj = new JObject();
            obj["title"] = title;
            obj["content"] = content;
            obj["text"] = text;
            api.AddSecondModule(obj);
            return RedirectToAction("SecondModule");
        }

        public ActionResult EditSecondModule(string id)
        {
            var model = api.GetSecondModule(id);
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditSecondModule(string id, string title, string content, string text)
        {
            JObject obj = new JObject();
            obj["id"] = id;
            obj["title"] = title;
            obj["content"] = content;
            obj["text"] = text;
            api.EditSecondModule(obj);
            return RedirectToAction("SecondModule");
        }

        public ActionResult DeleteSecondModule(string id)
        {
            api.DeleteSecondModule(id);
            return RedirectToAction("secondModule");
        }

        public ActionResult ThreeModule()
        {
            JArray threeModule = api.GetThreeModuleAll();
            return View(threeModule);
        }

        public ActionResult AddThreeModule()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddThreeModule(string url, HttpPostedFileWrapper file)
        {
            string fileName = DateTime.Now.ToString("yyyyMMddhhssmm");
            var vpath = Path.Combine("/img/", fileName + Path.GetExtension(file.FileName));
            string path = Server.MapPath("~" + vpath);
            file.SaveAs(path);

            var obj = new JObject();
            obj["url"] = url;
            obj["path"] = vpath;

            api.AddThreeModule(obj);
            return RedirectToAction("ThreeModule");
        }

        public ActionResult EditThreeModule(string id)
        {
            var model = api.GetThreeModule(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditThreeModule(string id, HttpPostedFileWrapper file, string url)
        {
            string fileName = DateTime.Now.ToString("yyyyMMddhhssmm");
            var vpath = Path.Combine("/img/", fileName + Path.GetExtension(file.FileName));
            string path = Server.MapPath("~" + vpath);
            file.SaveAs(path);

            JObject obj = new JObject();
            obj["id"] = id;
            obj["url"] = url;
            obj["path"] = vpath;

            api.EditThreeModule(obj);

            return RedirectToAction("ThreeModule");
        }

        public ActionResult DeleteThreeModule(string id)
        {
            api.DeleteThreeModule(id);
            return RedirectToAction("ThreeModule");
        }

        [ValidateInput(false)]
        public ActionResult EditDetail(string title = null, string content = null)
        {
            if (content != null && title != null)
            {
                var obj = new JObject();
                obj["content"] = content;
                obj["title"] = title;
                api.EditDetail(obj);
                return View(obj);
            }
            var model = api.GetDetail();
            return View(model);
        }
    }
}