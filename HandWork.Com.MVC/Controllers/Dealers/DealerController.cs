using HandWork.Com.Model.Dealers;
using HandWork.Com.Service.Dealers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandWork.Com.MVC.Controllers.Dealers
{
    public class DealerController:Controller
    {

        public ActionResult Index()
        {
            Dealer d = new Dealer();
            d.Comment = "test";
            d.IdClass = 1;
            d.Note = "yes";
            d.Password = "123";
            d.PhoneNum = "123";
            d.Sex =1;
            d.SfzAccount = "123";
            d.Star = 1;
            d.WeixinNum = "czr";

            DealerService.Insert(d);
            return View();
        }
    }
}