using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandWork.Com.MVC.Controllers.BaseControllers
{
    public class BaseWeixinController : Controller
    {
        //
        // GET: /BaseWeixin/
        protected bool hasSession = true;
        //暂时没有用
        public BaseWeixinController()
        {

            if (Session["weixinUser"] == null)
            {
                hasSession = false;
            }
        

        }


    }
}
