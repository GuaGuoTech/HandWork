using HandWork.Com.Provider.Contexts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HandWork.Com.Provider.Repositorys
{

    public class Repository<TEntity> : IRespository<TEntity> where TEntity : class
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected DbSet<TEntity> Dbset;
        private readonly DbContext _dbContext;

        /// <summary>
        ///构造函数 初始化DbsSet  和  _dbContext 
        /// </summary>
        /// <param name="dbContext"></param>
        public Repository(EntityContext dbContext)
        {
            _dbContext = dbContext;
            Dbset = dbContext.Set<TEntity>();
        }
        /// <summary>
        /// 空的构造函数
        /// </summary>
        public Repository()
        {


        }

        /// <summary>
        /// 条件查找
        /// </summary>
        /// <param name="lambdaPress">lambda表达式</param>
        /// <returns></returns>
        public IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> lambdaPress)
        {

            return Dbset.Where(lambdaPress).AsNoTracking();

        }



        public TEntity GetEntity(long id)
        {

            return Dbset.Find(id);

        }

        public IEnumerable<TEntity> GetAllEntity()
        {

            return Dbset.ToList();

        }

        public void Update(TEntity entity)
        {

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();



        }

        /// <summary>
        /// 带分页的拿到所有的entity
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="maxList"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAllEntity(int pageNum, int maxList)
        {
            int num = pageNum * maxList - maxList;

            return Dbset.ToList().Skip(num).Take(maxList);
        }

        public void Insert(TEntity entity)
        {

            try
            {
                Dbset.Add(entity);
                string aa = JsonConvert.SerializeObject(entity);
                logger.Info(aa);
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                List<string> errorMessages = new List<string>();
                foreach (DbEntityValidationResult validationResult in ex.EntityValidationErrors)
                {
                    string entityName = validationResult.Entry.Entity.GetType().Name;
                    foreach (DbValidationError error in validationResult.ValidationErrors)
                    {
                        errorMessages.Add(entityName + "." + error.PropertyName + ": " + error.ErrorMessage);
                    }
                }

                foreach (var item in errorMessages)
                {
                    logger.Info(item);
                }
            }


        }

        public void Delete(TEntity entity)
        {

            Dbset.Attach(entity);
            Dbset.Remove(entity);
            _dbContext.SaveChanges();

        }

    }
}