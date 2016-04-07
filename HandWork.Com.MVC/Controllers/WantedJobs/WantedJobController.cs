﻿using HandWork.Com.Model.WantedJobs;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Repositorys;
using HandWork.Com.Service.WantedJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandWork.Com.MVC.Controllers.WantedJobs
{
    public class WantedJobController:Controller
    {
        private Repository<WantedJob> repository = new Repository<WantedJob>(new EntityContext());
        public ActionResult Index()
        {
            WantedJob wantedjob = new WantedJob();
            wantedjob.Id = 1;
            wantedjob.Location = "西山区110";
            wantedjob.money = "100";
            wantedjob.Name = "allen";
            wantedjob.Note = "无简介";
            wantedjob.PhoneNum = "110";
            wantedjob.Sex = 0;
            wantedjob.SfzAccount = "520";
            wantedjob.WeixinNum = "taixi666";
            WantedJobService.Insert(wantedjob);
            return View();

        }
    }
}