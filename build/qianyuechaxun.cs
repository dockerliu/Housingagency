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
    public partial class qianyuechaxun : Form
    {
        public qianyuechaxun()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void qianyuechaxun_Load(object sender, EventArgs e)
        {
            string sql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称, huxing as 户型结构,mianji as 建筑面积, area as 所在区域, z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份, address as 具体地址 from fangyuan order by bianhao ";
            DataTable da = data.Query(sql);
            this.dataGridView2.DataSource = da;
            da.Dispose();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = this.dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();

            string strSql = "select * from fangyuan where bianhao='" + str + "'";
            DataTable dt = data.Query(strSql);
            foreach (DataRow dr in dt.Rows)
            {
                #region 绑定房源详细信息
                string Lend = dr["Lend"].ToString();
                if (Lend == "0")
                {
                    checkBox4.Checked = false;
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    checkBox4.Checked = true;
                    textBox3.Text = dr["lend_price"].ToString();
                    textBox4.Text = dr["lend_shuoming"].ToString();
                }
                string Sale = dr["sell"].ToString();
                if (Sale == "0")
                {
                    checkBox5.Checked = false;
                    textBox5.Text = "";
                    textBox6.Text = "";
                }
                else
                {
                    checkBox5.Checked = true;
                    textBox5.Text = dr["sell_price"].ToString();
                    textBox6.Text = dr["sell_shuoming"].ToString();
                }
                if (Lend == "1" && Sale == "1")
                {
                    checkBox4.Checked = true;
                    checkBox5.Checked = true;
                    textBox3.Text = dr["Lend_Price"].ToString();
                    textBox4.Text = dr["lend_shuoming"].ToString();
                    textBox5.Text = dr["sell_price"].ToString();
                    textBox6.Text = dr["sell_shuoming"].ToString();
                }
                textBox7.Text = dr["zhuangtai"].ToString();
                textBox8.Text = dr["guwen"].ToString();
                textBox9.Text = dr["jiancheng"].ToString();
                textBox10.Text = dr["wuye"].ToString();
                textBox11.Text = dr["yongtu"].ToString();
                textBox12.Text = dr["wuye_type"].ToString();
                textBox13.Text = dr["area"].ToString();
                textBox14.Text = dr["chengdu"].ToString();
                textBox15.Text = dr["fang_type"].ToString();
                textBox16.Text = dr["huxing"].ToString();
                textBox17.Text = dr["mianji"].ToString();
                string LayerNumber = dr["z_floor"].ToString();
                string Stand = dr["n_floor"].ToString();
                textBox18.Text = Stand + "/" + LayerNumber;
                textBox19.Text = dr["jichusheshi"].ToString();
                textBox20.Text = dr["peitaosheshi"].ToString();
                textBox21.Text = dr["Address"].ToString();
                textBox22.Text = dr["xiangxi"].ToString();
                textBox23.Text = dr["yezhu_name"].ToString();
                textBox24.Text = dr["tele"].ToString();
                textBox25.Text = dr["MobliePhone"].ToString();
                textBox26.Text = dr["yezhu_address"].ToString();
                textBox27.Text = dr["beizhu"].ToString();
                #endregion
                string area = dr["area"].ToString();

                string address = dr["address"].ToString();


                string sql_a = "select f_genjin as 跟进方式,genjinren as 跟进人,genjin_time as 跟进时间,neirong as 内容 from f_genjin_fy where bianhao='" + str + "'";
                SqlParameter[] par = {
                                          data.MakeInParam("@area",SqlDbType.VarChar,area),
                  
                   data.MakeInParam("@address",SqlDbType.VarChar,address),

                                      };

                DataTable dtb = data.Query(sql_a, par);
                this.dataGridView1.DataSource = dtb;
            }
        }
        //房屋出租签约查询
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

            string sql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称, huxing as 户型结构,mianji as 建筑面积, area as 所在区域, z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份, address as 具体地址 from fangyuan  where  date>='" + dateTimePicker1.Value + "' and date<='" + dateTimePicker2.Value + "' and ";

            if (checkBox6.Checked == true && checkBox7.Checked == false)
            {
                sql = sql + "lend='1'";


            }
            else
            {
                sql = sql + "sell='1'";

            }
            if (checkBox6.Checked == false && checkBox7.Checked == false)
            {
                sql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称, huxing as 户型结构,mianji as 建筑面积, area as 所在区域, z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份, address as 具体地址 from fangyuan  where  date>='" + dateTimePicker1.Value + "' and date<='" + dateTimePicker2.Value + "' ";

            }
            DataTable da = data.Query(sql);
            this.dataGridView2.DataSource = da;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称, huxing as 户型结构,mianji as 建筑面积, area as 所在区域, z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份, address as 具体地址 from fangyuan  where  date>='" + dateTimePicker1.Value + "' and date<='" + dateTimePicker2.Value + "' and ";

            if (checkBox7.Checked == true && checkBox6.Checked == false)
            {
                sql = sql + "sell='1'";


            }
            else
            {
                sql = sql + "lend='1'";

            }
            if (checkBox6.Checked == false && checkBox7.Checked == false)
            {
                sql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称, huxing as 户型结构,mianji as 建筑面积, area as 所在区域, z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份, address as 具体地址 from fangyuan  where  date>='" + dateTimePicker1.Value + "' and date<='" + dateTimePicker2.Value + "' ";

            }

            DataTable da = data.Query(sql);
            this.dataGridView2.DataSource = da;
        }
    }
}
