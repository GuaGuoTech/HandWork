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
        public void  SetComment(User user)
        {
            Repository<User> re = new Repository<User>(new EntityContext());
            User u = new User();
            if (u.Comment1!= null)
            {
                for (int i = 2; i <= 4; ++i)
                {
                    if (u.Comment2 == null)
                    {
                        //UserService.Insert(re);
                        re.Update(u);

                    }

                }

            }
            else re.Update(u);
        
        }
        //public static User GetAllEntity()
        //{
        //    Repository<User> repository=new Repository<User>(new EntityContext());
        //    IEnumerable<TEntity> user = repository.GetAllEntity();
        //    return user;
                
        //}

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