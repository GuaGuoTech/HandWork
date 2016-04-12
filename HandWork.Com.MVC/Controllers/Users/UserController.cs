using HandWork.Com.Service.PhoneChecks;
using HandWork.Com.Provider.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandWork.Com.MVC.Controllers.Users
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            //User user = new User();
            //user.Confirm = 0;
            return View();
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
            return Json(PhoneCheckService.SendCheckCode(number)) ;   
        }

    }
}
