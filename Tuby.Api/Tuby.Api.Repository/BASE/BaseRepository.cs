﻿
using Tuby.Api.IRepository.Base;
using Tuby.Api.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.Common.DB;
using Tuby.Api.Repository.sugar;

namespace Tuby.Api.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private DbContext context;
        private SqlSugarClient db;
        private SimpleClient<TEntity> entityDB;

        public DbContext Context
        {
            get { return context; }
            set { context = value; }
        }
        internal SqlSugarClient Db
        {
            get { return db; }
            private set { db = value; }
        }
        internal SimpleClient<TEntity> EntityDB
        {
            get { return entityDB; }
            private set { entityDB = value; }
        }
        public BaseRepository()
        {
            DbContext.Init(BaseDBConfig.ConnectionString, (DbType)BaseDBConfig.DbType);
            context = DbContext.GetDbContext();
            db = context.Db;
            entityDB = context.GetEntityDB<TEntity>(db);
        }



        public async Task<TEntity> QueryByID(object objId)
        {
            return await Task.Run(() => db.Queryable<TEntity>().InSingle(objId));
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
            return await Task.Run(() => db.Queryable<TEntity>().WithCacheIF(blnUseCache).InSingle(objId));
        }

        /// <summary>
        /// 功能描述:根据ID查询数据
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="lstIds">id列表（必须指定主键特性 [SugarColumn(IsPrimaryKey=true)]），如果是联合主键，请使用Where条件</param>
        /// <returns>数据实体列表</returns>
        public async Task<List<TEntity>> QueryByIDs(object[] lstIds)
        {
            return await Task.Run(() => db.Queryable<TEntity>().In(lstIds).ToList());
        }

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity">博文实体类</param>
        /// <returns></returns>
        public async Task<int> Add(TEntity entity)
        {
            var i = await Task.Run(() => db.Insertable(entity).ExecuteReturnBigIdentity());
            //返回的i是long类型,这里你可以根据你的业务需要进行处理
            return (int)i;
        }

        /// <summary>
        /// 批量插入实体模型
        /// </summary>
        /// <param name="entity">博文实体类</param>
        /// <returns></returns>
        public async Task<int> AddList(List<TEntity> list)
        {
            var i = await Task.Run(() => db.Insertable(list.ToArray()).ExecuteCommand());
            //返回的i是long类型,这里你可以根据你的业务需要进行处理
            return (int)i;
        }

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="entity">博文实体类</param>
        /// <returns></returns>
        public async Task<bool> Update(TEntity entity)
        {
            //这种方式会以主键为条件
            var i = await Task.Run(() => db.Updateable(entity).ExecuteCommand());
            return i > 0;
        }

        public async Task<bool> Update(TEntity entity, string strWhere)
        {
            return await Task.Run(() => db.Updateable(entity).Where(strWhere).ExecuteCommand() > 0);
        }

        public async Task<bool> Update(string strSql, SugarParameter[] parameters = null)
        {
            return await Task.Run(() => db.Ado.ExecuteCommand(strSql, parameters) > 0);
        }

        public async Task<bool> Update(
          TEntity entity,
          List<string> lstColumns = null,
          List<string> lstIgnoreColumns = null,
          string strWhere = ""
            )
        {
            //IUpdateable<TEntity> up = await Task.Run(() => db.Updateable(entity));
            //if (lstIgnoreColumns != null && lstIgnoreColumns.Count > 0)
            //{
            //    up = await Task.Run(() => up.IgnoreColumns(it => lstIgnoreColumns.Contains(it)));
            //}
            //if (lstColumns != null && lstColumns.Count > 0)
            //{
            //    up = await Task.Run(() => up.UpdateColumns(it => lstColumns.Contains(it)));
            //}
            //if (!string.IsNullOrEmpty(strWhere))
            //{
            //    up = await Task.Run(() => up.Where(strWhere));
            //}
            //return await Task.Run(() => up.ExecuteCommand()) > 0;
            IUpdateable<TEntity> up = db.Updateable(entity);
            if (lstIgnoreColumns != null && lstIgnoreColumns.Count > 0)
            {
                up = up.IgnoreColumns(lstIgnoreColumns.ToArray());
            }
            if (lstColumns != null && lstColumns.Count > 0)
            {
                up = up.UpdateColumns(lstColumns.ToArray());
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                up = up.Where(strWhere);
            }
            return await up.ExecuteCommandHasChangeAsync();
        }

        /// <summary>
        /// 根据实体删除一条数据
        /// </summary>
        /// <param name="entity">博文实体类</param>
        /// <returns></returns>
        public async Task<bool> Delete(TEntity entity)
        {
            var i = await Task.Run(() => db.Deleteable(entity).ExecuteCommand());
            return i > 0;
        }

        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public async Task<bool> DeleteById(object id)
        {
            var i = await Task.Run(() => db.Deleteable<TEntity>(id).ExecuteCommand());
            return i > 0;
        }

        /// <summary>
        /// 删除指定条件
        /// </summary>
        /// <param name="value">主键ID</param>
        /// <returns></returns>
        public async Task<bool> DeleteValue(Expression<Func<TEntity, bool>> whereExpression)
        {
            var i = await Task.Run(() => db.Deleteable<TEntity>().Where(whereExpression).ExecuteCommand());
            return i > 0;
        }

        /// <summary>
        /// 删除指定ID集合的数据(批量删除)
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        public async Task<bool> DeleteByIds(object[] ids)
        {
            var i = await Task.Run(() => db.Deleteable<TEntity>().In(ids).ExecuteCommand());
            return i > 0;
        }



        /// <summary>
        /// 功能描述:查询所有数据
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query()
        {
            return await Task.Run(() => entityDB.GetList());
        }

        /// <summary>
        /// 功能描述:查询数据列表
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(string strWhere)
        {
            return await Task.Run(() => db.Queryable<TEntity>().WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).ToList());
        }
        public async Task<List<string>> QueryField(Expression<Func<TEntity, string>> selectExpression)
        {
            return await Task.Run(() => db.Queryable<TEntity>().Select(selectExpression).ToList());
        }
        public async Task<List<object>> QueryField(Expression<Func<TEntity, object>> selectExpression)
        {
            return await Task.Run(() => db.Queryable<TEntity>().Select(selectExpression).ToList());
        }


        /// <summary>
        /// 功能描述:查询数据列表
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="whereExpression">whereExpression</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await Task.Run(() => entityDB.GetList(whereExpression));
        }

        /// <summary>
        /// 功能描述:查询一个列表
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds)
        {
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).WhereIF(whereExpression != null, whereExpression).ToList());
        }
        /// <summary>
        /// 功能描述:查询一个列表
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(orderByExpression != null, orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc).WhereIF(whereExpression != null, whereExpression).ToList());
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
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).ToList());
        }


        /// <summary>
        /// 功能描述:查询前N条数据
        /// 作　　者:Tuby.Api
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intTop">前N条</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(
            Expression<Func<TEntity, bool>> whereExpression,
            int intTop,
            string strOrderByFileds)
        {
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).WhereIF(whereExpression != null, whereExpression).Take(intTop).ToList());
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
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).Take(intTop).ToList());
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
        public async Task<PageModel<TEntity>> Query(
            Expression<Func<TEntity, bool>> whereExpression,
            int intPageIndex,
            int intPageSize,
            string strOrderByFileds)
        {
            RefAsync<int> totalCount = 0;
            var list= await Task.Run(() => db.Queryable<TEntity>()
            .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
            .WhereIF(whereExpression != null, whereExpression)
            .ToPageListAsync(intPageIndex, intPageSize, totalCount));
            int pageCount = (Math.Ceiling(totalCount.ObjToDecimal() / intPageSize.ObjToDecimal())).ObjToInt();
            return new PageModel<TEntity>() { dataCount = totalCount, pageCount = pageCount, page = intPageIndex, PageSize = intPageSize, data = list };
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
        public async Task<PageModel<TEntity>> Query(
          string strWhere,
          int intPageIndex,
          int intPageSize,

          string strOrderByFileds)
        {
            RefAsync<int> totalCount = 0;
            var list = await Task.Run(() => db.Queryable<TEntity>()
            .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
            .WhereIF(!string.IsNullOrEmpty(strWhere), strWhere)
           .ToPageListAsync(intPageIndex, intPageSize, totalCount));
            int pageCount = (Math.Ceiling(totalCount.ObjToDecimal() / intPageSize.ObjToDecimal())).ObjToInt();
            return new PageModel<TEntity>() { dataCount = totalCount, pageCount = pageCount, page = intPageIndex, PageSize = intPageSize, data = list };
        }




        public async Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression,
        int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            RefAsync<int> totalCount = 0;
            var list = await db.Queryable<TEntity>()
             .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
             .WhereIF(whereExpression != null, whereExpression)
             .ToPageListAsync(intPageIndex, intPageSize, totalCount);

            int pageCount = (Math.Ceiling(totalCount.ObjToDecimal() / intPageSize.ObjToDecimal())).ObjToInt();
            return new PageModel<TEntity>() { dataCount = totalCount, pageCount = pageCount, page = intPageIndex, PageSize = intPageSize, data = list };
        }

        /// <summary> 
        ///查询-多表查询
        /// </summary> 
        /// <typeparam name="T">实体1</typeparam> 
        /// <typeparam name="T2">实体2</typeparam> 
        /// <typeparam name="TResult">返回对象</typeparam>
        /// <param name="joinExpression">关联表达式 (join1,join2) => new object[] {JoinType.Left,join1.UserNo==join2.UserNo}</param> 
        /// <param name="selectExpression">返回表达式 (s1, s2) => new { Id =s1.UserNo, Id1 = s2.UserNo}</param>
        /// <param name="whereLambda">查询表达式 (w1, w2) =>w1.UserNo == "")</param> 
        /// <returns>值</returns>
        public async Task<List<TResult>> QueryMuch<T, T2,  TResult>(
            Expression<Func<T, T2, object[]>> joinExpression,
            Expression<Func<T, T2, TResult>> selectExpression) where T : class, new()
        {
            if (selectExpression == null)
            {
                var list = await Task.Run(() => db.Queryable(joinExpression).Select<TResult>()
              .Select<TResult>()
              .ToList());
                return list;
            }
            return await Task.Run(() => db.Queryable(joinExpression).Select(selectExpression).ToList());
                
        }
        public async Task<PageModel<TResult>> QueryMuch<T, T2, TResult>(
           Expression<Func<T, T2,  object[]>> joinExpression,
            Expression<Func<T, T2, TResult>> selectExpression, int intPageIndex = 0, int intPageSize = 20,
            Expression<Func<T, T2, bool>> whereLambda = null) where T : class, new()
        {
            RefAsync<int> totalCount = 0;
            var list = await db.Queryable(joinExpression).Select(selectExpression)
                .Select<TResult>()
                .ToPageListAsync(intPageIndex, intPageSize, totalCount);
            if (whereLambda != null)
            {
                list = await db.Queryable(joinExpression).Where(whereLambda).Select(selectExpression)
                .Select<TResult>()
                .ToPageListAsync(intPageIndex, intPageSize, totalCount);
            }
            int pageCount = (Math.Ceiling(totalCount.ObjToDecimal() / intPageSize.ObjToDecimal())).ObjToInt();
            return new PageModel<TResult>() { dataCount = totalCount, pageCount = pageCount, page = intPageIndex, PageSize = intPageSize, data = list };
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
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <returns>值</returns>
        public List<TResult> QueryMuch<T, T2, T3, TResult>(
            Expression<Func<T, T2, T3, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20) where T : class, new()
        {
            return db.Queryable(joinExpression)
                .Select<TResult>()
                .ToPageList(intPageIndex, intPageSize);
        }
        public async Task<List<TResult>> QueryMuch<T, T2, T3, TResult>(
            Expression<Func<T, T2, T3, object[]>> joinExpression) where T : class, new()
        {
            var list = await Task.Run(() => db.Queryable(joinExpression).Select<TResult>()
               .Select<TResult>()
               .ToList());
            return list;
        }
        public async Task<PageModel<TResult>> QueryMuch<T, T2, T3, TResult>(
           Expression<Func<T, T2, T3, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20,
            Expression<Func<T, T2, T3, bool>> whereLambda = null) where T : class, new()
        {
            RefAsync<int> totalCount = 0;
            var list = await db.Queryable(joinExpression).Select<TResult>()
                .Select<TResult>()
                .ToPageListAsync(intPageIndex, intPageSize, totalCount);
            if (whereLambda != null)
            {
                list = await db.Queryable(joinExpression).Where(whereLambda).Select<TResult>()
                .Select<TResult>()
                .ToPageListAsync(intPageIndex, intPageSize, totalCount);
            }
            int pageCount = (Math.Ceiling(totalCount.ObjToDecimal() / intPageSize.ObjToDecimal())).ObjToInt();
            return new PageModel<TResult>() { dataCount = totalCount, pageCount = pageCount, page = intPageIndex, PageSize = intPageSize, data = list };
        }
        public async Task<PageModel<TResult>> QueryMuch<T, T2, T3, T4, TResult>(
            Expression<Func<T, T2, T3, T4, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20,
            Expression<Func<T, T2, T3, T4, bool>> whereLambda = null) where T : class, new()
        {
             RefAsync<int> totalCount = 0;
            var list= await db.Queryable(joinExpression).Select<TResult>()
                .Select<TResult>()
                .ToPageListAsync(intPageIndex, intPageSize, totalCount);
            if (whereLambda != null)
            {
                list = await db.Queryable(joinExpression).Where(whereLambda).Select<TResult>()
                .Select<TResult>()
                .ToPageListAsync(intPageIndex, intPageSize, totalCount);
            }
            int pageCount = (Math.Ceiling(totalCount.ObjToDecimal() / intPageSize.ObjToDecimal())).ObjToInt();
            return new PageModel<TResult>() { dataCount = totalCount, pageCount = pageCount, page = intPageIndex, PageSize = intPageSize, data = list };
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
        //public List<TResult> QueryMuch<T, T2, T3, T4, T5, TResult>(
        //    Expression<Func<T, T2, T3, T4, T5, object[]>> joinExpression,
        //    Expression<Func<T, T2, T3, T4, T5, TResult>> selectExpression,
        //    Expression<Func<T, T2, T3, T4, T5, bool>> whereLambda = null) where T : class, new()
        //{
        //    if (whereLambda == null)
        //    {
        //        return db.Queryable(joinExpression).Select(selectExpression).ToList();
        //    }
        //    return db.Queryable(joinExpression).Where(whereLambda).Select(selectExpression).ToList();
        //}

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
        public async Task<PageModel<TResult>> QueryMuch<T, T2, T3, T4, T5, TResult>(
            Expression<Func<T, T2, T3, T4, T5, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20) where T : class, new()
        {
            RefAsync<int> totalCount = 0;
            var list = await db.Queryable(joinExpression).Select<TResult>()
                .Select<TResult>()
                .ToPageListAsync(intPageIndex, intPageSize, totalCount);
            int pageCount = (Math.Ceiling(totalCount.ObjToDecimal() / intPageSize.ObjToDecimal())).ObjToInt();
            return new PageModel<TResult>() { dataCount = totalCount, pageCount = pageCount, page = intPageIndex, PageSize = intPageSize, data = list };
        }

        public async Task<PageModel<TResult>> QueryMuch<T, T2, T3, T4, T5, T6, T7, T8, TResult>(
            Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20,
            Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, bool>> whereLambda = null) where T : class, new()
        {
            RefAsync<int> totalCount = 0;
            var list = await db.Queryable(joinExpression).Select<TResult>()
                .Select<TResult>()
                .ToPageListAsync(intPageIndex, intPageSize, totalCount);
            if (whereLambda != null)
            {
                list = await db.Queryable(joinExpression).Where(whereLambda).Select<TResult>()
                .Select<TResult>()
                .ToPageListAsync(intPageIndex, intPageSize, totalCount);
            }
            int pageCount = (Math.Ceiling(totalCount.ObjToDecimal() / intPageSize.ObjToDecimal())).ObjToInt();
            return new PageModel<TResult>() { dataCount = totalCount, pageCount = pageCount, page = intPageIndex, PageSize = intPageSize, data = list };
        }

        public async Task<List<TResult>> QueryMuch<T, T2, T3, T4, T5, T6, T7, T8, TResult>(
            Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object[]>> joinExpression,
            Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, bool>> whereLambda = null) where T : class, new()
        {
            RefAsync<int> totalCount = 0;
            //return await Task.Run(() => db.Queryable(joinExpression).Select(selectExpression).ToList());
            var list = await Task.Run(() => db.Queryable(joinExpression).Select<TResult>()
                .Select<TResult>()
                .ToList());
            if (whereLambda != null)
            {
                list = await Task.Run(() => db.Queryable(joinExpression).Where(whereLambda).Select<TResult>()
                .Select<TResult>()
                .ToList());
            }

            return list;
        }
        public async Task<PageModel<TResult>> QueryMuch<T, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
    Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20,
    Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, bool>> whereLambda = null) where T : class, new()
        {
            RefAsync<int> totalCount = 0;
            var list = await db.Queryable(joinExpression).Select<TResult>()
                .Select<TResult>()
                .ToPageListAsync(intPageIndex, intPageSize, totalCount);
            if (whereLambda != null)
            {
                list = await db.Queryable(joinExpression).Where(whereLambda).Select<TResult>()
                .Select<TResult>()
                .ToPageListAsync(intPageIndex, intPageSize, totalCount);
            }
            int pageCount = (Math.Ceiling(totalCount.ObjToDecimal() / intPageSize.ObjToDecimal())).ObjToInt();
            return new PageModel<TResult>() { dataCount = totalCount, pageCount = pageCount, page = intPageIndex, PageSize = intPageSize, data = list };
        }

        public async Task<List<TResult>> QueryMuch<T, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object[]>> joinExpression,
            Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, bool>> whereLambda = null) where T : class, new()
        {
            RefAsync<int> totalCount = 0;
            //return await Task.Run(() => db.Queryable(joinExpression).Select(selectExpression).ToList());
            var list = await Task.Run(() => db.Queryable(joinExpression).Select<TResult>()
                .Select<TResult>()
                .ToList());
            if (whereLambda != null)
            {
                list = await Task.Run(() => db.Queryable(joinExpression).Where(whereLambda).Select<TResult>()
                .Select<TResult>()
                .ToList());
            }

            return list;
        }

    }

}
