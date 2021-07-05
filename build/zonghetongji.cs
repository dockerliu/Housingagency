using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace build
{
    public partial class zonghetongji : Form
    {
        public zonghetongji()
        {
            InitializeComponent();
        }
        Database data = new Database();
        string nod1, nod2;
        DateTime startTime, endTime;
        private void zonghetongji_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddDays(-30);
            dateTimePicker2.Value = DateTime.Now.AddDays(1);
            treeView1.ExpandAll();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                startTime = this.dateTimePicker1.Value;
                endTime = this.dateTimePicker2.Value;
                nod1 = treeView1.SelectedNode.ToString();
                nod2 = nod1.Substring(10, 4);
                switch (nod2)
                {
                    case "房屋来源":
                        dataGridView1.DataSource = this.fwlyCount(startTime, endTime);
                        break;
                    case "房源状态":
                        dataGridView1.DataSource = this.fyztCount(startTime, endTime);
                        break;
                    case "物业用途":
                        dataGridView1.DataSource = this.wyytCount(startTime, endTime);
                        break;
                    case "物业类别":
                        dataGridView1.DataSource = this.wylbCount(startTime, endTime);
                        break;
                    case "所处区域":
                        dataGridView1.DataSource = this.scqyCount(startTime, endTime);
                        break;
                    case "出租出售":
                        dataGridView1.DataSource = this.czcsCount(startTime, endTime);
                        break;
                    case "客户来源":
                        dataGridView1.DataSource = this.khlyCount(startTime, endTime);
                        break;
                    case "客户状态":
                        dataGridView1.DataSource = this.khztCount(startTime, endTime);
                        break;
                    case "需求用途":
                        dataGridView1.DataSource = this.xqytCount(startTime, endTime);
                        break;
                    case "需求类别":
                        dataGridView1.DataSource = this.xqlbCount(startTime, endTime);
                        break;
                    case "需求区域":
                        dataGridView1.DataSource = this.xqqyCount(startTime, endTime);
                        break;
                    case "求租求购":
                        dataGridView1.DataSource = this.qzqgCount(startTime, endTime);
                        break;
                    case "房源数量":
                        dataGridView1.DataSource = this.fyslCount(startTime, endTime);
                        break;
                    case "客源数量":
                        dataGridView1.DataSource = this.kyslCount(startTime, endTime);
                        break;
                    case "成交数量":
                        dataGridView1.DataSource = this.cjslCount(startTime, endTime);
                        break;
                    case "日增房源":
                        dataGridView1.DataSource = this.rzfyCount(startTime, endTime);
                        break;
                    case "月增房源":
                        dataGridView1.DataSource = this.yzfyCount(startTime, endTime);
                        break;
                    case "日增客源":
                        dataGridView1.DataSource = this.rzkyCount(startTime, endTime);
                        break;
                    case "月增客源":
                        dataGridView1.DataSource = this.yzkyCount(startTime, endTime);
                        break;
                    case "日营业额":
                        dataGridView1.DataSource = this.ryyeCount(startTime, endTime);
                        break;
                    case "月营业额":
                        dataGridView1.DataSource = this.yyyeCount(startTime, endTime);
                        break;
                    default:
                        return;
                }
            }
            catch
            {

            }
        }
        #region 综合统计
        public DataTable fwlyCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select  laiyuan as 房屋来源   ,count(*)as  数量 from fangyuan where date>=@startTime and date<=@endTime group by laiyuan ";
            return data.Query(str, para);
        }
        public DataTable fyztCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select zhuangtai as 房源状态,count(*) as 数量 from fangyuan where date>=@startTime and date<=@endTime group by zhuangtai ";
            return data.Query(str, para);
        }
        public DataTable wyytCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select yongtu as 物业用途,count(*) as 数量 from fangyuan where date>=@startTime and date<=@endTime group by yongtu ";
            return data.Query(str, para);
        }
        public DataTable wylbCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select wuye_type as 物业类别,count(*) as 数量 from fangyuan where date>=@startTime and date<=@endTime group by wuye_type ";
            return data.Query(str, para);
        }
        public DataTable scqyCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select area as 所处区域,count(*) as 数量 from fangyuan where date>=@startTime and date<=@endTime group by area ";
            return data.Query(str, para);
        }
        public DataTable czcsCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select case when lend='1' then'出售' when lend='0' then '出租' end as 出租出售,count(*) as 数量 from fangyuan where date>=@startTime and date<=@endTime group by lend ";
            return data.Query(str, para);
        }
        public DataTable khlyCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select laiyuan as 客户来源,count(*) as 数量 from fangyuan  where date>=@startTime and date<=@endTime group by laiyuan ";
            return data.Query(str, para);
        }
        public DataTable khztCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select zhuangtai as 客户状态,count(*) as 数量 from fangyuan  where date>=@startTime and date<=@endTime group by zhuangtai ";
            return data.Query(str, para);
        }
        public DataTable xqytCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select yongtu as 需求用途,count(*) as 数量 from fangyuan  where date>=@startTime and date<=@endTime group by yongtu ";
            return data.Query(str, para);
        }
        public DataTable xqlbCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select wuye_type as 需求类别,count(*) as 数量 from fangyuan  where date>=@startTime and date<=@endTime group by wuye_type ";
            return data.Query(str, para);
        }
        public DataTable xqqyCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select area as 需求区域,count(*) as 数量 from fangyuan  where date>=@startTime and date<=@endTime group by area ";
            return data.Query(str, para);
        }
        public DataTable qzqgCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select  case when sell='1' then'求购' when sell='0' then '求租' end as 求租求购, count(*) as 数量 from fangyuan where date>=@startTime and date<=@endTime group by sell  ";
            return data.Query(str, para);
        }
        public DataTable fyslCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select yezhu_name as 员工编号,case when lend='1' then'出售' when lend='0' then '出租' end as 租售状态,count(*) as 房源数量 from fangyuan where date>=@startTime and date<=@endTime group by lend,yezhu_name  ";
            return data.Query(str, para);
        }
        public DataTable kyslCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select yezhu_name as 员工编号,case when lend='1' then'出售' when lend='0' then '出租' end as 租售状态,count(*) as 房源数量 from fangyuan where date>=@startTime and date<=@endTime group by lend,yezhu_name  ";
            return data.Query(str, para);
        }
        public DataTable cjslCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "SELECT     dbo.fangyuan.yezhu_name as 员工编号, case when dbo.fangyuan.Lend='1' then'出售' when lend='0' then '出租' end as 租售状态,count(*) as 成交数量 FROM         dbo.fangyuan INNER JOIN dbo.QyKhNews ON dbo.fangyuan.bianhao = dbo.QyKhNews.fnumber  where date>=@startTime and date<=@endTime group by lend,yezhu_name  ";
            return data.Query(str, para);
        }
        public DataTable rzfyCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select convert(varchar(10),date,121) as 登记日期, count(*) as 数量 from fangyuan where date>=@startTime and date<=@endTime group by day(date),date  ";
            return data.Query(str, para);
        }
        public DataTable yzfyCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select convert(varchar,year(date))+'年'+convert(varchar,month(date))+'月' as 登记日期 ,count(*) as 数量 from fangyuan  where date>=@startTime and date<=@endTime group by month(date),year(date) ";
            return data.Query(str, para);
        }
        public DataTable rzkyCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select convert(varchar(10),date,121) as 登记日期, count(*) as 数量 from fangyuan where date>=@startTime and date<=@endTime group by day(date),date  ";
            return data.Query(str, para);
        }
        public DataTable yzkyCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select convert(varchar,year(date))+'年'+convert(varchar,month(date))+'月' as 登记日期 ,count(*) as 数量 from fangyuan  where date>=@startTime and date<=@endTime group by month(date),year(date) ";
            return data.Query(str, para);
        }
        public DataTable ryyeCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select convert(varchar(10),qy_date,120) as 日期,sum(convert(money,all_money)) as '金额(元)' from htnews   where qy_date>=@startTime and qy_date<=@endTime group by convert(varchar(10),qy_date,120) ";
            return data.Query(str, para);
        }
        public DataTable yyyeCount(DateTime startTime, DateTime endTime)
        {
            SqlParameter[] para ={ 
                                  data.MakeInParam("@startTime",SqlDbType.DateTime,startTime),
                                  data.MakeInParam("@endTime",SqlDbType.DateTime,endTime)
            };
            string str = "select convert(varchar,year(qy_date))+'年'+convert(varchar,month(qy_date))+'月' as 月份,sum(convert(money,all_money)) as '金额(元)' from htnews  where qy_date>=@startTime and qy_date<=@endTime group by month(qy_date),year(qy_date) ";
            return data.Query(str, para);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //数据导出到EXCEL文件
        }

    }
}
