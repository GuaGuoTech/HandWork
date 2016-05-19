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
    public class DetailController : Controller
    {
        public ActionResult Index(long  id)
        {
            //if (RecruitService.CheckConfirm(id) == 0)
            //{
            //    //Response.("");
            //    Redirect("~/Users/User/Index.cshtml");
            //}

            if (id!=0)
            {
              Recruit  recruit =   RecruitService.GetEntity(id);
              if (recruit!=null)
              {
                  return View(recruit);
              }

            }
           
                return View();
            

        }


        [HttpPost]
        public ActionResult CloseThisRecruit(long  id)
        {
            if (id != 0)
            {
                Recruit recruit = RecruitService.GetEntity(id);
                recruit.state = 0;
                RecruitService.Update(recruit);
       
            }

            return Json("1");

        }

        [HttpPost]
        public ActionResult OpenThisRecruit(long  id)
        {

            if (id != 0)
            {
                Recruit recruit = RecruitService.GetEntity(id);
                recruit.state = 1;
                RecruitService.Update(recruit);

            }
            return Json("1");
        }
    }

}