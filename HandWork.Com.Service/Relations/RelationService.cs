using HandWork.Com.Model.JsonModels.Relations;
using HandWork.Com.Model.Recruits;
using HandWork.Com.Model.Relations;
using HandWork.Com.Model.Users;
using HandWork.Com.Model.Weixins;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Relations;
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
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void SetRelation(User worker,User delaer) 
        {

           
        }
        public static void FinishRelation()
        {

        }




        public static void AddRelation(Relation  relation) {

            Repository<Relation> repository = new Repository<Relation>(new Provider.Contexts.EntityContext());

            repository.Insert(relation);

        
        }


        public static RelationMassage GetRelationWithUser(long weixinUserId)
        {
           
                Repository<Relation> repository = new Repository<Relation>(new Provider.Contexts.EntityContext());

                ///作为发布者的所有的信息
                Expression<Func<Relation, bool>> expression = r => r.WeixinUserId == weixinUserId && r.Finish == 0;
                ///作为请求者所有的信息
                Expression<Func<Relation, bool>> expressionFor = r => r.AskWeixinUserId == weixinUserId && r.Finish != 0&&r.ForRead==0;

                RelationMassage relationMassage = new RelationMassage();

                List<Relation> relationListForPublish = repository.SearchFor(expression).ToList();
                for (int i = 0; i < relationListForPublish.Count; i++)
                {
                    RecruitAndRelationAndWeixinUser recuitAndRelationAndWeixinUser = new RecruitAndRelationAndWeixinUser();

                    recuitAndRelationAndWeixinUser.relation = relationListForPublish[i];
                    recuitAndRelationAndWeixinUser.recuit = new Repository<Recruit>(new EntityContext()).GetEntity(relationListForPublish[i].RecuitId);
                    recuitAndRelationAndWeixinUser.weixinUser = new Repository<WeixinUser>(new EntityContext()).GetEntity(relationListForPublish[i].AskWeixinUserId);
                    relationMassage.recruitAndRelationAndWeixinUser.Add(recuitAndRelationAndWeixinUser);

                }


                List<Relation> relationList = repository.SearchFor(expressionFor).ToList();
                for (int i = 0; i < relationList.Count; i++)
                {
                    RelationAndWeixinUser relationAnWeixinUser = new RelationAndWeixinUser();
                    relationAnWeixinUser.recuit = new Repository<Recruit>(new EntityContext()).GetEntity(relationList[i].RecuitId);
                    relationAnWeixinUser.relation = relationList[i];
                    relationMassage.relationAnWeixinUser.Add(relationAnWeixinUser);

                }
                return relationMassage;


            
           
        


        
        
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
            Expression<Func<Relation, bool>> expression = u => u.AskWeixinUserId == weixinUserId&&u.RecuitId==recruitId;

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


        public static void AcceptThisChecked(long id)
        {

            Repository<Relation> repository = new Repository<Relation>(new Provider.Contexts.EntityContext());

            Relation relation =   repository.GetEntity(id);
            relation.Finish = 1;
            repository.Update(relation);


        }

        public static void RefuseThisChecked(long id)
        {

            Repository<Relation> repository = new Repository<Relation>(new Provider.Contexts.EntityContext());

            Relation relation = repository.GetEntity(id);
            relation.Finish = 2;
            repository.Update(relation);


        }

        public static void ChangeRead(long id)
        {
            Repository<Relation> repository = new Repository<Relation>(new Provider.Contexts.EntityContext());

            Relation relation = repository.GetEntity(id);
            relation.ForRead = 1;
            repository.Update(relation);



        }
        


        public  static  List<RelationAndUser>  GetRelationShipWithUser()
        {


         List<RelationAndUser>  list =   RelationProvider.GetRelationShipWithUser();
         return list;
        }






        public static List<Relation> SearchRelation(Expression<Func<Relation,bool>> ex)
        {
            Repository<Relation> repository = new Repository<Relation>(new Provider.Contexts.EntityContext());

         return       repository.SearchFor(ex).ToList();

        }
    }
}