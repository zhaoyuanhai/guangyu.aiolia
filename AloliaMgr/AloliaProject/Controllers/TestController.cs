using AloliaProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace AloliaProject.Controllers
{
    public class TestController : Controller
    {
        DataManager DM = new DataManager();
        // GET: Test
        public ActionResult Upload()
        {
            return View();
        }
        /// <summary>
        /// 提交方法
        /// </summary>
        /// <param name="tm">模型数据</param>
        /// <param name="file">上传的文件对象，此处的参数名称要与View中的上传标签名称相同</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Upload(Test tm, HttpPostedFileBase file)
        {
            if (file == null)
            {
                return Content("没有文件！", "text/plain");
            }
            var vpath = $"/Upload/{Path.GetFileName(file.FileName)}";//相对路径
            var fileName = Request.MapPath("~" + vpath);
            try
            {
                file.SaveAs(fileName);
                //tm.AttachmentPath = fileName;//得到全部model信息，绝对路径
                tm.AttachmentPath = "../upload/" + Path.GetFileName(file.FileName);
                DM.AddHomeImage(vpath);
                //return Content("上传成功！", "text/plain");
                return View();
            }
            catch
            {
                return Content("上传异常 ！", "text/plain");
            }
        }

        public ActionResult tupianxianshi()
        {
            //var ImgList = DM.HomeIamges();
            //return View(ImgList);
            return View();
        }
        public ActionResult wenzi()
        {

            return View();
        }
        public ActionResult wenzitijiao(Wenzi wz)
        {
            var ss = DM.AddSecondModule(wz.Title, wz.Content);
            return View(ss);
        }
        public ActionResult wenzixianshi()
        {
            //string[] wenzi = DM.OneModule();
            //JObject[] model = wenzi.Select(e => JObject.Parse(e)).ToArray();
            //return View(model);
            return View();
        }
    }
}