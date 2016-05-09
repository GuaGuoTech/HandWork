using HandWork.Com.Model.ViewModels.JobLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Model.Recruits;
using System.Linq.Expressions;

namespace HandWork.Com.Provider.Recruits
{
    public static class RecruitProvider
    {
        public  static List<JobList>  GetAllRecruitByType(int pageNum, int maxList, int type,Expression<Func<Recruit,bool>> ex=null)
        {
            using (EntityContext entityContext = new EntityContext())
            {
                List<JobList> jobList = new List<JobList>();
                int num = pageNum * maxList - maxList;
              List<Recruit>   recruitList;
                ///当表达为空的时候   则不分页 直接返回集合
              if (ex != null)
              {
                  recruitList = entityContext.Recruits.Where(ex).ToList().OrderByDescending(r => r.PublishTime).ToList();

              }
              else
              {


                  ///如果为四则不分类
                  if (type == 4)
                  {
                      recruitList = entityContext.Recruits.ToList().OrderByDescending(r => r.PublishTime).Skip(num).Take(maxList).ToList();
                  }
                  else
                  {
                      recruitList = entityContext.Recruits.Where(r => r.PayType == type).OrderByDescending(r => r.PublishTime).Skip(num).Take(maxList).ToList();
                  }
              }
                for (int i = 0; i < recruitList.Count; i++)
		     	{
			       JobList  job = new JobList();
                    job.recuit =  recruitList[i];
                    job.weixinUser = entityContext.WeixinUsers.Find(recruitList[i].WeixinUserId);
                    jobList.Add(job);
                    

		     	}
                return jobList;

            }


        }

    }
}