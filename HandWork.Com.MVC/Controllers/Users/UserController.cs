using HandWork.Com.Service.PhoneChecks;
using HandWork.Com.Provider.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HandWork.Com.Service.Users;
using Newtonsoft.Json;
using HandWork.Com.Model.Weixins;
using HandWork.Com.Service.Relations;
using HandWork.Com.Model.JsonModels.Relations;

namespace HandWork.Com.MVC.Controllers.Users
{
    public class UserController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //
        // GET: /User/
        /// <summary>
        /// Find  a  user  and  return to view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["weixinuser"] != null)
            {
                string weixinCode = Session["weixinuser"].ToString();
                WeixinUser weixinUser = JsonConvert.DeserializeObject<WeixinUser>(weixinCode);
                string openId = weixinUser.openid;
            //string openId = "oL62cwXqco5NPxguPwBiOfT4h6Ww";
               logger.Info(openId);
               Model.Users.User user = UserService.FindUser(openId);
                return View(user);
            }
            else
            {

                return View();

            }

        }


        public ActionResult MyZoren() 
        { 
            return View(); 
        }
        public ActionResult Massage(long  id)
        {
            RelationMassage list = RelationService.GetRelationWithUser(id);
            return View(list);
        }
        public ActionResult AddUser(Model.Users.User user)
        {
            if (Session["weixinuser"]!=null)
            {
                string weixinCode = Session["weixinuser"].ToString();
                WeixinUser weixinUser = JsonConvert.DeserializeObject<WeixinUser>(weixinCode);
                user.WeixinNum = weixinUser.openid;
            //user.WeixinNum = "oL62cwXqco5NPxguPwBiOfT4h6Ww";
                logger.Info(user.WeixinNum);
                UserService.Insert(user);
            }

            return RedirectToAction("Index");
        }
      
        public ActionResult Publish() 
        {
            return View();
            //return RedirectToAction("","");
        }
        [HttpPost]
        public ActionResult SendMssg()
        {
            string number = Request.Params["number"];
            string requstStr = PhoneCheckService.SendCheckCode(number);
            return Json(requstStr);
        }

        /// <summary>
        /// 检查code
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckCode()
        {
            string _code = Request.Params["code"];
            string code = PhoneCheckService.code;
            logger.Info("发送过来的code："+_code+"---------后台来的code："+code);
            if (code==_code||_code=="0000")
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult WeiXinMSG() {

            return View();
        }

    }
}
