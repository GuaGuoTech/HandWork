using HandWork.Com.Service.PhoneChecks;
using HandWork.Com.Provider.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HandWork.Com.Service.Users;

namespace HandWork.Com.MVC.Controllers.Users
{
    public class UserController : BaseControllers.BaseWeixinController
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //
        // GET: /User/
        public ActionResult Index()
        {
            if (hasSession)
            {
                UserService.Alert();
                return null;
            }
            else
            {
                return View();

            }
            ///
            //User user = new User();
            //user.Confirm = 0;
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Publish() 
        {

            return View();
        }
        [HttpPost]
        public ActionResult SendMssg()
        {
            string number = Request.Params["number"];
            string requstStr = PhoneCheckService.SendCheckCode(number);
            return Json(requstStr);
        }

        /// <summary>
        /// 检查code
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckCode()
        {
            string _code = Request.Params["code"];
            string code = PhoneCheckService.code;
            logger.Info("发送过来的code："+_code+"---------后台来的code："+code);
            if (code==_code)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

    }
}
