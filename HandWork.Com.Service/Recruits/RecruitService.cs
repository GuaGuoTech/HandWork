using HandWork.Com.Model.Recruits;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandWork.Com.Service.Recruits
{
    public class RecruitService
    {
        public static void Alert(Recruit recruit)
        {
            Repository<Recruit> repository = new Repository<Recruit>(new EntityContext());
            repository.Update(recruit);

        }
        public static void Insert(Recruit recruit)
        {
            Repository<Recruit> repository = new Repository<Recruit>(new EntityContext());
            repository.Insert(recruit);
        }
      
        public static void GetEntity(long id)
        {
            Repository<Recruit> repository = new Repository<Recruit>(new EntityContext());
            repository.GetEntity(id);

        }


        public static void SendMsg(Recruit recruit)
        {
            Repository<Recruit> repository = new Repository<Recruit>(new EntityContext());
            repository.Update(recruit);


        }
        public static void DelMsg(Recruit recruit)
        {
            Repository<Recruit> repository = new Repository<Recruit>(new EntityContext());
            repository.Delete(recruit);


        }
    }
}