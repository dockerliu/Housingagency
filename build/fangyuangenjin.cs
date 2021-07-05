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
    public partial class fangyuangenjin : Form
    {
        public fangyuangenjin()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void fangyuangenjin_Load(object sender, EventArgs e)
        {
            this.checkBox1.Checked = false;
            this.checkBox2.Checked = false;
            this.checkBox3.Checked = false;
            string sql = "select * from qianyue_type";
            DataTable dt = data.Query(sql);
            this.comboBox1.DataSource = dt;
            this.comboBox1.DisplayMember = "qianyue";

            string sql_a = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前的状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积, area as 所在区域,z_floor as 总层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan order by bianhao";
            DataTable da = data.Query(sql_a);
            this.dataGridView1.DataSource = da;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //MessageBox.Show(str);
                string sql_genjin = "select genjin_time as 跟进时间,genjinren as 跟进人,f_genjin as 跟进方式,neirong as 跟进内容 from f_genjin_fy where bianhao='" + str + "'";
                DataTable dd = data.Query(sql_genjin);
                this.dataGridView2.DataSource = dd;
                string strSql = "select * from fangyuan where bianhao='" + str + "'";

                DataTable dt = data.Query(strSql);
                foreach (DataRow dr in dt.Rows)
                {
                    string Lend = dr["Lend"].ToString();
                    if (Lend == "0")
                    {
                        this.checkBox4.Checked = false;
                        this.textBox3.Text = "";
                        this.textBox5.Text = "";
                    }
                    else
                    {
                        this.checkBox4.Checked = true;
                        this.textBox3.Text = dr["lend_price"].ToString();
                        this.textBox5.Text = dr["lend_shuoming"].ToString();
                    }
                    string Sale = dr["sell"].ToString();
                    if (Sale == "0")
                    {
                        this.checkBox5.Checked = false;
                        this.textBox4.Text = "";
                        this.textBox6.Text = "";
                    }
                    else
                    {
                        this.checkBox5.Checked = true;
                        this.textBox4.Text = dr["sell_price"].ToString();
                        this.textBox6.Text = dr["sell_shuoming"].ToString();
                    }
                    if (Lend == "1" && Sale == "1")
                    {
                        this.checkBox4.Checked = true;
                        this.checkBox5.Checked = true;
                        this.textBox3.Text = dr["Lend_Price"].ToString();
                        this.textBox5.Text = dr["lend_shuoming"].ToString();
                        this.textBox4.Text = dr["sell_price"].ToString();
                        this.textBox6.Text = dr["sell_shuoming"].ToString();
                    }

                    this.textBox7.Text = dr["zhuangtai"].ToString();
                    this.textBox8.Text = dr["guwen"].ToString();
                    this.textBox9.Text = dr["jiancheng"].ToString();
                    this.textBox10.Text = dr["wuye"].ToString();
                    this.textBox13.Text = dr["yongtu"].ToString();
                    this.textBox14.Text = dr["wuye_type"].ToString();
                    this.textBox11.Text = dr["area"].ToString();
                    this.textBox15.Text = dr["chengdu"].ToString();
                    this.textBox16.Text = dr["fang_type"].ToString();
                    this.textBox12.Text = dr["huxing"].ToString();
                    this.textBox18.Text = dr["mianji"].ToString();
                    string LayerNumber = dr["z_floor"].ToString();
                    string Stand = dr["n_floor"].ToString();
                    this.textBox17.Text = Stand + "/" + LayerNumber;
                    this.textBox19.Text = dr["jichusheshi"].ToString();
                    this.textBox20.Text = dr["peitaosheshi"].ToString();
                    this.textBox21.Text = dr["address"].ToString();
                    this.textBox22.Text = dr["xiangxi"].ToString();
                    this.textBox23.Text = dr["yezhu_name"].ToString();
                    this.textBox24.Text = dr["tele"].ToString();
                    this.textBox25.Text = dr["MobliePhone"].ToString();
                    this.textBox26.Text = dr["yezhu_address"].ToString();
                    this.textBox27.Text = dr["beizhu"].ToString();


                }

            }
            catch
            {
            }
            finally
            {
                data.Close();
            }
        }
        /// <summary>
        /// 信息查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                string strSql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前的状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积, area as 所在区域,z_floor as 总层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where ";
                if (this.comboBox1.Text == "已签约")
                {
                    strSql = strSql + "zhuangtai='已经成交' and ";
                }
                if (this.comboBox1.Text == "未签约")
                {
                    strSql = strSql + "zhuangtai='正常状态' and ";
                }
                if (checkBox1.Checked == true)
                {
                    strSql = strSql + "Lend='1' and ";
                }
                if (this.checkBox1.Checked == false)
                {
                    strSql = strSql + "(Lend='1' or Lend='0') and ";
                }
                if (this.checkBox2.Checked == true)
                {
                    strSql = strSql + "sell='1' and ";
                }
                if (this.checkBox2.Checked == false)
                {
                    strSql = strSql + "(sell='1' or sell='0') and ";
                }
                if (this.checkBox3.Checked == true)
                {
                    DateTime dateTime = DateTime.Now.Date.AddDays(-Convert.ToInt32(this.textBox2.Text));
                    strSql = strSql + "NowDate<='" + DateTime.Now.Date.AddDays(0.5) + "' and NowDate>='" + dateTime + "' and ";
                }
                if (this.textBox1.Text != "")
                {
                    strSql = strSql + "(bianhao like '%"+this.textBox1.Text+"%')";
                }



                strSql = strSql + "1=1";

                DataTable da = data.Query(strSql);
                this.dataGridView1.DataSource = da;
                this.textBox1.Text = "";
                
            }
            catch
            {
            }
            finally
            {
                data.Close();
            }


        }
        //数据的刷新
        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前的状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积, area as 所在区域,z_floor as 总层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan";
            DataTable dd = data.Query(sql);
            this.dataGridView1.DataSource = dd;

        }
        //删除操作
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            try
            {
                int st = this.dataGridView2.SelectedRows[0].Index;
                DateTime str_1 = Convert.ToDateTime(this.dataGridView2.Rows[st].Cells[0].Value.ToString());
                DialogResult df = MessageBox.Show("确定要删除本条记录吗?","确认删除",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (df == DialogResult.OK)
                {
                    string sql = "delete from f_genjin_fy where genjin_time='"+str_1+"'";
                    int i = data.RunSql(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("删除成功");
                    }
                }

            }
            catch
            {
                MessageBox.Show("数据删除失败");
            }
            finally
            {
                data.Close();
            }
        }
    }
}
