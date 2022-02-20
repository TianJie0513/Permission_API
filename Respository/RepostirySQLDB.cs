using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sql;
using System.Reflection;

namespace Respository
{
    public class RepostirySQLDB<T> : IRepository.IRepostirySQLDB<T> where T : class, new()
    {
        private readonly MyDBContext.MyDBContext context;
        public RepostirySQLDB(MyDBContext.MyDBContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// 执行添加操作
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int ExecuteCommand(T models)
        {
            context.Set<T>().Add(models);
            return context.SaveChanges();
        }


        /// <summary>
        ///单个详情的查看
        /// </summary>
        /// <param name="expression">lamda表达式</param>
        /// <returns></returns>
        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression).FirstOrDefault();
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageIndex">分页的index</param>
        /// <param name="pageSize">size</param>
        /// <param name="expression">lamda表达式可以通过参数传入</param>
        /// <returns></returns>
        public List<T> Query()
        {
            var list = context.Set<T>().AsQueryable().ToList();
            return list;
        }
        //执行存储过程
        public int ExcuteProc(string procName, SqlParameter[] parameters)
        {
            //首先获取connection
            DbConnection connection = context.Database.GetDbConnection();
            //创建command
            DbCommand cmd = connection.CreateCommand();
            //打开数据库
            connection.Open();
            //这里是我们需要执行的存储过程的名称
            cmd.CommandText = procName;
            //指定执行的是存储过程
            cmd.CommandType = CommandType.StoredProcedure;
            //判断参数不为空添加参数句的数目不匹配。上一计数 = 0，当前
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    DbParameter parameter = cmd.CreateParameter();
                    parameter.Value = item.Value;
                    parameter.ParameterName = item.ParameterName;
                    parameter.DbType = item.DbType;
                    parameter.Size = item.Size;
                    parameter.Direction = item.Direction;
                    cmd.Parameters.Add(parameter);
                }

            }
            //这里就是执行结果
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            return result;
        }
        //执行存储过程
        public List<TResult> ExcuteSpQuery<TResult>(string procName, SqlParameter[] parameters) where TResult:class,new()
        {
            List<TResult> list = new List<TResult>();
            //首先获取connection
            DbConnection connection = context.Database.GetDbConnection();
            //创建command
            DbCommand cmd = connection.CreateCommand();
            //打开数据库
            connection.Open();
            //这里是我们需要执行的存储过程的名称
            cmd.CommandText = procName;
            //指定执行的是存储过程
            cmd.CommandType = CommandType.StoredProcedure;
            //判断参数不为空添加参数句的数目不匹配。上一计数 = 0，当前
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    DbParameter parameter = cmd.CreateParameter();
                    parameter.Value = item.Value;
                    parameter.ParameterName = item.ParameterName;
                    parameter.DbType = item.DbType;
                    parameter.Size = item.Size;
                    parameter.Direction = item.Direction;
                    cmd.Parameters.Add(parameter);
                }
            }
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TResult result = new TResult();
                Type type = result.GetType();
                //type.prop
                //得到了所有的属性集合
                PropertyInfo[] propertyInfo = type.GetProperties(); 
                for (int i = 1; i < reader.FieldCount; i++)
                {
                    foreach (var info in propertyInfo)
                    {
                        if (info.Name == reader.GetName(i))
                        {
                            if (info.PropertyType.Name.ToLower() == "int")
                                info.SetValue(result, reader.GetInt32(i));
                            if (info.PropertyType.Name.ToLower() == "string")
                                info.SetValue(result, reader.GetString(i));
                            if (info.PropertyType.Name.ToLower() == "bool")
                                info.SetValue(result, reader.GetBoolean(i));
                        }
                    }
                }
                list.Add(result);
            }
            connection.Close();
            return list;
        }
    }
}
