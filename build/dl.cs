using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace build
{
    public class dl
    {
        Database data = new Database();
        public int InsertHandle(sysHandleInfo syshandleInfo)
        {
            string date = DateTime.Now.ToString();
            SqlParameter[] para ={
                                     data.MakeInParam("@HandlePerson",SqlDbType.VarChar,syshandleInfo.HandlePerson),
                                     data.MakeInParam("@HandleContent",SqlDbType.VarChar,syshandleInfo.HandleContent),
                                     data.MakeInParam("@HandleRemark",SqlDbType.VarChar,syshandleInfo.HandleRemark),
                                     data.MakeInParam("@date",SqlDbType.DateTime,date),

                                 };
            string strsql = "insert into rizhi(time,person,concent,remark) values(@date,@HandlePerson,@HandleContent,@HandleRemark)";
            return data.RunSql(strsql, para);
        }

        public  DataTable SeleFollow(string FNumber)
        {
            SqlParameter[] para = { 
                                  
                                  data.MakeInParam("@FNumber",SqlDbType.VarChar,FNumber),
                                
                                  
                                  };
            string strsql = "select genjin_time as 跟进时间,genjinren as 跟进人,f_genjin as 跟进方式,neirong as 跟进内容 from f_genjin_fy where FNumber=@FNumber";
            return data.Query(strsql, para);

        }
    }
}
