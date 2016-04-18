using HandWork.Com.Model.Users;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandWork.Com.Service.Users
{
    public class UserService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static User FindUser(string  ) 
        {


            return null;
        }

        public static void Insert(User user)
        {

            Repository<User> repository = new Repository<User>(new EntityContext());
            repository.Insert(user);
        }
        public static void Alert(User user)
        {
            Repository<User> repository = new Repository<User>(new EntityContext());
            repository.Update(user);
        }
        public static User GetEntity(long id)
        {
            Repository<User> repository = new Repository<User>(new EntityContext());
            User user = repository.GetEntity(id);
            return user;
        }

        public static void SendMsg(User user)
        {
            Repository<User> repository = new Repository<User>(new EntityContext());
            repository.Update(user);


        }
        public static void DelMsg(User user)
        {
            Repository<User> repository = new Repository<User>(new EntityContext());
            repository.Delete(user);


        }

    }
}