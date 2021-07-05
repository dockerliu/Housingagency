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
    public partial class addfencheng : Form
    {
        public addfencheng()
        {
            InitializeComponent();
        }
        public string stt, emp_num=null, sql, f_num, d_desc, d_ption;
        public double all_money;
        Database data = new Database();
        public delegate void camEventHandler(object sender,EventArgs e);
        public event camEventHandler cam;
        private void addfencheng_Load(object sender, EventArgs e)
        {
            sql = "select * from f_fencheng";
            DataTable dt = data.Query(sql);
            this.comboBox1.DataSource = dt;
            this.comboBox1.ValueMember = "_f_fencheng";
            if (emp_num != null)
            {
                this.textBox1.Text = emp_num;
                this.textBox2.Text = d_ption;
                this.comboBox1.Text = d_desc;
                this.pictureBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请选择分成的用户");
                return;
            }
            if (this.textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请输入分成比例");
                return;
            }
            if (emp_num == null)
            {
                double hkkk = Convert.ToDouble(this.textBox2.Text);
                sql = "select sum(d_portion) from divide where fnumber='" + stt + "'";
                DataTable s = data.Query(sql);
                if (s.Rows[0][0].ToString() == "")
                {
                    double m = Convert.ToDouble(this.textBox2.Text);
                    if (m > 100)
                    {
                        MessageBox.Show("分成比例不能大于100");
                        return;
                    }
                    else
                    {
                        sql = "insert into divide(fnumber,empnumber,d_portion,d_desc,nowdate,d_money) values('" + stt + "','" + this.textBox1.Text + "','" + hkkk + "','" + this.comboBox1.Text + "','" + DateTime.Now.Date + "','" + hkkk / 100 * all_money + "')";

                    }
                }
                else
                {
                    double i = Convert.ToDouble(s.Rows[0][0].ToString());
                    double j = i + Convert.ToDouble(this.textBox2.Text);
                    double h = 100 - i;
                    if (j > 100)
                    {
                        MessageBox.Show("分成比例过大");
                        return;
                    }
                    else
                    {
                        sql = "insert into divide(fnumber,empnumber,d_portion,d_desc,nowdate,d_money) values('" + stt + "','" + this.textBox1.Text + "','" + hkkk + "','" + this.comboBox1.Text + "','" + DateTime.Now.Date + "','" + hkkk / 100 * all_money + "')";

                    }

                }

            }
            else
            {
                string sqlder = "select sum(d_portion) from divide where fnumber='"+f_num+"'";
                DataTable dt = data.Query(sqlder);
                if (dt.Rows[0][0].ToString() != "")
                {
                    double m = Convert.ToDouble(d_ption.ToString());
                    double mk = Convert.ToDouble(this.textBox2.Text);
                    double j = Convert.ToDouble(dt.Rows[0][0])-m;
                    double h = 100 - j;
                    if (j + mk > 100)
                    {
                        MessageBox.Show("分成比例过大");
                        return;
                    }
                    else
                    {
                        sql = "update divide set d_portion='"+this.textBox2.Text+"',d_desc='"+this.textBox1.Text+"' where empnumber='"+emp_num+"' and fnumber='"+f_num+"'";

                    }
                }
            }
            int r = data.RunSql(sql);
            if (r == -1)
            {
                MessageBox.Show("操作失败");


            }
            else
            {
                camEventHandler hand = cam;
                if (hand != null)
                {
                    hand(this,e);

                }
                this.Close();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (emp_num == null)
            {

                adduse addus = new adduse();
                addus.f_num = stt;
                addus.proe+=new adduse.proeEventHandler(dias);
                addus.ShowDialog();
            }
        }
        private void dias(object sender, NameEventArgs e)
        {
            this.textBox1.Text = e.Str;
        }
    }
}
