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
    public partial class tichenghuizong : Form
    {
        public tichenghuizong()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void tichenghuizong_Load(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = DateTime.Now.AddDays(-30);
            this.dateTimePicker2.Value = DateTime.Now.AddDays(1);
            string selectsql = "select empnumber as 员工姓名,sum(d_money) as 总分成金额,sum(all_money) as 总佣金 from divide e1 inner join htnews e2 on e1.fnumber=e2.ht_num group by empnumber";
            DataTable dt1 = data.Query(selectsql);
            this.dataGridView1.DataSource = dt1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                string strsql = "select empnumber as 员工姓名,sum(d_money) as 总分成金额,sum(all_money) as 总佣金 from divide e1 inner join htnews e2 on e1.fnumber=e2.ht_num where nowdate between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' group by empnumber";
                DataTable dt = data.Query(strsql);
                this.dataGridView1.DataSource = dt;
            }
            else
            {
                string strsql = "select empnumber as 员工姓名,sum(d_money) as 总分成金额,sum(all_money) as 总佣金 from divide e1 inner join htnews e2 on e1.fnumber=e2.ht_num where nowdate between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and empnumber like '%"+this.textBox1.Text+"%' group by empnumber";
                DataTable dt = data.Query(strsql);
                this.dataGridView1.DataSource = dt;

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows.Count > 0)
                {
                    string emp_name = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string sql = "select empnumber as 员工姓名,fnumber as 合同编号,d_portion as 所占分成,d_money as 分成金额,d_desc as 分成方式,case when sell_or_lend='true' then '销售' when sell_or_lend='false' then '租赁' end as 租售,f_num as 房源的编号,ht_money as 成交金额,f_fukuan as 付款方式,kh_money as 客户佣金,yz_money as 业主佣金,all_money as 总佣金,ticheng as 提成比例,nowdate as 签约时间 from divide inner join htnews on fnumber=ht_num where empnumber='" + emp_name + "'";
                    DataTable das = data.Query(sql);
                    this.dataGridView2.DataSource = das;
                }
            }
            catch
            {
            }
        }
    }
}
