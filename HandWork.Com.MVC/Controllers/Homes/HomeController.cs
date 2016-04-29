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

        [ValidateInput(false)]
        public ActionResult Index()
        {
            if (Session["weixinuser"] != null)
            {
                try
                {
        

                    return View();

                }
                catch (Exception e)
                {
                    logger.Error(e);
                    throw;
                }
 
            }

            string code = Request.Params["code"];

            ///没有session的情况去获取用户信息
            if (code != null)
            {

                string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid=wxd21f90079ecb0969&secret=338345d734124088ce5579a6a4514318&code={0}&grant_type=authorization_code", code);

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
