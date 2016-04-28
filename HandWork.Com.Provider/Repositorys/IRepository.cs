using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HandWork.Com.Provider.Repositorys
{
    public interface IRespository<TEntity>
    {
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetEntity(long id);

        /// <summary>
        /// 拿到所有的实体
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllEntity();


        /// <summary>
        /// 拿到所有的实体和分页
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllEntity(int pageNum,int maxList);


        /// <summary>
        /// 根据条件返回一个list
        /// </summary>
        /// <param name="lambdaPress"></param>
        /// <returns></returns>
        IEnumerable<TEntity> SearchFor(Expression<Func<TEntity,bool>> lambdaPress);


        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity  entity);

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

    }
}