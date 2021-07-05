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
    public partial class ht_demo : Form
    {
        public ht_demo()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void ht_demo_Load(object sender, EventArgs e)
        {
            string sql = "select h_name as 合同名称,h_url as 合同路径 from hetong";
            DataTable ds = data.Query(sql);
            this.dataGridView1.DataSource = ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                string dd = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                try
                {
                    System.Diagnostics.Process.Start(dd);

                }
                catch
                {
                    MessageBox.Show("文件路径错误");
                }

            }
            else
            {
                MessageBox.Show("当前没有可供打开的样本路径");
                return;
            }
        }
    }
}
