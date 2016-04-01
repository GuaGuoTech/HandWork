using HandWork.Com.Provider.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HandWork.Com.Provider.Repositorys
{
    public  class Repository<TEntity> : IRespository<TEntity> where TEntity : class
    {
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

        public void Insert(TEntity entity)
        {

            Dbset.Add(entity);
            _dbContext.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            Dbset.Attach(entity);
            Dbset.Remove(entity);
            _dbContext.SaveChanges();

        }
    }
}