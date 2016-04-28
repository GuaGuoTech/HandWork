using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HandWork.Com.Model.Relations;
using HandWork.Com.Model.Recruits;
using HandWork.Com.Model.Weixins;
namespace HandWork.Com.Model.JsonModels.Relations
{
    public class RelationMassage
    {

        public List<RecruitAndRelationAndWeixinUser> recruitAndRelationAndWeixinUser { get; set; }


        public List<RelationAndWeixinUser> relationAnWeixinUser { get; set; }

        public RelationMassage()
        {

            recruitAndRelationAndWeixinUser = new List<RecruitAndRelationAndWeixinUser>();
            relationAnWeixinUser = new List<RelationAndWeixinUser>();
        }
    }


    public class RecruitAndRelationAndWeixinUser
    {
        public Recruit recuit { get; set; }

        public WeixinUser weixinUser { get; set; }

        public Relation relation { get; set; }
        public RecruitAndRelationAndWeixinUser()
        {
            recuit = new Recruit();
            weixinUser = new WeixinUser();
            relation = new Relation();


        }


    }


    public class RelationAndWeixinUser
    {
        public Relation relation { get; set; }

        public Recruit recuit { get; set; }
        public RelationAndWeixinUser()
        {
            recuit = new Recruit();
            relation = new Relation();


        }

    }


}