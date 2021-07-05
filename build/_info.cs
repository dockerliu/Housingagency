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
    public partial class _info : Form
    {
        public _info()
        {
            InitializeComponent();
        }
        Database data = new Database();
        public int i, j, k;
        public string st;
        public string sql;
        public bool tex6;
        public delegate void freshEventHandler(object sender,eventArgs2 e);
        public event freshEventHandler fresh;
        private void _info_Load(object sender, EventArgs e)
        {
            this.comboBox2.SelectedItem = comboBox2.Items[0];
            sql = "select id,_jibie from jibie";
            DataTable da = data.Query(sql);
            comboBox1.DataSource = da;
            comboBox1.DisplayMember = "_jibie";
            comboBox1.ValueMember = "id";
            if (i == 1)
            {
                this.textBox1.Enabled = false;
                string sql2 = "select _jibie,_name,_username,_pass,_sta from login_user z1 inner join jibie z2 on z1._jibieid=z2.id where _name='"+st+"'";
                da = data.Query(sql2);
                this.textBox1.Text = da.Rows[0][1].ToString();
                this.textBox2.Text = da.Rows[0][3].ToString();
                textBox3.Text = da.Rows[0][2].ToString();
                this.comboBox1.Text = da.Rows[0][0].ToString();
                bool dsc = Convert.ToBoolean(da.Rows[0][4].ToString());
                if (dsc == true)
                {
                    this.comboBox2.Text = "可用";
                }
                else
                {
                    this.comboBox2.Text = "不可用";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            j = Convert.ToInt32(this.comboBox1.SelectedValue.ToString());
            if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show("用户编号不能为空");
                this.textBox1.Focus();
                return;
            }
            if (this.textBox2.Text.Trim() == "" || this.textBox4.Text.Trim() == "")
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            if (this.textBox2.Text != this.textBox4.Text && this.textBox2.Text != "")
            {
                MessageBox.Show("密码输入不一致");
                return;
            }
            if (this.textBox3.Text.Trim() == "")
            {
                MessageBox.Show("操作员的姓名不能为空");
                return;
            }
            string tex1, tex2, tex3, tex5;
            tex1 = this.textBox1.Text.Trim();
            tex2 = this.textBox2.Text.Trim();
            tex3 = this.textBox3.Text.Trim();
            tex5 = this.comboBox1.Text;
            if (this.comboBox2.Text == "可用")
            {
                tex6 = true;
            }
            if (this.comboBox2.Text == "不可用")
            {
                tex6 = false;
            }
            if (i == 0)
            {
                sql = "insert into login_user(_name,_username,_jibieid,_pass,_sta) values('"+tex1+"','"+tex3+"','"+j+"','"+tex2+"','"+tex6+"')";

            }
            else if (i == 1)
            {
                sql = "update login_user set _username='"+tex3+"',_jibieid='"+j+"',_pass='"+tex2+"',_sta='"+tex6+"' where _name='"+tex1+"'";

            }
            int ss = data.RunSql(sql);
            if (ss > 0)
            {
                MessageBox.Show("操作成功");
                freshEventHandler hand = fresh;
                if (hand != null)
                {
                    eventArgs2 eva = new eventArgs2();
                    eva.ss_num = k;
                    hand(this,eva);
                }
                this.Close();
            }

        }
    }
}
