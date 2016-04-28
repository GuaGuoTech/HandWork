using HandWork.Com.Model.Recruits;
using HandWork.Com.Model.Weixins;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Repositorys;
using HandWork.Com.Service.Recruits;
using Newtonsoft.Json;
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
        public ActionResult AddPublish(Recruit recruit)
        {
            return Json(true);

        }
        
        [HttpPost]
        public ActionResult AddRecruit(Recruit recruit)
        {

            if (Session["weixinUser"]!=null)
            {

                WeixinUser weixinUser = new WeixinUser();
                weixinUser = JsonConvert.DeserializeObject<WeixinUser>(Session["weixinUser"].ToString());
                recruit.WeixinUserId = weixinUser.id;
                Recruit addRecruit = RecruitService.Insert(recruit);
                return Json(addRecruit);

            }

            return Json("");

        }
        /// <summary>
        /// 这里缺逻辑判断
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return View();
        }

    }
}