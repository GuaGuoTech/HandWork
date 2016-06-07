using HandWork.Com.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuaGuoTech.Com.Manager.MVC.Controllers.Homes
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            List<User> userList = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                User user = new User();
                user.Id = i+1;
                user.Adress = i+"asdfasd";
                user.Name = i+"地方萨芬";
                userList.Add(user);
            }

            return View(userList);
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}
