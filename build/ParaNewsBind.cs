using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace build
{
    class ParaNewsBind
    {
        Database data = new Database();
        public DataTable fwlySelect() //房屋来源
        {
            string str = "select f_laiyuan as 名称 from f_laiyuan";
            return data.Query(str);
        }
        public DataTable fwlySelect2(string XName) //房屋来源 修改
        {
            SqlParameter[] para ={
                                  data.MakeInParam ("@XName",SqlDbType.VarChar,XName),
                                  };
            string str = "select f_laiyuan as 名称 from f_laiyuan where f_laiyuan=@XName ";
            return data.Query(str, para);
        }
        public DataTable fyztSelect() //房源状态
        {
            string str = "select f_sta as 名称 from f_sta";
            return data.Query(str);
        }
        public DataTable fyztSelect2(string XName) //房源状态 修改
        {
            SqlParameter[] para ={
                                  data.MakeInParam ("@XName",SqlDbType.VarChar,XName),
                                  };
            string str = "select f_sta as 名称 from f_sta where f_sta=@XName ";
            return data.Query(str, para);

        }
        public DataTable wyytSelect() //物业用途
        {
            string str = "select f_yongtu as 名称 from f_yongtu";
            return data.Query(str);
        }

        public DataTable wyytSelect2(string XName) //物业用途 修改
        {
            SqlParameter[] para ={
                                  data.MakeInParam ("@XName",SqlDbType.VarChar,XName),
                                  };
            string str = "select f_yongtu as 名称 from f_yongtu where f_yongtu=@XName";
            return data.Query(str, para);
        }

        public DataTable wylbSelect() //物业类别
        {
            string str = "select f_wuye as 名称 from f_wuye";
            return data.Query(str);
        }

        public DataTable wylbSelect2(string XName) //物业类别
        {
            SqlParameter[] para ={
                                  data.MakeInParam ("@XName",SqlDbType.VarChar,XName),
                                  };
            string str = "select f_wuye as 名称 from f_wuye where f_wuye=@XName";
            return data.Query(str, para);
        }

        public DataTable zxcdSelect() //装修程度
        {
            string str = "select f_zhuangxiu as 名称 from f_zhuangxiu";
            return data.Query(str);
        }

        public DataTable zxcdSelect2(string XName) //装修程度
        {
            SqlParameter[] para ={
                                  data.MakeInParam ("@XName",SqlDbType.VarChar,XName),
                                  };
            string str = "select f_zhuangxiu as 名称 from f_zhuangxiu where f_zhuangxiu=@XName";
            return data.Query(str, para);
        }

        public DataTable scqySelect() //所处区域
        {
            string str = "select area as 名称 from area";
            return data.Query(str);
        }

        public DataTable scqySelect2(string XName) //所处区域
        {
            SqlParameter[] para ={
                                  data.MakeInParam ("@XName",SqlDbType.VarChar,XName),
                                  };
            string str = "select area as 名称 from area where area=@XName";
            return data.Query(str, para);
        }

        public DataTable fwlxSelect() //房屋类型
        {
            string str = "select f_leixing as 名称 from f_leixing";
            return data.Query(str);
        }

        public DataTable fwlxSelect2(string XName) //房屋类型
        {
            SqlParameter[] para ={
                                  data.MakeInParam ("@XName",SqlDbType.VarChar,XName),
                                  };
            string str = "select f_leixing as 名称 from f_leixing where f_leixing=@XName";
            return data.Query(str, para);
        }

        public DataTable ptssSelect() //配套设施
        {
            string str = "select f_peitao as 名称 from f_peitao";
            return data.Query(str);
        }

        public DataTable ptssSelect2(string XName) //配套设施
        {
            SqlParameter[] para ={
                                  data.MakeInParam ("@XName",SqlDbType.VarChar,XName),
                                  };
            string str = "select f_peitao as 名称 from f_peitao where f_peitao=@XName";
            return data.Query(str, para);
        }

        public DataTable khztSelect() //客户状态
        {
            string str = "select f_kehu as 名称 from f_kehu";
            return data.Query(str);
        }

        public DataTable khztSelect2(string XName) //客户状态
        {
            SqlParameter[] para ={
                                  data.MakeInParam ("@XName",SqlDbType.VarChar,XName),
                                  };
            string str = "select f_kehu as 名称 from f_kehu where f_kehu=@XName";
            return data.Query(str, para);
        }
        public DataTable gjfsSelect() //跟进方式
        {
            string str = "select f_genjin as 名称 from f_genjin";
            return data.Query(str);
        }

        public DataTable gjfsSelect2(string XName) //跟进方式
        {
            SqlParameter[] para ={
                                  data.MakeInParam ("@XName",SqlDbType.VarChar,XName),
                                  };
            string str = "select f_genjin as 名称 from f_genjin where f_genjin=@XName";
            return data.Query(str, para);
        }

        public DataTable fkfsSelect() //付款方式
        {
            string str = "select f_fukuan as 名称 from f_fukuan";
            return data.Query(str);
        }

        public DataTable fkfsSelect2(string XName) //付款方式
        {
            SqlParameter[] para ={
                                  data.MakeInParam ("@XName",SqlDbType.VarChar,XName),
                                  };
            string str = "select f_fukuan as 名称 from f_fukuan where f_fukuan=@XName";
            return data.Query(str, para);
        }

        public DataTable fcsmSelect() //分成说明
        {
            string str = "select f_fencheng as 名称 from f_fencheng";
            return data.Query(str);
        }

        public DataTable fcsmSelect2(string XName) //分成说明
        {
            SqlParameter[] para ={
                                  data.MakeInParam ("@XName",SqlDbType.VarChar,XName),
                                  };
            string str = "select f_fencheng as 名称 from f_fencheng where f_fencheng=@XName";
            return data.Query(str, para);
        }




        //插入-------------------------------------------------------------------------------




        public int fwlyInsert(string XName) //房屋来源
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@XName",SqlDbType.VarChar,XName),
            };
            string str = "insert into f_laiyuan (f_laiyuan)values(@XName)";
            return data.RunSql(str, para);
        }
        public int fyztInsert(string XName) //房源状态
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@XName",SqlDbType.VarChar,XName),
            };
            string str = "insert into f_sta (f_sta)values(@XName) ";
            return data.RunSql(str, para);
        }
        public int wyytInsert(string XName) //物业用途
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@XName",SqlDbType.VarChar,XName),
            };
            string str = "insert into f_yongtu (f_yongtu)values(@XName) ";
            return data.RunSql(str, para);
        }
        public int wylbInsert(string XName) //物业类别
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@XName",SqlDbType.VarChar,XName),
            };
            string str = "insert into f_wuye (f_wuye)values(@XName) ";
            return data.RunSql(str, para);
        }
        public int zxcdInsert(string XName) //装修程度
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@XName",SqlDbType.VarChar,XName),
            };
            string str = "insert into f_zhuangxiu (f_zhuangxiu)values(@XName)";
            return data.RunSql(str, para);
        }
        public int scqyInsert(string XName) //所处区域
        {

            SqlParameter[] para ={
                                 data.MakeInParam("@XName",SqlDbType.VarChar,XName),
            };
            string str = "insert into area (area)values(@XName)";
            return data.RunSql(str, para);
        }
        public int fwlxInsert(string XName) //房屋类型
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@XName",SqlDbType.VarChar,XName),
            };
            string str = "insert into f_leixing (f_leixing)values(@XName)";
            return data.RunSql(str, para);
        }
        public int ptssInsert(string XName) //配套设施
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@XName",SqlDbType.VarChar,XName),
            };
            string str = "insert into f_peitao (f_peitao)values(@XName)";
            return data.RunSql(str, para);
        }
        public int khztInsert(string XName) //客户状态
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@XName",SqlDbType.VarChar,XName),
            };
            string str = "insert into f_kehu (f_kehu)values(@XName)";
            return data.RunSql(str, para);
        }
        public int gjfsInsert(string XName) //跟进方式
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@XName",SqlDbType.VarChar,XName),
            };
            string str = "insert into f_genjin (f_genjin)values(@XName)";
            return data.RunSql(str, para);
        }
        public int fkfsInsert(string XName) //付款方式
        {

            SqlParameter[] para ={
                                 data.MakeInParam("@XName",SqlDbType.VarChar,XName),
            };
            string str = "insert into f_fukuan (f_fukuan)values(@XName)";
            return data.RunSql(str, para);
        }
        public int fcsmInsert(string XName) //分成说明
        {

            SqlParameter[] para ={
                                 data.MakeInParam("@XName",SqlDbType.VarChar,XName),
            };
            string str = "insert into f_fencheng (f_fencheng)values(@XName)";
            return data.RunSql(str, para);
        }



        //---------------------------------------------------------------更新
        //X:原名称 Y：目标名称


        public int fwlyUpdate(string X, string Y) //房屋来源 
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 data.MakeInParam("@Y",SqlDbType.VarChar,Y),
            };
            string str = "update f_laiyuan set f_laiyuan=@Y where f_laiyuan=@X";
            return data.RunSql(str, para);
        }

        public int fyztUpdate(string X, string Y) //房源状态
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 data.MakeInParam("@Y",SqlDbType.VarChar,Y),
            };
            string str = "update f_sta set f_sta=@Y where f_sta=@X ";
            return data.RunSql(str, para);
        }

        public int wyytUpdate(string X, string Y) //物业用途
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 data.MakeInParam("@Y",SqlDbType.VarChar,Y),
            };
            string str = "update f_yongtu set f_yongtu=@Y where f_yongtu=@X ";
            return data.RunSql(str, para);
        }

        public int wylbUpdate(string X, string Y) //物业类别
        {

            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 data.MakeInParam("@Y",SqlDbType.VarChar,Y),
            };
            string str = "update f_wuye set f_wuye=@Y where f_wuye=@X";
            return data.RunSql(str, para);
        }

        public int zxcdUpdate(string X, string Y) //装修程度
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 data.MakeInParam("@Y",SqlDbType.VarChar,Y),
            };
            string str = "update f_zhuangxiu set f_zhuangxiu=@Y where f_zhuangxiu=@X";
            return data.RunSql(str, para);
        }

        public int scqyUpdate(string X, string Y) //所处区域
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 data.MakeInParam("@Y",SqlDbType.VarChar,Y),
            };
            string str = "update area set area=@Y where area=@X";
            return data.RunSql(str, para);
        }

        public int fwlxUpdate(string X, string Y) //房屋类型
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 data.MakeInParam("@Y",SqlDbType.VarChar,Y),
            };
            string str = "update f_leixing set f_leixing=@Y where f_leixing=@X";
            return data.RunSql(str, para);
        }

        public int ptssUpdate(string X, string Y) //配套设施
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 data.MakeInParam("@Y",SqlDbType.VarChar,Y),
            };
            string str = "update f_peitao set f_peitao=@Y where f_peitao=@X";
            return data.RunSql(str, para);
        }

        public int khztUpdate(string X, string Y) //客户状态
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 data.MakeInParam("@Y",SqlDbType.VarChar,Y),
            };
            string str = "update f_kehu set f_kehu=@Y where f_kehu=@X";
            return data.RunSql(str, para);
        }

        public int gjfsUpdate(string X, string Y) //跟进方式
        {

            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 data.MakeInParam("@Y",SqlDbType.VarChar,Y),
            };
            string str = "update f_genjin set f_genjin=@Y where f_genjin=@X";
            return data.RunSql(str, para);
        }

        public int fkfsUpdate(string X, string Y) //付款方式
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 data.MakeInParam("@Y",SqlDbType.VarChar,Y),
            };
            string str = "update f_fukuan set f_fukuan=@Y where f_fukuan=@X";
            return data.RunSql(str, para);
        }

        public int fcsmUpdate(string X, string Y) //分成说明
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 data.MakeInParam("@Y",SqlDbType.VarChar,Y),
            };
            string str = "update f_fencheng set f_fencheng=@Y where f_fencheng=@X";
            return data.RunSql(str, para);
        }



        //删除 X:名称 --------------------------------------------------------------------



        public int fwlyDelete(string X) //房屋来源 
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 
            };
            string str = "delete from f_laiyuan  where f_laiyuan=@X";
            return data.RunSql(str, para);
        }

        public int fyztDelete(string X) //房源状态
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 
            };
            string str = "delete from  f_sta  where f_sta=@X ";
            return data.RunSql(str, para);
        }

        public int wyytDelete(string X) //物业用途
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                
            };
            string str = "delete from f_yongtu where f_yongtu=@X ";
            return data.RunSql(str, para);
        }

        public int wylbDelete(string X) //物业类别
        {

            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                
            };
            string str = "delete from f_wuye where f_wuye=@X";
            return data.RunSql(str, para);
        }

        public int zxcdDelete(string X) //装修程度
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 
            };
            string str = "delete from f_zhuangxiu  where f_zhuangxiu=@X";
            return data.RunSql(str, para);
        }

        public int scqyDelete(string X) //所处区域
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                
            };
            string str = "delete from area where area=@X";
            return data.RunSql(str, para);
        }

        public int fwlxDelete(string X) //房屋类型
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                               
            };
            string str = "delete from  f_leixing where f_leixing=@X";
            return data.RunSql(str, para);
        }

        public int ptssDelete(string X) //配套设施
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                
            };
            string str = "delete from  f_peitao where f_peitao=@X";
            return data.RunSql(str, para);
        }

        public int khztDelete(string X) //客户状态
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                
            };
            string str = "delete from f_kuhu  where f_kuhu=@X";
            return data.RunSql(str, para);
        }

        public int gjfsDelete(string X) //跟进方式
        {

            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                
            };
            string str = "delete from f_genjin where f_genjin=@X";
            return data.RunSql(str, para);
        }

        public int fkfsDelete(string X) //付款方式
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                
            };
            string str = "delete from f_fukuan where f_fukuan=@X";
            return data.RunSql(str, para);
        }

        public int fcsmDelete(string X) //分成说明
        {
            SqlParameter[] para ={
                                 data.MakeInParam("@X",SqlDbType.VarChar,X),
                                 
            };
            string str = "delete from f_fencheng where f_fencheng=@X";
            return data.RunSql(str, para);
        }


    }
}
