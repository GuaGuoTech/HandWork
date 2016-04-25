using HandWork.Com.Model.Weixins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandWork.Com.Model.ViewModels.JobLists
{
    public class JobList
    {
        public WeixinUser weixinUser { get; set; }

        public Recruits.Recruit recuit { get; set; }

        public JobList()
        {

            weixinUser = new WeixinUser();
            recuit = new Recruits.Recruit();
        
        }
    }
}