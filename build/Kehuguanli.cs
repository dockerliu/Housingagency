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
    public partial class Kehuguanli : Form
    {
        public Kehuguanli()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void Kehuguanli_Load(object sender, EventArgs e)
        {
            string sql = "select bianhao as 客户编号,laiyuan as 客户来源,zhuangtai as 当前状态,wuye as 物业名称,fangshumin as 最小房间数,fangshumax as 最大房间数,mianjimin as 最小面积,mianjimax as 最大面积,jianchengmin as 建成年份小,jianchengmax as 建成年份大 from kehu order by bianhao";
            DataTable dt = data.Query(sql);
            this.dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string strSql = "select * from kehu where bianhao='"+str+"'";
                DataTable dt = data.Query(strSql);
                foreach (DataRow dr in dt.Rows)
                {
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
                        textBox3.Text = dr["lend_price"].ToString();
                        textBox4.Text = dr["lend_shuoming"].ToString();
                        textBox5.Text = dr["sell_price"].ToString();
                        textBox6.Text = dr["sell_shuoming"].ToString();

                    }

                    textBox7.Text = dr["zhuangtai"].ToString();
                    textBox8.Text = dr["guwen"].ToString();
                    string jianchengmin = dr["jianchengmin"].ToString();
                    string jianchengmax = dr["jianchengmax"].ToString();
                    textBox9.Text = jianchengmin + "/" + jianchengmax;
                    textBox10.Text = dr["wuye"].ToString();
                    textBox11.Text = dr["yongtu"].ToString();
                    textBox12.Text = dr["wuye_type"].ToString();
                    textBox13.Text = dr["area"].ToString();
                    textBox14.Text = dr["chengdu"].ToString();
                    textBox15.Text = dr["fang_type"].ToString();
                    textBox16.Text = "";
                    string mianjimin = dr["mianjimin"].ToString();
                    string mianjimax = dr["mianjimax"].ToString();
                    textBox17.Text = mianjimin + "/" + mianjimax;
                    textBox18.Text = "";
                    textBox19.Text = dr["jichusheshi"].ToString();
                    textBox20.Text = dr["peitaosheshi"].ToString();
                    textBox21.Text = dr["address"].ToString();
                    textBox22.Text = dr["xinxi"].ToString();
                    textBox23.Text = dr["yezhu_name"].ToString();
                    textBox24.Text = dr["tele"].ToString();
                    textBox25.Text = dr["MobliePhone"].ToString();
                    textBox26.Text = dr["yezhu_address"].ToString();
                    textBox27.Text = dr["beizhu"].ToString();
                    string chengdu=dr["chengdu"].ToString();
                    string address=dr["address"].ToString();
                    string sql_a = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 状态,wuye as 物业名称,area as 所在区域,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,address as 具体地址 from kehu where(chengdu=@chengdu or address=@address) and bianhao!='"+str+"'";
                    SqlParameter[] par = { 
                                         
                                         data.MakeInParam("@chengdu",SqlDbType.VarChar,chengdu),
                                         data.MakeInParam("@address",SqlDbType.VarChar,address),
                                         
                                         };
                    DataTable dtb = data.Query(sql_a,par);
                    this.dataGridView2.DataSource = dtb;
                }

            }
            catch
            {
            }
            finally
            {
            }
        }
        //删除一条记录
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows.Count > 0)
                {
                    int st = this.dataGridView1.SelectedRows[0].Index;
                    string str = this.dataGridView1.Rows[st].Cells[0].Value.ToString();
                    DialogResult df = MessageBox.Show("确定要删除本条记录吗？","删除确认",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                    if (df == DialogResult.OK)
                    {
                        string sql = "delete from kehu where bianhao='"+str+"'";
                        int i = data.RunSql(sql);
                        if (i > 0)
                        {
                            MessageBox.Show("数据删除成功");
                        }
                        else
                        {
                            MessageBox.Show("数据删除失败");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("没有数据可以删除");
                }

            }
            catch
            {
                MessageBox.Show("没有数据可以删除");
            }

        }
        //修改客户信息
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                keehuu kh = new keehuu();
                int i = dataGridView1.CurrentRow.Index;
                string bh = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string sql_1 = "select * from kehu where bianhao='" + bh + "'";
                DataTable dt = data.Query(sql_1);
                foreach (DataRow dr in dt.Rows)
                {
                    kh.bianhao = dr["bianhao"].ToString();
                    kh.laiyuan = dr["laiyuan"].ToString();
                    kh.zhuangtai = dr["zhuangtai"].ToString();
                    kh.wuye = dr["wuye"].ToString();
                    kh.area = dr["area"].ToString();
                    kh.guwen = dr["guwen"].ToString();
                    kh.yongtu = dr["yongtu"].ToString();
                    kh.wuye_type = dr["wuye_type"].ToString();
                    kh.chengdu = dr["chengdu"].ToString();
                    kh.fang_type = dr["fang_type"].ToString();
                    kh.address = dr["address"].ToString();
                    kh.yezhu_name = dr["yezhu_name"].ToString();
                    kh.tele = dr["tele"].ToString();
                    kh.MobliePhone = dr["MobliePhone"].ToString();
                    kh.yezhu_address = dr["yezhu_address"].ToString();
                    kh.lend_price = dr["lend_price"].ToString();
                    kh.sell_price = dr["sell_price"].ToString();
                    kh.lend_shuoming = dr["lend_shuoming"].ToString();
                    kh.sell_shuoming = dr["sell_shuoming"].ToString();
                    kh.xinxi = dr["xinxi"].ToString();
                    kh.beizhu = dr["beizhu"].ToString();
                    kh.lend = dr["lend"].ToString();
                    kh.sell = dr["sell"].ToString();
                    kh.fangshumin = Convert.ToInt32(dr["fangshumin"]);
                    kh.fangshumax = Convert.ToInt32(dr["fangshumax"]);
                    kh.jianchengmin = Convert.ToInt32(dr["jianchengmin"]);
                    kh.jianchengmin = Convert.ToInt32(dr["jianchengmax"]);
                    kh.mianjimin = Convert.ToInt32(dr["mianjimin"]);
                    kh.mianjimin = Convert.ToInt32(dr["mianjimax"]);
                }
                xinxi xx = new xinxi(kh);
                xx.bianh = bh;
                xx.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有可以更改的数据");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            xinxi xx = new xinxi();
            xx.ShowDialog();

        }
    }
}
