using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace build
{
   public class Database
    {
       public SqlConnection getConnection()
       {
           return new SqlConnection("server=.;uid=home;pwd=;database=build");
       }
       SqlConnection con = null;
       /// <summary>
       /// 执行SQL语句
       /// </summary>
       /// <param name="sql">SQL语句</param>
       /// <returns>返回一个具体值</returns>
       public object QueryScalar(string sql)
       {
           Open();//打开数据连接
           object result = null;
           try
           {
               using(SqlCommand cmd=new SqlCommand(sql,con))
               {
                   result = cmd.ExecuteScalar();
                   return result;
               }
           }
           catch
           {
               return null;
           }

       }
       /// <summary>
       /// 执行SQL语句
       /// </summary>
       /// <param name="sql">要执行的SQL语句</param>
       /// <param name="prams">参数</param>
       /// <returns></returns>
       public object QueryScalar(string sql,SqlParameter[]prams)
       {
           Open();
           object result = null;
           try
           {
               using (SqlCommand cmd = CreateCommandSql(sql, prams))
               {
                   result = cmd.ExecuteScalar();
                   return result;
               }
           }
           catch
           {
               return null;
           }
       }
       /// <summary>
       /// 创建一个Sqlcommand对象，用来构建SQL语句
       /// </summary>
       /// <param name="sql">sql语句</param>
       /// <param name="prams">sql所需要的参数</param>
       /// <returns></returns>
       public SqlCommand CreateCommandSql(string sql, SqlParameter[] prams)
       {
           Open();
           SqlCommand cmd = new SqlCommand(sql,con);
           if (prams != null)
           {
               foreach (SqlParameter parameter in prams)
               {
                   cmd.Parameters.Add(parameter);
               }
           }
           return cmd;
       }
       private void Open()
       {
           if (con == null)
           {
               con = new SqlConnection("server=.;uid=home;pwd=;database=build");

           }
           if (con.State == ConnectionState.Closed)
           {
               con.Open();
           }
       }
       /// <summary>
       /// 要执行SQL语句，该方法返回一个DataTable
       /// </summary>
       /// <param name="sql">执行SQL语句</param>
       /// <returns></returns>
       public DataTable Query(string sql)
       {
           Open();
           using (SqlDataAdapter sqlda = new SqlDataAdapter(sql, con))
           {
               using (DataTable dt = new DataTable())
               {
                   sqlda.Fill(dt);
                   return dt;
               }
           }

       }
       /// <summary>
       /// 执行SQL语句，返回DataTable
       /// </summary>
       /// <param name="sql">要执行的SQL语句</param>
       /// <param name="prams">构建SQL语句所需要的参数</param>
       /// <returns></returns>
       public DataTable Query(string sql,SqlParameter[]prams)
       {
           SqlCommand cmd = CreateCommandSql(sql,prams);
           using (SqlDataAdapter sqldata = new SqlDataAdapter(cmd))
           {
               using (DataTable dt = new DataTable())
               {
                   sqldata.Fill(dt);
                   return dt;
               }
           }
       }
       /// <summary>
       /// 执行SQL语句，返回影响的记录行数
       /// </summary>
       /// <param name="sql">要执行的SQL语句</param>
       /// <returns></returns>
       public int RunSql(string sql)
       {
           int result = -1;
           try
           {
               Open();
               using (SqlCommand cmd = new SqlCommand(sql, con))
               {
                  result= cmd.ExecuteNonQuery();
                  con.Close();
                  return result;
               }
           }
           catch
           {
               return 0;
           }
       }
       /// <summary>
       /// 执行SQL语句，返回影响的记录行数
       /// </summary>
       /// <param name="sql">要执行的SQL语句</param>
       /// <param name="prams">SQL语句所需要的参数</param>
       /// <returns></returns>
       public int RunSql(string sql,SqlParameter[]prams)
       {
           try
           {
               int result = -1;
               SqlCommand cmd = CreateCommandSql(sql, prams);
               result = cmd.ExecuteNonQuery();
               this.Close();
               return result;
           }
           catch
           {
               return 0;
           }

       }
       public void Close()
       {
           if (con != null)
               con.Close();

       }
       /// <summary>
       /// 执行SQL语句，返回一个SqlDataReader
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="dataReader"></param>
       public void RunSql(string sql,out SqlDataReader dataReader)
       {
           SqlCommand cmd = CreateCommandSql(sql,null);
           dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

       }
       public void RunSql(string sql,SqlParameter[]prams,out SqlDataReader dataReader)
       {
           SqlCommand cmd = CreateCommandSql(sql,prams);
           dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
       }
       /// <summary>
       /// 执行存储过程
       /// </summary>
       /// <param name="ProcName">存储过程名称</param>
       /// <returns></returns>
       public int RunProc(string ProcName)
       {
           SqlCommand cmd = CreateCommand(ProcName,null);
           cmd.ExecuteNonQuery();
           this.Close();
           return (int)cmd.Parameters["ReturnValue"].Value; 

       }
       /// <summary>
       /// 执行存储过程
       /// </summary>
       /// <param name="ProcName">要执行的存储过程的名称</param>
       /// <param name="prams">构建存储过程所需要的参数</param>
       /// <returns></returns>
       public int RunProc(string ProcName,SqlParameter[]prams)
       {
           SqlCommand cmd = CreateCommand(ProcName,prams);
           cmd.ExecuteNonQuery();
           this.Close();
           return (int)cmd.Parameters["ReturnValue"].Value;
       }
       /// <summary>
       /// 执行存储过程，返回SqlDataReader
       /// </summary>
       /// <param name="ProcName">存储过程</param>
       /// <param name="dataReader">要返回的SqlDataReader</param>
       public void RunProc(string ProcName,out SqlDataReader dataReader)
       {
           SqlCommand cmd = CreateCommand(ProcName,null);
           dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
       }
       public void RunProc(string ProcName,SqlParameter[]prams,out SqlDataReader dataReader)
       {
           SqlCommand cmd = CreateCommand(ProcName,prams);
           dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
       }
       /// <summary>
       /// 创建一个sqlCommand对象，用来执行存储过程
       /// </summary>
       /// <param name="ProcName">存储过程名称</param>
       /// <param name="prams">构建存储过程所需要的参数</param>
       /// <returns></returns>
       private SqlCommand CreateCommand(string ProcName,SqlParameter[]prams)
       {
           Open();
           SqlCommand cmd = new SqlCommand(ProcName,con);
           cmd.CommandType = CommandType.StoredProcedure;
           if (prams != null)
           {
               foreach (SqlParameter parameter in prams)
               {
                   cmd.Parameters.Add(parameter);
               }

           }
           cmd.Parameters.Add(new SqlParameter("ReturnValue",SqlDbType.Int,4,ParameterDirection.ReturnValue,false,0,0,string.Empty,DataRowVersion.Default,null));
           return cmd;

       }
       /// <summary>
       /// 对DateTime型数据做限制
       /// </summary>
       /// <returns></returns>
       public SqlParameter MakeInParamDate(string ParamName,SqlDbType DbType,int size,DateTime value)
       {
           if (value.ToShortDateString() == "0001-1-1")
           {
               return MakeParam(ParamName, DbType, size, ParameterDirection.Input, System.DBNull.Value);
           }
           else
           {
               return MakeParam(ParamName,DbType,size,ParameterDirection.Input,value);
           }
       }
       public SqlParameter MakeParam(string ParamName,SqlDbType DbType,int size,ParameterDirection Direction,object value)
       {
           SqlParameter Param;
           if (size > 0)
           {
               Param = new SqlParameter(ParamName, DbType, size);
           }
           else
           {
               Param = new SqlParameter(ParamName,DbType);
           }
           Param.Direction = Direction;
           if (!(Direction == ParameterDirection.Output && value == null))
           {
               Param.Value = value;


           }
           return Param;
       }
       /// <summary>
       /// 对String类型数据的限制
       /// </summary>
       /// <returns></returns>
       public SqlParameter MakeInParamStr(string ParamName,SqlDbType Dbtype,int size,string  value)
       {
           if (value == null)
           {
               return MakeParam(ParamName, Dbtype, size, ParameterDirection.Input, System.DBNull.Value);

           }
           else
           {
               return MakeParam(ParamName,Dbtype,size,ParameterDirection.Input,value);
           }
       }
       /// <summary>
       /// 对int,float数据的限制
       /// </summary>
       /// <returns></returns>
       public SqlParameter MakeInParamIntF(string ParamName,SqlDbType DbType,int size,object value)
       {
           if (float.Parse(value.ToString()) == 0)
           {
               return MakeParam(ParamName, DbType, size, ParameterDirection.Input, System.DBNull.Value);
           }
           else
           {
               return MakeParam(ParamName,DbType,size,ParameterDirection.Input,value);
           }
       }
       public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, object value)
       {
           return MakeParam(ParamName, DbType, 0, ParameterDirection.Input, value);
       }
       public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int size, object value)
       {
           return MakeParam(ParamName, DbType, size, ParameterDirection.Input, value);
       }
       public SqlParameter MakeOutParam(string ParamName,SqlDbType DbType,int size)
       {
           return MakeParam(ParamName, DbType, size, ParameterDirection.Output, null);
       }
       public SqlParameter MakeReturnParam(string ParamName, SqlDbType DbType, int size)
       {
           return MakeParam(ParamName,DbType,size,ParameterDirection.ReturnValue,null);
       }

    }
}
