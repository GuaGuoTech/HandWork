
using HandWork.Com.Model.Users;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Repositorys;
using HandWork.Com.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandWork.Com.MVC.Controllers.Users
{
    public class UserController : Controller
    {
        private Repository<User> repository = new Repository<User>(new EntityContext());
        
        public ActionResult Index()
        {
            User d = new User();
            d.Comment = "test";
            //d.IdClass = 1;
            d.Note = "yes";
            d.Password = "123";
            d.PhoneNum = "123";
            d.Sex =1;
            d.SfzAccount = "123";
            d.Star = 1;
            d.WeixinNum = "czr";

            UserService.Insert(d);
            return View();
        }
    }
}