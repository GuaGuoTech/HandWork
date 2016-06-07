using HandWork.Com.Model.ViewModels.JobLists;
using HandWork.Com.Model.Weixins;
using HandWork.Com.MVC.Controllers.BaseControllers;
using HandWork.Com.Service.PhoneChecks;
using HandWork.Com.Service.Recruits;
using HandWork.Com.Service.Weixins;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HandWork.Com.MVC.Controllers.Home
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            if (Session["weixinuser"] != null)
            {
           
        

                    return View();

 
 
            }

            string code = Request.Params["code"];

            if (code != null)
            {
                logger.Info(code);
                string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid=wx5816d70da3d66669&secret=e5864723af41144650a9e46062107f38&code={0}&grant_type=authorization_code", code);
                logger.Info(url);

                string responseText = WeixinService.HttpsGet(url);
                ///日志记录
                logger.Info(responseText);
                WeixinUser obj = WeixinService.GetWeixinUser(responseText);
                string userJsonStr = JsonConvert.SerializeObject(obj);

                ///session
                Session["weixinUser"] = userJsonStr;

                ///执行父类中的方法
                ////设置Cookies
                //Response.Cookies["weixinUser"].Value = HttpUtility.UrlEncode(userJsonStr,Encoding.UTF8);
                //logger.Info("写入的cookie:"+Response.Cookies["weixinUser"].Value);

                ////设置Cookies有效期
                //Response.Cookies["weixinUser"].Expires = DateTime.MaxValue;


                return View();

            }
            return View();
        }


        [HttpPost]
        public ActionResult GetJobList() 
        {
            //pageNum
            int  pageNum  = Convert.ToInt32(Request.Params["pageNum"]);
            //Max list value  in  a page
            int maxNum = 10;

            int type = Convert.ToInt32(Request.Params["type"]);

            List<JobList> jobList = RecruitService.GetJobList(pageNum,maxNum,type);

            return Json(jobList);
        }


    }
}
