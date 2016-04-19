using HandWork.Com.Model.Users;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HandWork.Com.Service.Users
{
    public class UserService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
      private  static    Repository<User> repository = new Repository<User>(new EntityContext());

        public static User FindUser(string  weixinCode) 
        {
            Expression<Func<User, bool>> expression = u => u.WeixinNum == weixinCode;
            User   user =        repository.FindEntity(expression);

            return user;
        }

        public static void Insert(User user)
        {
            
            repository.Insert(user);
        }
        public static void Alert(User user)
        {
            repository.Update(user);
        }
        public static User GetEntity(long id)
        {
            User user = repository.GetEntity(id);
            return user;
        }

        public static void SendMsg(User user)
        {
            repository.Update(user);


        }
        public static void DelMsg(User user)
        {
            repository.Delete(user);


        }

    }
}