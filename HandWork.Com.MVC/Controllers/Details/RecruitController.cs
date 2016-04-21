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
        public ActionResult AddRecruit()
        {
            //if (RecruitService.CheckConfirm(id) == 0)
            //{
            //    //Response.("");
            //    RedirectToAction("Index", "Detail");
            //}


            Recruit recruit = new Recruit();
            recruit.Id = 0;
            recruit.Location = "GuaGuoTech";
            recruit.Money = 100;
            recruit.Note = "天天情人节之出租男朋友 陪吃陪逛陪玩";
            recruit.Percent = 1.00;
            recruit.PhoneNum = "110";
            recruit.Sex = 0;
            recruit.SfzAccount = "3535353535";
            recruit.WeixinNum = "520582";
            RecruitService.Insert(recruit);
            //return View();
            return RedirectToAction("Index","Detail");

        }
        public ActionResult Index()
        {

            return View();
        }

        public long id { get; set; }
    }
}