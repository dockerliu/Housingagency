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
    public partial class rizhi : Form
    {
        public rizhi()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d1, d2;
            d1 = this.dateTimePicker1.Value;
            d2 = this.dateTimePicker2.Value;
            string sql = "select person as 操作账号,concent as 操作内容,time as 操作时间,remark as 说明 from rizhi where time>'" + d1 + "' and time<'" + d2 + "'";
            DataTable dt = data.Query(sql);
            this.dataGridView1.DataSource = dt;
        }

        private void rizhi_Load(object sender, EventArgs e)
        {
            string sql = "select person as 操作账号,concent as 操作内容,time as 操作时间,remark as 说明 from rizhi";
            DataTable dt = data.Query(sql);
            this.dataGridView1.DataSource = dt;
        }
    }
}
