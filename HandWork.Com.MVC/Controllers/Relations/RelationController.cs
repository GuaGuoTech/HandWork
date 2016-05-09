using HandWork.Com.Model.JsonModels.Relations;
using HandWork.Com.Model.Relations;
using HandWork.Com.Model.Weixins;
using HandWork.Com.Service.Recruits;
using HandWork.Com.Service.Relations;
using HandWork.Com.Service.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandWork.Com.MVC.Controllers.Relations
{
    public class RelationController : Controller
    {
        //
        // GET: /Relation/
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult AddRelation(Relation relation)
        {

            
            if (Session["weixinUser"]!=null)
            {
                WeixinUser weixinUser = new WeixinUser();
                weixinUser = JsonConvert.DeserializeObject<WeixinUser>(Session["weixinUser"].ToString());

                Model.Users.User user = UserService.FindUser(weixinUser.id);
                if (user==null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }


                else
                {
                    relation.AskWeixinUserId = weixinUser.id;
                    relation.ForRead = 0;
                    relation.ManagerForRead = 0;
                    relation.WeixinUserId = RecruitService.GetEntity(relation.RecuitId).WeixinUserId;
                    RelationService.AddRelation(relation);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("erro",JsonRequestBehavior.AllowGet);
            }

        }


        /// <summary>
        /// 返回消息的总条数
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult GetRelationCout(long ids)
        {
            logger.Info(ids);
          RelationMassage list =  RelationService.GetRelationWithUser(ids);
          int cout = list.relationAnWeixinUser.Count + list.recruitAndRelationAndWeixinUser.Count;
          return Json(cout, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ChangeRead(string ids)
        {


            if (ids != null)
            {
                string[] idArray = ids.Split(',');
                for (int i = 0; i < idArray.Length; i++)
                {
                    if (idArray[i] != "")
                    {
                        long id = Convert.ToInt64(idArray[i]);
                        RelationService.ChangeRead(id);
                    }

                }
                return Json("233", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("shibai", JsonRequestBehavior.AllowGet);
            }

        }
    

        /// <summary>
        /// 返回具体的集合   其中list.relationList[0]位作为发布者的消息，[1]位申请者的消息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetRelation(long id)
        {

            RelationMassage list = RelationService.GetRelationWithUser(id);


            return Json(list, JsonRequestBehavior.AllowGet);

        }


        public ActionResult AcceptThisChecked(string  ids)
        {
            logger.Info(ids);

            if (ids!=null)
            {
                string[] idArray = ids.Split(',');
                for (int i = 0; i < idArray.Length; i++)
                {
                    if (idArray[i]!="")
                    {
                        long id = Convert.ToInt64(idArray[i]);
                        RelationService.AcceptThisChecked(id);
                    }
           
                }
                return Json("23", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("shibai", JsonRequestBehavior.AllowGet);
            }
     
        }


        public ActionResult RefuseThisChecked(string  ids)
        {
            logger.Info(ids);

            if (ids != null)
            {
             
                string[] idArray = ids.Split(',');
                for (int i = 0; i < idArray.Length; i++)
                {
                    if (idArray[i] != "")
                    {
                        long id = Convert.ToInt64(idArray[i]);
                        RelationService.RefuseThisChecked(id);
                    }
                }
                return Json("32",JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("shibai", JsonRequestBehavior.AllowGet);
            }
        }



    }
}
