using HandWork.Com.Model.Users;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Repositorys;
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
        private Repository<User> repository = new Repository<User>(new EntityContext());
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

    }
}
