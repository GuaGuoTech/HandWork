using HandWork.Com.Model.Weixins;
using Newtonsoft.Json;
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
        protected bool hasSession = false;

        protected  string  weixinUserJson = "" ;

        protected WeixinUser weixinUserObj = new WeixinUser();
        //暂时没有用
         protected  void  CreatWeixinObj()
          {

            if (Session != null)
            {
                if (Session["weixinuser"]!=null)
                {
                    hasSession = true;
                    weixinUserJson = Session["weixinUser"].ToString();
                    weixinUserObj = JsonConvert.DeserializeObject<WeixinUser>(weixinUserJson);
                }
   
            }
        

        }


    }
}
