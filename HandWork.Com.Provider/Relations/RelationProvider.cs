using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Model.Relations;
using HandWork.Com.Model.Users;
using HandWork.Com.Model.JsonModels.Relations;
namespace HandWork.Com.Provider.Relations
{
    public static class RelationProvider
    {
        /// <summary>
        ///管理端显示的用户跟工作关系
        /// </summary>
        /// <returns></returns>
        public static List<RelationAndUser> GetRelationShipWithUser()
        {
            using (EntityContext entityContext =  new EntityContext())
            {

                List<RelationAndUser> relationList = (List<RelationAndUser>)entityContext.Relations.ToList().Where(r => r.ManagerForRead == 0).GroupJoin(entityContext.WeixinUsers, r => r.WeixinUserId, w => w.id, (r, w) => new
                {
                    recruit = r,
                    recruitWeixinUserId = r.WeixinUserId,
                    askWeixinUserId = r.AskWeixinUserId,
                }).GroupJoin(entityContext.Users, r => r.recruitWeixinUserId, u => u.Id, (r, u) => new { 
                    recruit = r,
                    user = (User)entityContext.Users.Find(r.recruitWeixinUserId),
                    recruitUser = (User)entityContext.Users.Find(r.recruit),
                });


                return relationList;

            }
        }
    }
}