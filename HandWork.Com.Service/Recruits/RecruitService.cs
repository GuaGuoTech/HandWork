using HandWork.Com.Model.Recruits;
using HandWork.Com.Model.Users;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Recruits;
using HandWork.Com.Provider.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HandWork.Com.Service.Recruits
{
    public class RecruitService
    {
        /// <summary>
        /// 验证是否审核
        /// </summary>
        /// <param name="id">当前对象的ID标识</param>
        /// <returns></returns>
        public static int CheckConfirm(long id)
        {
            Repository<User> repo = new Repository<User>(new EntityContext());
            User user = repo.GetEntity(id);
            return user.Confirm;


        }

        public static string Apply(long id)
        {
            //Repository()
            return "test";

        }
        public static void Alert(Recruit recruit)
        {
            Repository<Recruit> repository = new Repository<Recruit>(new EntityContext());
            repository.Update(recruit);

        }
        public static Recruit Insert(Recruit recruit)
        {
            Repository<Recruit> repository = new Repository<Recruit>(new EntityContext());
            recruit.PublishTime = DateTime.Now;
            return       repository.Insert(recruit);
        }
      
        public static Recruit GetEntity(long id)
        {
            Repository<Recruit> repository = new Repository<Recruit>(new EntityContext());
           return      repository.GetEntity(id);

        }

        /// <summary>
        /// 发布招聘
        /// </summary>
        /// <param name="recruit">对象上下文</param>

        public static void SendMsg(Recruit recruit)
        {
            //Repository<Recruit> repository = new Repository<Recruit>(new EntityContext());
            //recruit.FinalMoney = recruit.Money * recruit.Percent;
            //repository.Update(recruit);


        }
        public static void DelMsg(Recruit recruit)
        {
            Repository<Recruit> repository = new Repository<Recruit>(new EntityContext());
            repository.Delete(recruit);


        }

        public static List<Model.ViewModels.JobLists.JobList> GetJobList(int pageNum, int maxList, int type, Expression<Func<Recruit, bool>> ex )
        {



            return RecruitProvider.GetAllRecruitByType(pageNum, maxList, type, ex);


        
            
        }

        public static List<Model.ViewModels.JobLists.JobList> GetJobList(int pageNum, int maxList, int type)
        {



            return RecruitProvider.GetAllRecruitByType(pageNum, maxList, type);




        }

        public static List<Recruit> SearchRecruit(System.Linq.Expressions.Expression<Func<Recruit, bool>> ex)
        {
            Repository<Recruit> repository = new Repository<Recruit>(new EntityContext());
        return    repository.SearchFor(ex).ToList();
        }

        public static List<Recruit> SearchRecruitForAsk(long p)
        {
            throw new NotImplementedException();
        }
    }
}