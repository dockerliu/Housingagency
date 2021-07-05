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
    public partial class tichengmingxi : Form
    {
        public tichengmingxi()
        {
            InitializeComponent();
        }
        Database da = new Database();
        private void tichengmingxi_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddDays(-30);
            dateTimePicker2.Value = DateTime.Now.AddDays(1);
            string SelectSql = "select empnumber as 员工姓名,fnumber as 合同编号,d_portion as 所占分成,d_money as 分成金额,d_desc as 分成方式, case when sell_or_lend='true' then '销售' when sell_or_lend='false' then '租赁' end as 租售,f_num as 房源编号,kh_num as 客户编号,ht_money as 成交金额,f_fukuan as 付款方式,kh_money as 客户佣金,yz_money as 业主佣金,all_money as 总佣金,ticheng as 提成比例,nowdate as 签约时间 from divide inner join htnews on fnumber=ht_num";

            DataTable dt = da.Query(SelectSql);
            this.dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGridView1.RowCount > 0)
                {
                    string f_num = this.dataGridView1.SelectedRows[0].Cells["房源编号"].Value.ToString();
                    string sql = "select * from fangyuan where bianhao='" + f_num + "'";
                    DataTable dts = da.Query(sql);

                    this.textBox2.Text = dts.Rows[0][26].ToString();
                    this.textBox3.Text = dts.Rows[0][27].ToString();
                    this.textBox42.Text = dts.Rows[0][3].ToString();
                    this.textBox39.Text = dts.Rows[0][4].ToString();
                    this.textBox33.Text = dts.Rows[0][5].ToString();
                    this.textBox32.Text = dts.Rows[0][6].ToString();
                    this.textBox36.Text = dts.Rows[0][7].ToString();
                    this.textBox31.Text = dts.Rows[0][8].ToString();
                    this.textBox41.Text = dts.Rows[0][10].ToString();
                    this.textBox38.Text = dts.Rows[0][11].ToString();
                    this.textBox37.Text = dts.Rows[0][12].ToString();
                    this.textBox35.Text = dts.Rows[0][13].ToString();
                    this.textBox34.Text = dts.Rows[0][14].ToString();
                    this.textBox40.Text = dts.Rows[0][15].ToString();
                    this.textBox21.Text = dts.Rows[0][16].ToString();
                    this.textBox22.Text = dts.Rows[0][21].ToString();
                    this.textBox19.Text = dts.Rows[0][24].ToString();
                    if (Convert.ToBoolean(dts.Rows[0][17].ToString()) == true)
                    {
                        this.checkBox4.Checked = true;
                        this.textBox46.Text = dts.Rows[0][22].ToString();
                        this.textBox45.Text = dts.Rows[0][19].ToString();
                    }
                    else
                    {
                        this.checkBox4.Checked = false;
                        this.textBox46.Text = "";
                        this.textBox45.Text = "";
                    }
                    if (Convert.ToBoolean(dts.Rows[0][18].ToString()) == true)
                    {
                        this.checkBox3.Checked = true;
                        this.textBox44.Text = dts.Rows[0][22].ToString();
                        this.textBox43.Text = dts.Rows[0][20].ToString();
                    }
                    else
                    {
                        this.checkBox3.Checked = false;
                        this.textBox44.Text = "";
                        this.textBox43.Text = "";
                    }
                    this.textBox20.Text = dts.Rows[0][25].ToString();
                    this.textBox2.Text = dts.Rows[0][26].ToString();
                    this.textBox3.Text = dts.Rows[0][27].ToString();
                    this.textBox4.Text = dts.Rows[0][28].ToString();
                    this.textBox6.Text = dts.Rows[0][29].ToString();
                    this.textBox5.Text = dts.Rows[0][30].ToString();
                }

            }
            catch
            {
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sdvl = "select empnumber as 员工姓名,fnumber as 合同编号,d_portion as 所占分成,d_money as 分成金额,d_desc as 分成方式, case when sell_or_lend='true' then '销售' when sell_or_lend='false' then '租赁' end as 租售,f_num as 房源编号,kh_num as 客户编号,ht_money as 成交金额,f_fukuan as 付款方式,kh_money as 客户佣金,yz_money as 业主佣金,all_money as 总佣金,ticheng as 提成比例,nowdate as 签约时间 from divide inner join htnews on fnumber=ht_num where empnumber like '%" + this.textBox1.Text.Trim() + "%'";
                if (this.checkBox1.Checked == true)
                {
                    sdvl += " and sell_or_lend='false'";
                }
                if (this.checkBox2.Checked == true)
                {
                    sdvl += " and sell_or_lend='true'";
                }
                dataGridView1.DataSource = da.Query(sdvl);
            }
            catch
            {
                MessageBox.Show("出现未知错误！");
                return;
            }
        }

    }
}
