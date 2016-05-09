using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Model.Relations;
using HandWork.Com.Model.Users;
using HandWork.Com.Model.JsonModels.Relations;
using Newtonsoft.Json;
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

              var relationList = entityContext.Relations.ToList().Where(r => r.ManagerForRead == 0).GroupJoin(entityContext.WeixinUsers, r => r.WeixinUserId, w => w.id, (r, w) => new
                {
                    relation = r,
                    recruit = entityContext.Recruits.Where(g=>g.Id==r.RecuitId).ToList()[0],
                    recruitWeixinUserId = r.WeixinUserId,
                    askWeixinUserId = r.AskWeixinUserId,
                }).GroupJoin(entityContext.Users, r => r.recruitWeixinUserId, u => u.Id, (r, u) => new {
                    relation = r.relation,
                    recruit = r.recruit,
                    askUser = (User)entityContext.Users.Where(g => g.Id == r.askWeixinUserId).ToList()[0],
                    recruitUser = (User)entityContext.Users.Where(g => g.Id == r.recruitWeixinUserId).ToList()[0],
                });

              string jsonStr = JsonConvert.SerializeObject(relationList);

                //反序列化
                List<RelationAndUser> list =   JsonConvert.DeserializeObject< List<RelationAndUser>>(jsonStr);

                return list;

            }
        }
    }
}