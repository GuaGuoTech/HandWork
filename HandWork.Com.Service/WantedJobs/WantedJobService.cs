using HandWork.Com.Model;
using HandWork.Com.Model.Users;
using HandWork.Com.Model.WantedJobs;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandWork.Com.Service.WantedJobs
{
    public class WantedJobService
    {
        public static int CheckComfirm(long id)
        {
            Repository<User> repository = new Repository<User>(new EntityContext());
            User user=repository.GetEntity(id);         
            return user.ManConfirm;                           
            

        }
        public static void Insert(WantedJob wantejob)
        {
            Repository<WantedJob> repository = new Repository<WantedJob>(new EntityContext());
            repository.Insert(wantejob);
        }
        public static void Alert(WantedJob wantedjob)
        {
            Repository<WantedJob> repository = new Repository<WantedJob>(new EntityContext());
            repository.Update(wantedjob);

        }
        public static void GetEntity(long id)
        {
            Repository<WantedJob> repository =new Repository<WantedJob>(new EntityContext());
            repository.GetEntity(id);
        
        }


        public static void SendMsg(WantedJob wantedjob)
        {
            Repository<WantedJob> repository = new Repository<WantedJob>(new EntityContext());
            repository.Update(wantedjob);


        }
        public static void DelMsg(WantedJob wantedjob)
        {
            Repository<WantedJob> repository = new Repository<WantedJob>(new EntityContext());
            repository.Delete(wantedjob);


        }
    }
}