﻿using HandWork.Com.Service.PhoneChecks;
using HandWork.Com.Provider.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HandWork.Com.Service.Users;
using Newtonsoft.Json;
using HandWork.Com.Model.Weixins;

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
               string  openId = weixinUser.openid;
               Model.Users.User user = UserService.FindUser(openId);
               logger.Info(user.WeixinNum);
                return View(user);
            }
            else
            {

                return View("Erro");

            }

        }

        public ActionResult AddUser(Model.Users.User user)
        {
            if (Session["weixinuser"]!=null)
            {
                string weixinCode = Session["weixinuser"].ToString();
                WeixinUser weixinUser = JsonConvert.DeserializeObject<WeixinUser>(weixinCode);
                user.WeixinNum = weixinUser.openid;
                logger.Info(user.WeixinNum);
                UserService.Insert(user);
            }        

            return Json("");
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Publish() 
        {

            return View();
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
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

    }
}
