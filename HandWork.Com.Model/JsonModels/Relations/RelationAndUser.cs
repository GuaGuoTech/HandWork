using HandWork.Com.Model.Recruits;
using HandWork.Com.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.JsonModels.Relations
{
    public class RelationAndUser
    {


        public User recruitUser { get; set; }

        public User askUser { get; set; }

        public Recruit recruit { get; set; }

    }
}