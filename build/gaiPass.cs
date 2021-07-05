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
    public partial class gaiPass : Form
    {
        public gaiPass()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("请输入登录账号");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入密码");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("请输入要修改的密码");
                return;
            }

           
            else
            {
                try
                {

                    string sql = "update login_user set _pass='" + textBox2.Text + "' where _name='" + login._UserName + "'";
                    int i = data.RunSql(sql);

                    if (i > 0)
                    {
                        MessageBox.Show("修改成功");
                        this.Close();
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
        }
    }
}
