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
    public partial class FenYe : Form
    {
        public FenYe()
        {
            InitializeComponent();
        }
       
        int Sizes = 3;//每页显示3条记录
        int AllCount = 0;
        SqlConnection conn = new SqlConnection("server=.;uid=home;pwd=;database=build");
        private void FenYe_Load(object sender, EventArgs e)
        {
            
            SqlDataAdapter da = new SqlDataAdapter("select * from fangyuan",conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = dt.Rows.Count;//总记录数
            int m = i % Sizes;
            if (m == 0)
            {
                m = i / Sizes;//可以分多少页
            }
            else
            {
                m = i / Sizes + 1;
            }
            this.label3.Text = m.ToString();
            this.label6.Text = "1";
            ShowInfo(0,Sizes); 
        }
        private void ShowInfo(int i,int j)
        {
            conn.Open();
            SqlDataAdapter daone = new SqlDataAdapter("select * from fangyuan",conn);
            DataSet dsone = new DataSet();
            daone.Fill(dsone, i, j, "one");
            this.dataGridView1.DataSource = dsone.Tables["one"].DefaultView;
            dsone = null;
            conn.Close();
        }
        //首页
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.label6.Text = "1";
            ShowInfo(0,Sizes);
        }
        //上一页
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.dataGridView1.DataSource = null;
            int m = Convert.ToInt32(this.label6.Text) - 1;
            if (m < 1)
            {
                this.label6.Text = "1";
            }
            else
            {
                this.label6.Text = m.ToString();
            }
            int a = Convert.ToInt32(this.label6.Text)*Sizes-Sizes;
            ShowInfo(a,Sizes);
        }
        //下一页
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.dataGridView1.DataSource = null;
            int m = Convert.ToInt32(this.label6.Text) + 1;
            if (m > Convert.ToInt32(this.label3.Text))
            {
                this.label6.Text = this.label3.Text;
            }
            else
            {
                this.label6.Text = m.ToString();
            }
            int a = Convert.ToInt32(this.label6.Text)*Sizes-Sizes;
            ShowInfo(a,4);
        }
        //末页
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
