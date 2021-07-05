using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace build
{
    public partial class maifangchaxun : Form
    {
        public maifangchaxun()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void maifangchaxun_Load(object sender, EventArgs e)
        {
            string sql = "select area from area";
            DataTable da = data.Query(sql);
            this.comboBox10.DataSource = da;
            this.comboBox10.DisplayMember = "area";

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Bitmap aa = new Bitmap(Application.StartupPath + "//img/queding2.jpg");
            this.pictureBox1.Image = aa;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            System.Drawing.Bitmap aa = new Bitmap(Application.StartupPath + "//img/queding1.jpg");
            this.pictureBox1.Image = aa;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Bitmap aa = new Bitmap(Application.StartupPath + "//img/quxiao2.jpg");
            this.pictureBox2.Image = aa;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            System.Drawing.Bitmap aa = new Bitmap(Application.StartupPath+"//img/quxiao1.jpg");
            this.pictureBox2.Image = aa;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string sql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where ";
            try
            {
                if (this.comboBox10.Text != "不限")
                {
                    sql = sql + "area='" + comboBox10.Text + "' and ";
                }
                if (this.textBox1.Text != "")
                {
                    sql = sql + "mianji>='" + textBox1.Text + "' and ";
                }
                if (this.textBox2.Text != "")
                {
                    sql = sql + "mianji<='" + textBox2.Text + "' and ";
                }
                if (this.comboBox2.Text != "不限")
                {
                    sql = sql + "huxing like '%" + comboBox2.Text + label6.Text + "%' and ";
                }
                if (this.comboBox3.Text != "不限")
                {
                    sql = sql + "huxing like '%" + comboBox3.Text + label7.Text + "%' and ";
                }
                if (this.comboBox4.Text != "不限")
                {
                    sql = sql + "huxing like '%" + comboBox4.Text + label8.Text + "%' and ";
                }
                if (this.comboBox5.Text != "不限")
                {
                    sql = sql + "huxing like '%" + comboBox5.Text + label9.Text + "%' and  ";
                }
                if (this.textBox3.Text != "")
                {
                    sql = sql + "sell_price>='" + textBox3.Text + "' and ";
                }
                if (this.textBox4.Text != "")
                {
                    sql = sql + "sell_price<='" + textBox4.Text + "' and ";
                }
                if (this.checkBox1.Checked == true)
                {
                    sql = sql + "jichusheshi like '%" + checkBox1.Text + "%' and ";
                }
                if (this.checkBox2.Checked == true)
                {
                    sql = sql + "jichusheshi like '%" + checkBox2.Text + "%' and ";
                }

                if (this.checkBox3.Checked == true)
                {
                    sql = sql + "jichusheshi like '%" + checkBox3.Text + "%' and ";

                }
                if (this.checkBox4.Checked == true)
                {
                    sql = sql + "jichusheshi like '%" + checkBox4.Text + "%' and ";
                }
                if (this.textBox5.Text != "")
                {
                    sql = sql + "wuye like '%" + textBox5.Text + "%' and ";
                }
                if (this.textBox6.Text != "")
                {
                    sql = sql + "address like '%" + textBox6.Text + "%' and ";
                }
                sql = sql + "sell=1";
                DataTable da = data.Query(sql);
                this.dataGridView1.DataSource = da;
            }
            catch
            {

            }
            finally
            {
                data.Close();
            }
        }


    }
}
