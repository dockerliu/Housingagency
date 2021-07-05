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
    public partial class hetong : Form
    {
        public hetong()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void hetong_Load(object sender, EventArgs e)
        {
            string sql = "select * from hetong";
            DataTable ds = data.Query(sql);
            this.dataGridView1.DataSource = ds;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            addhetong addhe = new addhetong();
            addhe.sta = -1;
            addhe.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                int i = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                addhetong addhe = new addhetong();
                addhe.sta = i;
                addhe.sdd = this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
                addhe.sff = this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
                addhe.ShowDialog();
            }
            else
            {
                MessageBox.Show("当前没有可供删除的数据！");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                int i = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                if (MessageBox.Show("确定要删除本条信息么？", "删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    string sql = "delete from hetong where id=" + i;
                    int j = data.RunSql(sql);
                    hetong_Load(this, e);
                    if (j == -1)
                    {
                        MessageBox.Show("删除失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("当前没有可供删除的数据！");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                string dd = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                try
                {
                    System.Diagnostics.Process.Start(dd);
                }
                catch
                {
                    MessageBox.Show("文件路径名错误");
                    return;
                }
            }
            else
            {
                MessageBox.Show("当前没有可供打开的样本路径！");
                return;
            }
        }
    }
}
