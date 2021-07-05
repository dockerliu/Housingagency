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
    public partial class kehugenjin : Form
    {
        public kehugenjin()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void kehugenjin_Load(object sender, EventArgs e)
        {
            string sql_a = "select bianhao as 客户编号,zhuangtai as 当前状态,yezhu_name as 客户姓名,wuye as 物业姓名,area as 所处区域,wuye_type as 物业类别,yongtu as 物业用途,chengdu as 装修成度,guwen as 置业顾问,address as 具体地址 from kehu order by bianhao desc";
            DataTable dt = data.Query(sql_a);
            this.dataGridView4.DataSource = dt;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (dataGridView4.Rows.Count > 0)
            {
                int index = dataGridView4.CurrentRow.Index;
                string gjbh = dataGridView4.Rows[index].Cells[0].Value.ToString();
                addgenjin addgj = new addgenjin();
                addgj.khid = gjbh;
                addgj.ShowDialog();

            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = this.dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sql_d = "select * from kehu where bianhao='" + str + "'";
                string sql_e = "select genjin_time as 跟进时间,genjinren as 跟进人,f_genjin as 跟进方式,neirong as 跟进内容 from f_genjin_kh where bianhao='" + str + "'";
                DataTable dtd = data.Query(sql_e);
                this.dataGridView3.DataSource = dtd;
                DataTable dtb = data.Query(sql_d);
                foreach (DataRow dr in dtb.Rows)
                {
                    string Lend = dr["lend"].ToString();
                    if (Lend == "0")
                    {
                        checkBox4.Checked = false;
                        textBox3.Text = "";
                        textBox5.Text = "";
                    }
                    else
                    {
                        checkBox4.Checked = true;
                        textBox3.Text = dr["lend_price"].ToString();
                        textBox5.Text = dr["lend_shuoming"].ToString();
                    }
                    string Sell = dr["sell"].ToString();
                    if (Sell == "0")
                    {
                        checkBox5.Checked = false;
                        textBox4.Text = "";
                        textBox6.Text = "";
                    }
                    else
                    {
                        checkBox5.Checked = true;
                        textBox4.Text = dr["sell_price"].ToString();
                        textBox6.Text = dr["sell_shuoming"].ToString();
                    }
                    if (Lend == "1" && Sell == "1")
                    {
                        checkBox4.Checked = true;
                        checkBox5.Checked = true;
                        textBox3.Text = dr["lend_price"].ToString();
                        textBox5.Text = dr["sell_price"].ToString();
                        textBox4.Text = dr["lend_shuomig"].ToString();
                        textBox6.Text = dr["sell_shuoming"].ToString();
                    }
                    textBox7.Text = dr["zhuangtai"].ToString();
                    textBox8.Text = dr["guwen"].ToString();
                    string jianchengmin = dr["jianchengmin"].ToString();
                    string jianchengmax = dr["jianchengmax"].ToString();
                    textBox9.Text = jianchengmin + "/" + jianchengmax;
                    textBox10.Text = dr["wuye"].ToString();
                    textBox13.Text = dr["yongtu"].ToString();
                    textBox14.Text = dr["wuye_type"].ToString();
                    textBox11.Text = dr["area"].ToString();
                    textBox15.Text = dr["chengdu"].ToString();
                    textBox16.Text = dr["fang_type"].ToString();
                    textBox12.Text = "";
                    string mianjimin = dr["mianjimin"].ToString();
                    string mianjimax = dr["mianjimax"].ToString();
                    textBox18.Text = mianjimin + "/" + mianjimax;
                    string fangshumin = dr["fangshumin"].ToString();
                    string fangshumax = dr["fangshumax"].ToString();
                    textBox17.Text = fangshumin + "/" + fangshumax;
                    textBox19.Text = dr["jichusheshi"].ToString();
                    textBox20.Text = dr["peitaosheshi"].ToString();
                    textBox21.Text = dr["address"].ToString();
                    textBox22.Text = dr["xinxi"].ToString();
                    textBox23.Text = dr["yezhu_name"].ToString();
                    textBox24.Text = dr["tele"].ToString();
                    textBox25.Text = dr["MobliePhone"].ToString();
                    textBox26.Text = dr["yezhu_address"].ToString();
                    textBox27.Text = dr["beizhu"].ToString();


                }
            }
            catch
            { }
            finally
            {
                data.Close();
            }
        }
        //跟进查询
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            try
            {
                string sql_i = "select genjin_time as 跟进时间,genjinren as 跟进人,f_genjin as 跟进方式,neirong as 跟进内容 from f_genjin_kh where ";
                if (textBox2.Text != "")
                {
                    sql_i = sql_i + "genjin_time>='" + dateTimePicker1.Value + "' and genjin_time<='" + dateTimePicker2.Value + "' and genjinren like '%" + textBox2.Text + "%' or f_genjin like '%" + textBox2.Text + "%' or neirong like '%" + textBox2.Text + "%'";
                }
                else
                {
                    sql_i = sql_i + "genjin_time>='" + dateTimePicker1.Value + "' and genjin_time<='" + dateTimePicker2.Value + "'";
                }
                dataGridView1.DataSource = data.Query(sql_i);
            }
            catch { }
            finally { data.Close(); }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (this.dataGridView3.Rows.Count > 0)
            {
                genjinkehu Genjinkehu = new genjinkehu();
                int index = this.dataGridView3.CurrentRow.Index;
                int i = this.dataGridView4.CurrentRow.Index;
                string genjintime = this.dataGridView3.Rows[index].Cells["跟进时间"].Value.ToString();
                string bianh = this.dataGridView4.Rows[i].Cells["客户编号"].Value.ToString();
                string sql_c = "select * from f_genjin_kh where genjin_time='"+genjintime+"'";
                DataTable dtt = data.Query(sql_c);
                foreach (DataRow dr in dtt.Rows)
                {
                    Genjinkehu.bianhao = dr["bianhao"].ToString();
                    Genjinkehu.genjin_time = Convert.ToDateTime(dr["genjin_time"]);
                    Genjinkehu.f_genjin = dr["f_genjin"].ToString();
                    Genjinkehu.neirong = dr["neirong"].ToString();
                    Genjinkehu.tixing_type = dr["tixing_type"].ToString();
                    Genjinkehu.tixing_date = dr["tixing_date"].ToString();
                    Genjinkehu.tixing_time = dr["tixing_time"].ToString();
                    Genjinkehu.genjinren = dr["genjinren"].ToString();
                }
                addgenjin ad = new addgenjin(Genjinkehu, true);
                ad.ShowDialog();

            }
            
        }
    }
}
