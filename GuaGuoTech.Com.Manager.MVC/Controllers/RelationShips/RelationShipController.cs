using HandWork.Com.Model.JsonModels.Relations;
using HandWork.Com.Service.Weixins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace GuaGuoTech.Com.Manager.MVC.Controllers.RelationShips
{
    public class RelationShipController : Controller
    {
        //
        // GET: /RelationShip/

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult GetRelationShipWithUser()
        {


            List<RelationAndUser> relationAndUser = WeixinService.GetRelationShipWithUser();


            return null;
        }

    }
}
