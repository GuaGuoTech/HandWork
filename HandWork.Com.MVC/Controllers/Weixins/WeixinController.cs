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

        public ActionResult Index()
        {
            return View();
        }

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

        public void GetWeixinUser()
        { 
        
        
        
        }

        public void GetBaseToken()
        {
            WeixinService.GetBaseToken(500);        
        }
        public void CreateWeixinMenu()
        {
            WeixinService.CreateWenxinMenu();
        
        
        }
    }
}
