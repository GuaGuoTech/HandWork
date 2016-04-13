using HandWork.Com.Model.Recruits;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Repositorys;
using HandWork.Com.Service.Recruits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandWork.Com.MVC.Controllers.Recruits
{
    public class RecruitController:Controller
    {
        Repository<Recruit> repo = new Repository<Recruit>(new EntityContext());
        public ActionResult Index()
        {
            if (RecruitService.CheckConfirm(id) == 0)
            {
                //Response.("");
                Redirect("~/Users/User/Index.cshtml");
            }
            return View();

        }

        public long id { get; set; }
    }
}