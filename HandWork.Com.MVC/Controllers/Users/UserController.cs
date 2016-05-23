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
using HandWork.Com.Service.Recruits;
using HandWork.Com.Model.Recruits;
using System.Linq.Expressions;
using HandWork.Com.Model.ViewModels.JobLists;
using HandWork.Com.Model.Relations;

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
               Model.Users.User user = UserService.FindUser(weixinUser.id);
                return View(user);
            }
            else
            {

                return View();

            }

        }
        public ActionResult PhoneCheck()
        {
            return View();
        }

        public ActionResult MyAsk()
        {
            return View();
        }
        public ActionResult Mistake() 
        {
            return View();
        }
        public ActionResult MyPublish()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MyPublishRecruit()
        {
            if (Session["weixinuser"] != null)
            {
                string weixinCode = Session["weixinuser"].ToString();
                WeixinUser weixinUser = JsonConvert.DeserializeObject<WeixinUser>(weixinCode);
                string openId = weixinUser.openid;
                //string openId = "oL62cwXqco5NPxguPwBiOfT4h6Ww";
                logger.Info(openId);
                int pageNum = 0;
                int maxNum = 0;
                int type = 0;

                Expression<Func<Recruit, bool>> ex = r=>r.WeixinUserId==weixinUser.id;

                List<JobList> jobList = RecruitService.GetJobList(pageNum, maxNum, type, ex);
                return Json(jobList);
            }
            else
            {

                return Json("22");

            }
        }
       [HttpPost]
        public ActionResult MyAskRecruit()
        {

            if (Session["weixinuser"] != null)
            {
                string weixinCode = Session["weixinuser"].ToString();
                WeixinUser weixinUser = JsonConvert.DeserializeObject<WeixinUser>(weixinCode);
                string openId = weixinUser.openid;
                //string openId = "oL62cwXqco5NPxguPwBiOfT4h6Ww";
                logger.Info(openId);
                int pageNum = 0;
                int maxNum = 0;
                int type = 0;

                Expression<Func<Relation, bool>> ex1 = r=>r.AskWeixinUserId==weixinUser.id;

              List  <Relation> relation = RelationService.SearchRelation(ex1);

              List<JobList> jobList = new List<JobList>();
              for (int i = 0; i < relation.Count; i++)
              {
                  Expression<Func<Recruit, bool>> ex2 = r=>r.Id==relation[i].RecuitId;

                  jobList.AddRange(RecruitService.GetJobList(pageNum, maxNum, type, ex2));
              }

              
                return Json(jobList);

            }
            else
            {

                return Json("22");

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
                user.WeixinUserId = weixinUser.id;
            //user.WeixinNum = "oL62cwXqco5NPxguPwBiOfT4h6Ww";
                logger.Info(user.Id);
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
