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
    public partial class LockCreen : Form
    {
        public LockCreen()
        {
            InitializeComponent();
        }
        Database da = new Database();
        mainform m = new mainform();
        private void button1_Click(object sender, EventArgs e)
        {
            bool a = false;
            DataTable dt = m.Login_out(login._UserName);
            foreach(DataRow dr in dt.Rows)
            {
                if (this.textBox1.Text == dr["_pass"].ToString())
                {
                    a = true;
                }
            }
            if (a == true)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("解锁密码错误!","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.textBox1.Text = "";
            }
        }
    }
}
