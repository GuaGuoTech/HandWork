using HandWork.Com.Model.Relation;
using HandWork.Com.Model.Users;
using HandWork.Com.Provider.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HandWork.Com.Service.Relations
{
    public class RelationService
    {
        public static void SetRelation(User worker,User delaer) 
        {

           
        }
        public static void FinishRelation()
        {

        }
        /// <summary>
        /// 是否投过简历
        /// </summary>
        /// <param name="weixinUserId"></param>
        /// <param name="recruitId"></param>
        /// <returns>有记录return  true</returns>
        public static bool IsAskFor(long weixinUserId,long recruitId)
        {
            Repository<Relation> repository = new Repository<Relation>(new Provider.Contexts.EntityContext());
            Expression<Func<Relation, bool>> expression = u => u.WeixinUserId == weixinUserId&&u.RecuitId==recruitId;

            List<Relation>  relationList =   repository.SearchFor(expression).ToList();
            if (relationList.Count>0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        
    }
}