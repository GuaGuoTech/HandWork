using System;
using System.Collections.Generic;
using System.Linq;
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