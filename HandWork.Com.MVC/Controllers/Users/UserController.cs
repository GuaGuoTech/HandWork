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
          return Json( PhoneCheckService.SendCheckCode(number));
        }

    }
}
