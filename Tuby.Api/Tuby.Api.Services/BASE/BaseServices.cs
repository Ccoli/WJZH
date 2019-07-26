using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IRepository.Base;
using Tuby.Api.IServices.BASE;
using Tuby.Api.Model;
using Tuby.Api.Repository.Base;

namespace Tuby.Api.Services.BASE
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        //public IBaseRepository<TEntity> baseDal = new BaseRepository<TEntity>();
        public IBaseRepository<TEntity> baseDal;//通过在子类的构造函数中注入，这里是基类，不用构造函数

        public async Task<TEntity> QueryByID(object objId)
        {
            return await baseDal.QueryByID(objId);
        }
        /// <summary>
        /// 功能描述:根据ID查询一条数据
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="objId">id（必须指定主键特性 [SugarColumn(IsPrimaryKey=true)]），如果是联合主键，请使用Where条件</param>
        /// <param name="blnUseCache">是否使用缓存</param>
        /// <returns>数据实体</returns>
        public async Task<TEntity> QueryByID(object objId, bool blnUseCache = false)
        {
            return await baseDal.QueryByID(objId, blnUseCache);
        }

        /// <summary>
        /// 功能描述:根据ID查询数据
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="lstIds">id列表（必须指定主键特性 [SugarColumn(IsPrimaryKey=true)]），如果是联合主键，请使用Where条件</param>
        /// <returns>数据实体列表</returns>
        public async Task<List<TEntity>> QueryByIDs(object[] lstIds)
        {
            return await baseDal.QueryByIDs(lstIds);
        }

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity">博文实体类</param>
        /// <returns></returns>
        public async Task<int> Add(TEntity entity)
        {
            return await baseDal.Add(entity);
        }

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="entity">博文实体类</param>
        /// <returns></returns>
        public async Task<bool> Update(TEntity entity)
        {
            return await baseDal.Update(entity);
        }
        public async Task<bool> Update(TEntity entity, string strWhere)
        {
            return await baseDal.Update(entity, strWhere);
        }

        public async Task<bool> Update(
         TEntity entity,
         List<string> lstColumns = null,
         List<string> lstIgnoreColumns = null,
         string strWhere = ""
            )
        {
            return await baseDal.Update(entity, lstColumns, lstIgnoreColumns, strWhere);
        }


        /// <summary>
        /// 根据实体删除一条数据
        /// </summary>
        /// <param name="entity">博文实体类</param>
        /// <returns></returns>
        public async Task<bool> Delete(TEntity entity)
        {
            return await baseDal.Delete(entity);
        }

        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public async Task<bool> DeleteById(object id)
        {
            return await baseDal.DeleteById(id);
        }

        /// <summary>
        /// 删除指定ID集合的数据(批量删除)
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        public async Task<bool> DeleteByIds(object[] ids)
        {
            return await baseDal.DeleteByIds(ids);
        }



        /// <summary>
        /// 功能描述:查询所有数据
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query()
        {
            return await baseDal.Query();
        }

        /// <summary>
        /// 功能描述:查询数据列表
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(string strWhere)
        {
            return await baseDal.Query(strWhere);
        }

        /// <summary>
        /// 功能描述:查询数据列表
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="whereExpression">whereExpression</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await baseDal.Query(whereExpression);
        }
        /// <summary>
        /// 功能描述:查询一个列表
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            return await baseDal.Query(whereExpression, orderByExpression, isAsc);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds)
        {
            return await baseDal.Query(whereExpression, strOrderByFileds);
        }

        /// <summary>
        /// 功能描述:查询一个列表
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(string strWhere, string strOrderByFileds)
        {
            return await baseDal.Query(strWhere, strOrderByFileds);
        }

        /// <summary>
        /// 功能描述:查询前N条数据
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intTop">前N条</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            return await baseDal.Query(whereExpression, intTop, strOrderByFileds);
        }

        /// <summary>
        /// 功能描述:查询前N条数据
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="intTop">前N条</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(
            string strWhere,
            int intTop,
            string strOrderByFileds)
        {
            return await baseDal.Query(strWhere, intTop, strOrderByFileds);
        }

        /// <summary>
        /// 功能描述:分页查询
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="intTotalCount">数据总量</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(
            Expression<Func<TEntity, bool>> whereExpression,
            int intPageIndex,
            int intPageSize,
            string strOrderByFileds)
        {
            return await baseDal.Query(
              whereExpression,
              intPageIndex,
              intPageSize,
              strOrderByFileds);
        }

        /// <summary>
        /// 功能描述:分页查询
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="intTotalCount">数据总量</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(
          string strWhere,
          int intPageIndex,
          int intPageSize,
          string strOrderByFileds)
        {
            return await baseDal.Query(
            strWhere,
            intPageIndex,
            intPageSize,
            strOrderByFileds);
        }

        public async Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression,
        int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            return await baseDal.QueryPage(whereExpression,
         intPageIndex = 0, intPageSize, strOrderByFileds);
        }
        /// <summary> 
        ///查询-多表查询
        /// </summary> 
        /// <typeparam name="T">实体1</typeparam> 
        /// <typeparam name="T2">实体2</typeparam> 
        /// <typeparam name="T3">实体3</typeparam>
        /// <typeparam name="TResult">返回对象</typeparam>
        /// <param name="joinExpression">关联表达式 (join1,join2) => new object[] {JoinType.Left,join1.UserNo==join2.UserNo}</param> 
        /// <param name="selectExpression">返回表达式 (s1, s2) => new { Id =s1.UserNo, Id1 = s2.UserNo}</param>
        /// <param name="whereLambda">查询表达式 (w1, w2) =>w1.UserNo == "")</param> 
        /// <returns>值</returns>
        public List<TResult> QueryMuch<T, T2, TResult>(Expression<Func<T, T2,object[]>> joinExpression) where T : class, new()
        {
            return baseDal.QueryMuch<T, T2, TResult>(joinExpression);
        }

        /// <summary> 
        ///查询-多表查询
        /// </summary> 
        /// <typeparam name="T">实体1</typeparam> 
        /// <typeparam name="T2">实体2</typeparam> 
        /// <typeparam name="T3">实体3</typeparam>
        /// <typeparam name="TResult">返回对象</typeparam>
        /// <param name="joinExpression">关联表达式 (join1,join2) => new object[] {JoinType.Left,join1.UserNo==join2.UserNo}</param> 
        /// <param name="selectExpression">返回表达式 (s1, s2) => new { Id =s1.UserNo, Id1 = s2.UserNo}</param>
        /// <param name="whereLambda">查询表达式 (w1, w2) =>w1.UserNo == "")</param> 
        /// <returns>值</returns>
        public List<TResult> QueryMuch<T, T2, T3, TResult>(Expression<Func<T, T2, T3, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20) where T : class, new()
        {
            return baseDal.QueryMuch<T, T2, T3, TResult>(joinExpression, intPageIndex, intPageSize);
        }

        /// <summary> 
        ///查询-多表查询
        /// </summary> 
        /// <typeparam name="T">实体1</typeparam> 
        /// <typeparam name="T2">实体2</typeparam> 
        /// <typeparam name="T3">实体3</typeparam>
        /// <typeparam name="TResult">返回对象</typeparam>
        /// <param name="joinExpression">关联表达式 (join1,join2) => new object[] {JoinType.Left,join1.UserNo==join2.UserNo}</param> 
        /// <param name="selectExpression">返回表达式 (s1, s2) => new { Id =s1.UserNo, Id1 = s2.UserNo}</param>
        /// <param name="whereLambda">查询表达式 (w1, w2) =>w1.UserNo == "")</param> 
        /// <returns>值</returns>
        public async Task<PageModel<TResult>> QueryMuch<T, T2, T3, T4, TResult>(Expression<Func<T, T2, T3, T4, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20) where T : class, new()
        {
            return await baseDal.QueryMuch<T, T2, T3, T4, TResult>(joinExpression, intPageIndex, intPageSize);
        }

        /// <summary> 
        ///查询-多表查询
        /// </summary> 
        /// <typeparam name="T">实体1</typeparam> 
        /// <typeparam name="T2">实体2</typeparam> 
        /// <typeparam name="T3">实体3</typeparam>
        /// <typeparam name="T4">实体4</typeparam>
        /// <typeparam name="T5">实体5</typeparam> 
        /// <typeparam name="TResult">返回对象</typeparam>
        /// <param name="joinExpression">关联表达式 (join1,join2) => new object[] {JoinType.Left,join1.UserNo==join2.UserNo}</param> 
        /// <param name="selectExpression">返回表达式 (s1, s2) => new { Id =s1.UserNo, Id1 = s2.UserNo}</param>
        /// <param name="whereLambda">查询表达式 (w1, w2) =>w1.UserNo == "")</param> 
        /// <returns>值</returns>
        public List<TResult> QueryMuch<T, T2, T3, T4, T5, TResult>(Expression<Func<T, T2, T3, T4, T5, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, TResult>> selectExpression, Expression<Func<T, T2, T3, T4, T5, bool>> whereLambda = null) where T : class, new()
        {
            return baseDal.QueryMuch<T, T2, T3, T4, T5, TResult>(joinExpression, selectExpression, whereLambda);
        }
    }
}
