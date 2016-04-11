using HandWork.Com.Service.Weixins;
using System;
using System.Collections.Generic;
using System.Linq;
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
            string code = Request.Params["code"];
            if (code != null)
            {

                string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid=wxd21f90079ecb0969&secret=338345d734124088ce5579a6a4514318&code={0}&grant_type=authorization_code", code);

                string responseText = WeixinService.HttpsGet(url);
                ///日志记录
                logger.Info(responseText);


                return View(WeixinService.GetWeixinUser(responseText));

            }
            return View();
        }

    }
}
