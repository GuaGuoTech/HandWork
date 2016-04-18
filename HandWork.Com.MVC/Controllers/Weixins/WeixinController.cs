using HandWork.Com.Service.Weixins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandWork.Com.MVC.Controllers.Weixins
{
    public class WeixinController : Controller
    {
        //
        // GET: /Weixin/
        /// <summary>
        ///log4net 日志
        /// </summary>
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            string code = Request.Params["code"].ToString();
            if (code != null)
            {

                string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid=wxd21f90079ecb0969&secret=338345d734124088ce5579a6a4514318&code={0}&grant_type=authorization_code", code);

                string responseText = WeixinService.HttpsGet(url);
                ///日志记录
                logger.Info(responseText);


                return View(WeixinService.GetWeixinUser(responseText));

            }
            return Json("erro");

        }

        /// <summary>
        /// 微信配置对接
        /// </summary>
        /// <returns></returns>
        public string CheckDevelopment()
        {
            string token = "guaguokeji";
            string signature = Request.Params["signature"];
            string timestamp = Request.Params["timestamp"];
            string nonce = Request.Params["nonce"];
            string echostr = Request.Params["echostr"];
            string[] arr = { token, timestamp, nonce };
            Array.Sort(arr);

            string sunStr = arr[0].ToString().Trim() + arr[1].ToString().Trim() + arr[2].ToString().Trim();

            if (WeixinService.GetPwd(sunStr).ToLower() == signature)
            {
                return echostr;
            }

            return null;
        }

        /// <summary>
        /// 微信返回的数据
        /// </summary>
        public ActionResult GetWeixinUser()
        {
            
                
   
            return null;
        }

        public void GetBaseToken()
        {
            WeixinService.GetBaseToken();
        }
        /// <summary>
        /// 微信自定义菜单，目前只能在程序中去改
        /// </summary>
        /// <returns></returns>
        public string CreateWeixinMenu()
        {
            return WeixinService.CreateWenxinMenu();
        }
    }
}
