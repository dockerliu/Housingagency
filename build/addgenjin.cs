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
    public partial class addgenjin : Form
    {
        public addgenjin()
        {
            InitializeComponent();
        }
        public string khid;
        public addgenjin(string khidNo)
        {
            InitializeComponent();
            khid = khidNo;

        }
        genjinkehu gjkh = new genjinkehu();
        bool abc = false;
        public addgenjin(genjinkehu gjkehu, bool bb)
        {
            InitializeComponent();
            gjkh = gjkehu;
            abc = bb;
        }
        Database data = new Database();

        private void button1_Click(object sender, EventArgs e)
        {
            genjinkehu Genjinkehu = new genjinkehu();
            Genjinkehu.bianhao = this.textBox1.Text;
            Genjinkehu.f_genjin = this.comboBox2.Text;
            Genjinkehu.neirong = this.textBox4.Text;
            Genjinkehu.genjin_time = Convert.ToDateTime(dateTimePicker1.Text + "" + dateTimePicker3.Text);
            Genjinkehu.genjinren = this.comboBox3.Text;
            if (checkBox1.Checked == true)
            {
                Genjinkehu.tixing_type = this.comboBox1.Text;
                Genjinkehu.tixing_date = this.dateTimePicker2.Text;
                Genjinkehu.tixing_time = this.dateTimePicker4.Text;
                Genjinkehu.iftixing = "1";
            }
            else
            {
                Genjinkehu.tixing_type = "";
                Genjinkehu.tixing_date = "";
                Genjinkehu.tixing_time = "";
                Genjinkehu.iftixing = "0";
            }
            if (gjkh.neirong != null && abc == true)
            {
                string sql_a = "update f_genjin_kh set genjin_time='" + Genjinkehu.genjin_time + "',f_genjin='" + Genjinkehu.f_genjin + "',genjinren='" + Genjinkehu.genjinren + "',neirong='" + Genjinkehu.neirong + "',iftixing='" + Genjinkehu.iftixing + "',tixing_type='" + Genjinkehu.tixing_type + "',tixing_date='" + Genjinkehu.tixing_date + "',tixing_time='" + Genjinkehu.tixing_time + "' where bianhao='" + Genjinkehu.bianhao + "'";
                int j = data.RunSql(sql_a);
                if (j > 0)
                {
                    MessageBox.Show("修改成功！");
                    this.Close();
                }


            }
            if (khid != null)
            {
                string sql_b = "insert into f_genjin_kh (bianhao,genjinren,neirong,iftixing,tixing_type,genjin_time,tixing_date,tixing_time,f_genjin) values ('" + Genjinkehu.bianhao + "','" + Genjinkehu.genjinren + "','" + Genjinkehu.neirong + "','" + Genjinkehu.iftixing + "','" + Genjinkehu.tixing_type + "','" + Genjinkehu.genjin_time + "','" + Genjinkehu.tixing_date + "','" + Genjinkehu.tixing_time + "','" + Genjinkehu.f_genjin + "')";
                int i = data.RunSql(sql_b);
                if (i > 0)
                {
                    MessageBox.Show("保存成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败");
                }

            }

        }

        private void addgenjin_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "当次提醒";
            comboBox1.Items.Add("当次提醒");
            comboBox1.Items.Add("每次提醒");
            comboBox1.Items.Add("每月提醒");
            comboBox1.Items.Add("每年提醒");
            string sql_c = "select * from empl_info";
            DataTable dt = data.Query(sql_c);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "_name";
            string sql_d = "select * from f_genjin";
            DataTable dd = data.Query(sql_d);
            comboBox2.DataSource = dd;
            comboBox2.DisplayMember = "f_genjin";
            if (khid != "")
            {
                textBox1.Text = khid;
            }
            if (gjkh.neirong != null && abc == true)
            {
                textBox1.Text = gjkh.bianhao;
                string[] str = gjkh.genjin_time.ToString().Split(' ');
                dateTimePicker1.Text = str[0].ToString();
                dateTimePicker3.Text = str[1].ToString();
                comboBox2.Text = gjkh.f_genjin;
                comboBox3.Text = gjkh.genjinren;
                textBox4.Text = gjkh.neirong;
                string sql_e = "select * from f_genjin_kh where genjin_time='" + gjkh.genjin_time + "'";
                DataTable dbt = data.Query(sql_e);
                foreach (DataRow dr in dbt.Rows)
                {
                    gjkh.iftixing = dr["iftixing"].ToString();
                }
                if (gjkh.iftixing == "1")
                {
                    checkBox1.Checked = true;
                    checkBox1.Text = gjkh.tixing_type;
                    dateTimePicker2.Text = gjkh.tixing_date;
                    dateTimePicker4.Text = gjkh.tixing_time;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                if (comboBox1.Text != "")
                {
                    comboBox1.Text = gjkh.tixing_type;
                }
                else
                {
                    comboBox1.Text = "当次提醒";
                }
                dateTimePicker2.Text = gjkh.tixing_date;
                dateTimePicker4.Text = gjkh.tixing_time;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
