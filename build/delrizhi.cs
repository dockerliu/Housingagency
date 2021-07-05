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
    public partial class delrizhi : Form
    {
        public delrizhi()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void delrizhi_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除当前时间段内的信息么？删除后不能修复！", "删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DateTime d1, d2;
                d1 = this.dateTimePicker1.Value;
                d2 = this.dateTimePicker2.Value;
                string sql = "delete from rizhi where time>'" + d1 + "' and time<'" + d2 + "'";
                int i = data.RunSql(sql);

                if (i > 0)
                {
                    this.Close();
                }
                if (i == -1)
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
