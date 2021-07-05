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
    public partial class addhetong : Form
    {
        public addhetong()
        {
            InitializeComponent();
        }
        Database data = new Database();
        public int sta;
        public string sql, sdd, sff;
        private void addhetong_Load(object sender, EventArgs e)
        {
            if (sta != -1)
            {
                this.textBox1.Text = sdd;
                this.textBox2.Text = sff;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("请输入合同名称！");
                    return;
                }
                if (this.textBox2.Text.Trim() == "")
                {
                    MessageBox.Show("您还没有设置样本文件的路径。");
                    return;
                }

                string str1, str2;
                str1 = this.textBox1.Text.Trim();
                str2 = this.textBox2.Text.Trim();
                if (sta == -1)
                {
                    sql = "insert into hetong (h_name,h_url) values ('" + str1 + "','" + str2 + "')";
                }
                else
                {
                    sql = "update hetong set h_name='" + str1 + "',h_url='" + str2 + "' where id='" + sta + "'";
                }
                int i = data.RunSql(sql);
                if (i != -1)
                {

                    this.Close();

                }
            }
            catch
            {
                MessageBox.Show("有错误产生");
            }
            finally
            {
                data.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "打开";
            openFileDialog1.Filter = "合同文件(*.*)|*.*|Word文档|*.doc|Txt文件|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = openFileDialog1.FileName;
            }
        }
    }
}
