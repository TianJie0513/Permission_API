using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;


namespace IRepository
{
    public interface IRepostirySQLDB<T> where T : class, new()
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageIndex">分页的index</param>
        /// <param name="pageSize">size</param>
        /// <param name="expression">lamda表达式可以通过参数传入 1,2,43 s=>s.id==id</param>
        /// <returns></returns>
        List<T> Query();
        /// <summary>
        ///单个详情的查看
        /// </summary>
        /// <param name="expression">lamda表达式</param>
        /// <returns></returns>
        T FirstOrDefault(Expression<Func<T, bool>> expression);
        int ExecuteCommand(T models);
        int ExcuteProc(string procName, SqlParameter[] parameters);
        List<TResult> ExcuteSpQuery<TResult>(string procName, SqlParameter[] parameters) where TResult:class,new();

    }
}
