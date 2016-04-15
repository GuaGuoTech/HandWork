using HandWork.Com.Model.Recruits;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace HandWork.Com.MVC.Controllers
{
    public class WatchController: Controller
    {
        public ActionResult Index()
        {
            Repository<Recruit> re = new Repository<Recruit>(new EntityContext());
            Recruit recruit = re.GetEntity(007);
           
            //Recruit re2 = re.GetAllEntity();
            var xinxi = JsonConvert.SerializeObject(recruit);
            return View();

        }

    }
} 