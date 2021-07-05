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
    public partial class qychengjiao : Form
    {
        public qychengjiao()
        {
            InitializeComponent();
        }
        public string f_num;
        Database data = new Database();
        public bool update = false;
        public string sql;
        public string dd1, dd2, dd3, dd4, dd5;

        private void qychengjiao_Load(object sender, EventArgs e)
        {
            this.label2.Text = f_num;
            sql = "select wuye,yezhu_name,lend,sell from fangyuan where bianhao='"+f_num+"'";
            DataTable dbq = data.Query(sql);
            this.label4.Text = dbq.Rows[0][0].ToString();
            this.label6.Text = dbq.Rows[0][1].ToString();
            this.comboBox1.Text = "新增客户";
            if (Convert.ToBoolean(dbq.Rows[0][2].ToString()) == false)
            {
                this.radioButton2.Enabled = false;
            }
            if (Convert.ToBoolean(dbq.Rows[0][3].ToString()) == false)
            {
                this.radioButton1.Enabled = false;
            }
            sql = "select * from f_fukuan";
            DataTable ds = data.Query(sql);
            this.comboBox2.DataSource = ds;
            this.comboBox2.ValueMember = "f_fukuan";

            if (update == false)
            {
                string da = "yyyyMMddHHmmss";
                this.textBox7.Text = "HT" + DateTime.Now.ToString(da);
                this.textBox7.Enabled = false;
            }
            if (update == true)
            {
                sql = "select * from htnews where f_num='"+f_num+"' and date in (select max(date) from htnews where f_num='"+f_num+"')";
                DataTable dtdt = data.Query(sql);
                this.radioButton1.Checked = Convert.ToBoolean(dtdt.Rows[0][1].ToString());
                this.radioButton2.Checked = !Convert.ToBoolean(dtdt.Rows[0][1].ToString());
                this.comboBox1.Text = dtdt.Rows[0][5].ToString();
                this.textBox1.Text = dtdt.Rows[0][6].ToString();
                this.textBox2.Text = dtdt.Rows[0][7].ToString();
                this.textBox3.Text = dtdt.Rows[0][9].ToString();
                this.textBox4.Text = dtdt.Rows[0][8].ToString();


                this.textBox6.Text = dtdt.Rows[0][10].ToString();
                this.textBox5.Text = dtdt.Rows[0][11].ToString();
                this.textBox7.Text = dtdt.Rows[0][12].ToString();
                this.textBox8.Text = dtdt.Rows[0][13].ToString();
                this.textBox9.Text = dtdt.Rows[0][14].ToString();

                this.textBox10.Text = dtdt.Rows[0][15].ToString();
                this.textBox11.Text = dtdt.Rows[0][16].ToString();

                this.textBox12.Text = dtdt.Rows[0][17].ToString();
                this.dateTimePicker1.Value = Convert.ToDateTime(dtdt.Rows[0][18].ToString());
                this.comboBox2.Text = dtdt.Rows[0][19].ToString();
                this.textBox14.Text = dtdt.Rows[0][20].ToString();
                this.textBox13.Text = dtdt.Rows[0][21].ToString();

                sql = "select empnumber,d_desc,d_portion,d_money from divide where fnumber='"+this.textBox7.Text+"' ";
                DataTable dt = data.Query(sql);
                this.dataGridView1.DataSource = dt;

                if (this.radioButton1.Checked == true)
                {
                    this.radioButton2.Enabled = false;
                    this.radioButton2.Text = "房屋已出售";
                }
                if (this.radioButton2.Checked == true)
                {
                    this.radioButton1.Enabled = false;
                    this.radioButton1.Text = "租赁期未到";
                }

            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                string emp = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult da = MessageBox.Show("确定要删除吗?", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (da == DialogResult.OK)
                {
                    sql = "delete from divide where empnumber='" + emp + "' and fnumber='" + this.textBox7.Text + "'";
                    int i = data.RunSql(sql);
                    if (i > 0)
                    {
                        //MessageBox.Show("删除成功");
                        canm(this,e);
                    }
                }
            }
            else
            {
                MessageBox.Show("当前没有可删除的数据");
            }
        }
        private void canm(object sender,EventArgs e)
        {
            string sql = "select empnumber,d_desc,d_protion,d_money from divide where fnumber='"+this.textBox7.Text+"'";
            DataTable dt = data.Query(sql);
            this.dataGridView1.DataSource = dt;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double i = Convert.ToDouble(this.textBox9.Text);
                double j = Convert.ToDouble(this.textBox10.Text);
                double s = i + j;
                this.textBox11.Text = s.ToString();
            }
            catch
            {
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double i = Convert.ToDouble(this.textBox9.Text);
                double j = Convert.ToDouble(this.textBox10.Text);
                double s = i + j;
                this.textBox11.Text = s.ToString();
            }
            catch
            {
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double i = Convert.ToDouble(this.textBox11.Text);
                double j = Convert.ToDouble(this.textBox12.Text);
                if (j > 100)
                {
                    MessageBox.Show("分成比例过大");
                    this.textBox12.Text = "0.00";
                }
                else
                {
                    double s = j / 100 * i;
                    this.textBox13.Text = s.ToString();
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
                addfencheng addf = new addfencheng();
                addf.stt = this.textBox7.Text;
                addf.all_money = Convert.ToDouble(this.textBox13.Text);
                addf.cam+=new addfencheng.camEventHandler(canm);
                addf.Show();
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                addfencheng addff = new addfencheng();
                addff.emp_num = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                addff.f_num = this.textBox7.Text;
                addff.d_desc = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                addff.d_ption = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
              addff.cam+=new addfencheng.camEventHandler(canm);
              addff.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool sell;
            DateTime date;
            string f_num, wu_name, yezhu_name, kh_type, kh_name, kh_num, kh_tele, kh_mob, kh_cdk, kh_address, ht_money, ht_num, kh_money, yz_money, all_money, ticheng, f_fukuan, beizhu, tc_money;
            f_num = this.label2.Text;
            wu_name = this.label4.Text;
            yezhu_name = this.label6.Text;
            sell = this.radioButton1.Checked;
            kh_type = this.comboBox1.Text;
            kh_name = this.textBox2.Text;
            kh_num = this.textBox1.Text;
            kh_tele = this.textBox4.Text;
            kh_mob = this.textBox3.Text;
            kh_address = this.textBox6.Text;
            kh_cdk = this.textBox5.Text;
            ht_num = this.textBox7.Text;
            ht_money = this.textBox8.Text;
            f_fukuan = this.comboBox2.Text;
            kh_money = this.textBox9.Text;
            yz_money = this.textBox10.Text;
            all_money = this.textBox11.Text;
            ticheng = this.textBox12.Text;
            tc_money = this.textBox13.Text;
            date = this.dateTimePicker1.Value;
            beizhu = this.textBox14.Text;
            if (update == false)
            {
                if (sell == false)
                {
                    if (this.dateTimePicker1.Value <= DateTime.Now.Date.AddDays(1))
                    {
                        MessageBox.Show("租赁期时间大于当前时间");
                    }
                }
            }
            if (update == false)
            {
                sql = "insert into htnews (sell_or_lend,f_num,wu_name,yezhu_name,kh_type,kh_num,kh_name,kh_tele,kh_mob,kh_address,kh_cdk,ht_num,ht_money,kh_money,yz_money,all_money,ticheng,date,beizhu,f_fukuan,tc_money,qy_date) values ('" + sell + "','" + f_num + "','" + wu_name + "','" + yezhu_name + "','" + kh_type + "','" + kh_num + "','" + kh_name + "','" + kh_tele + "','" + kh_mob + "','" + kh_address + "','" + kh_cdk + "','" + ht_num + "','" + ht_money + "','" + kh_money + "','" + yz_money + "','" + all_money + "','" + ticheng + "','" + date + "','" + beizhu + "','" + f_fukuan + "','" + tc_money + "',getdate())";
            }
            if (update == true)
            {
                sql = "update htnews set sell_or_lend='" + sell + "',kh_type='" + kh_type + "',kh_num='" + kh_num + "',kh_name='" + kh_name + "',kh_tele='" + kh_tele + "',kh_mob='" + kh_mob + "',kh_address='" + kh_address + "',kh_cdk='" + kh_cdk + "',ht_money='" + ht_money + "',kh_money='" + kh_money + "',yz_money='" + yz_money + "',all_money='" + all_money + "',ticheng='" + ticheng + "',date='" + date + "',beizhu='" + beizhu + "',f_fukuan='" + f_fukuan + "',tc_money='" + tc_money + "' where ht_num='" + ht_num + "' ";
            }
            int p = data.RunSql(sql);
            if (p > 0)
            {
                string sgl = "update fangyuan set zhuangtai='已经成交' where bianhao='" + f_num + "'";
                int i = data.RunSql(sgl);
                if (i > 0)
                {
                    MessageBox.Show("操作成功！");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("操作失败！");
                return;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {
                this.label17.Text = "元";
                this.label29.Visible = false;
                this.dateTimePicker1.Visible = false;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked == true)
            {
                this.label17.Text = "元/月";
                this.label29.Visible = true;
                this.dateTimePicker1.Visible = true;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "新客户")
            {
                string da = "yyyyMMddHHmmss";
                this.textBox1.Text = "KH"+DateTime.Now.ToString(da);
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox6.Text = "";
            }
        }

    }
}
