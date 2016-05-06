using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Model.Relations;
using HandWork.Com.Model.Users;
namespace HandWork.Com.Provider.Relations
{
    public class RelationProvider
    {
        public void GetRelationShipWithUser()
        {
            using (EntityContext entityContext =  new EntityContext())
            {

                var relationList = entityContext.Relations.ToList().Where(r => r.ManagerForRead == 0).GroupJoin(entityContext.WeixinUsers, r => r.WeixinUserId, w => w.id, (r, w) => new
                {
                    recruit = r,
                    recruitWeixinUserId = r.WeixinUserId,
                    askWeixinUserId = r.AskWeixinUserId,
                }).GroupJoin(entityContext.Users, r => r.recruitWeixinUserId, u => u.Id, (r, u) => new { 
                    recruit = r,
                    user = entityContext.Users.Find(r.recruitWeixinUserId),
                    recruitUser = entityContext.Users.Find(r.recruit),
                });


                return relationList;

            }
        }
    }
}