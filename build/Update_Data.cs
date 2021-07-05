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
    public partial class Update_Data : Form
    {
        public Update_Data()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.Title = "存放为";
            this.saveFileDialog1.Filter = "数据库文件(*.dat)|*.dat";
            this.saveFileDialog1.FileName = DateTime.Now.Date.ToString().Substring(2, 9) + ".dat";
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = this.saveFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = this.textBox1.Text;
            if (url != "")
            {
                try
                {
                    string sql = "backup database build to disk='" + url + "'";
                    data.RunSql(sql);
                    MessageBox.Show("备份成功");
                }
                catch
                {
                }
            }
            else
            {
                MessageBox.Show("请选择数据库备份的地址");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Title = "打开备份数据库文件";
            this.openFileDialog1.Filter = "数据库文件(*.dat)|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = this.openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = this.textBox2.Text.Trim();
            if (url != "")
            {
                try
                {
                    string sql = "restore database build from disk='" + url + "'";
                    int i = data.RunSql(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("数据库还原成功");
                    }
                    else
                    {
                        MessageBox.Show("数据库还原失败");
                    }

                }
                catch
                {
                }
            }
            else
            {
                MessageBox.Show("请选择数据库备份文件的地址");
            }


        }
    }
}
