using Tuby.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tuby.Api.IRepository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        Task<TEntity> QueryByID(object objId);
        Task<TEntity> QueryByID(object objId, bool blnUseCache = false);
        Task<List<TEntity>> QueryByIDs(object[] lstIds);

        Task<int> Add(TEntity model);

        Task<int> AddList(List<TEntity> list);

        Task<bool> DeleteById(object id);
        Task<bool> DeleteValue(Expression<Func<TEntity, bool>> whereExpression);

        Task<bool> Delete(TEntity model);

        Task<bool> DeleteByIds(object[] ids);

        Task<bool> Update(TEntity model);
        Task<bool> Update(TEntity entity, string strWhere);
        Task<bool> Update(TEntity entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "");

        Task<List<TEntity>> Query();
        Task<List<TEntity>> Query(string strWhere);
        Task<List<string>> QueryField(Expression<Func<TEntity, string>> selectExpression);
        Task<List<object>> QueryField(Expression<Func<TEntity, object>> selectExpression);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);
        Task<List<TEntity>> Query(string strWhere, string strOrderByFileds);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds);
        Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds);
        Task<PageModel<TEntity>> Query(
            Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds);
        Task<PageModel<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds);
        Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null);
        Task<List<TResult>> QueryMuch<T, T2, TResult>(
          Expression<Func<T, T2,object[]>> joinExpression,
            Expression<Func<T, T2,TResult>> selectExpression) where T : class, new();
        Task<PageModel<TResult>> QueryMuch<T, T2, TResult>(
          Expression<Func<T, T2, object[]>> joinExpression,
            Expression<Func<T, T2, TResult>> selectExpression, int intPageIndex = 0, int intPageSize = 20,
           Expression<Func<T, T2, bool>> whereLambda = null) where T : class, new();
        List<TResult> QueryMuch<T, T2, T3, TResult>(
           Expression<Func<T, T2, T3, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20) where T : class, new();
        Task<List<TResult>> QueryMuch<T, T2, T3, TResult>(
            Expression<Func<T, T2, T3, object[]>> joinExpression) where T : class, new();
        Task<PageModel<TResult>> QueryMuch<T, T2, T3, TResult>(
           Expression<Func<T, T2, T3, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20,
            Expression<Func<T, T2, T3, bool>> whereLambda = null) where T : class, new();
        Task<PageModel<TResult>> QueryMuch<T, T2, T3, T4, TResult>(
           Expression<Func<T, T2, T3, T4, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20,
            Expression<Func<T, T2, T3, T4, bool>> whereLambda = null) where T : class, new();

        //List<TResult> QueryMuch<T, T2, T3, T4, T5, TResult>(
        //   Expression<Func<T, T2, T3, T4, T5, object[]>> joinExpression,
        //   Expression<Func<T, T2, T3, T4, T5, TResult>> selectExpression,
        //   Expression<Func<T, T2, T3, T4, T5, bool>> whereLambda = null) where T : class, new();
        Task<PageModel<TResult>> QueryMuch<T, T2, T3, T4, T5, TResult>(
           Expression<Func<T, T2, T3, T4, T5, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20) where T : class, new();

        Task<PageModel<TResult>> QueryMuch<T, T2, T3, T4, T5, T6, T7, T8, TResult>(
           Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20,
           Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, bool>> whereLambda = null) where T : class, new();
        Task<List<TResult>> QueryMuch<T, T2, T3, T4, T5, T6, T7, T8, TResult>(
           Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object[]>> joinExpression,
           Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, bool>> whereLambda = null) where T : class, new();
        Task<PageModel<TResult>> QueryMuch<T, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
           Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object[]>> joinExpression, int intPageIndex = 0, int intPageSize = 20,
           Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, bool>> whereLambda = null) where T : class, new();
        Task<List<TResult>> QueryMuch<T, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
           Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object[]>> joinExpression,
           Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, bool>> whereLambda = null) where T : class, new();
    }
}
