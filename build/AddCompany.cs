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
    public partial class AddCompany : Form
    {
        public AddCompany()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void AddCompany_Load(object sender, EventArgs e)
        {
            string sql = "select * from comp_info";
            DataTable da = data.Query(sql);
            this.textBox1.Text = da.Rows[0][1].ToString();
            this.textBox2.Text = da.Rows[0][2].ToString();
            this.textBox3.Text = da.Rows[0][4].ToString();
            this.textBox4.Text = da.Rows[0][5].ToString();
            this.textBox5.Text = da.Rows[0][3].ToString();
            da.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string z1 = this.textBox1.Text.Trim();
            string z2 = this.textBox2.Text.Trim();
            string z3 = this.textBox3.Text.Trim();
            string z4 = this.textBox4.Text.Trim();
            string z5 = this.textBox5.Text.Trim();
            string sql = "update comp_info set comp_name='"+z1+"',comp_tel='"+z2+"',comp_email='"+z3+"',comp_http='"+z4+"',comp_add='"+z5+"'";
            int i = data.RunSql(sql);
            if (i > 0)
            {
                MessageBox.Show("更新成功");
            }
            else
            {
                MessageBox.Show("更新失败");
            }
        }
    }
}
