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
        public ActionResult AddPublish(Recruit recruit)
        {
            return Json(true);

        }
        
        public ActionResult AddRecruit()
        {
            //if (RecruitService.CheckConfirm(id) == 0)
            //{
            //    //Response.("");
            //    RedirectToAction("Index", "Detail");
            //}


            //recruit.Location=Request.Form["Location"];
            //recruit.Classify=Request.Form["小时工"];
            //recruit.FinalMoney=Request.Form["Momey".ToString()];
            var  a = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Recruit recruit = new Recruit();
                    recruit.Location = "GuaGuoTech";
                    //recruit.Location=@Form["Location"];
                    //Response.Write(form["WorkHour"]);
                    recruit.Money = 100;
                    recruit.PayType = i;
                    recruit.WeixinUserId = i+1;
                    recruit.Note = "天天情人节之出租男朋友 陪吃陪逛陪玩";
                    recruit.Percent = 1.00;
                    recruit.PhoneNum = "110";
                    recruit.Sex = 0;
                    recruit.Title = "我要招"+a+"万个";
                    a++;
                    recruit.Words = "打架";

                    recruit.SfzAccount = "3535353535";
                    recruit.WeixinNum = "520582";
                    RecruitService.Insert(recruit);

                }

            }
          
            

            //return View();
            return RedirectToAction("Index","Detail");

        }
        public ActionResult Index()
        {

            return View();
        }

    }
}