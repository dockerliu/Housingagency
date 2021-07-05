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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string Fnumber;
        public Form1(string FNumber)
        {
            Fnumber = FNumber;
        }
        FollowInfo FInfo = new FollowInfo();
        bool FFollow = false;
        Database data = new Database();
        public Form1(FollowInfo followInfo, bool bb)
        {
            FInfo = followInfo;
            FFollow = bb;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.Text = "当次提醒";
            this.comboBox1.Items.Add("每次提醒");
            this.comboBox1.Items.Add("每日提醒");
            this.comboBox1.Items.Add("每月提醒");
            this.comboBox1.Items.Add("每年提醒");
            string sql = "select * from empl_info";
            DataTable dt = data.Query(sql);
            this.comboBox3.DataSource = dt;
            this.comboBox3.DisplayMember = "_name";

            string sql_a = "select * from f_genjin";
            DataTable dd = data.Query(sql_a);
            this.comboBox2.DataSource = dd;
            this.comboBox2.DisplayMember = "f_genjin";

            if (Fnumber != "")
            {
                this.textBox1.Text = Fnumber;
            }
            if (FInfo.neirong != null && FFollow == true)
            {
                this.textBox1.Text = FInfo.bianhao;
                string[] str = FInfo.genjin_time.ToString().Split(' ');
                this.dateTimePicker1.Text = str[0].ToString();
                this.dateTimePicker3.Text = str[1].ToString();
                this.comboBox2.Text = FInfo.f_genjin;
                this.comboBox3.Text = FInfo.genjinren;
                this.textBox4.Text = FInfo.neirong;
                string sqlid = "select * from f_genjin_fy where genjin_time='" + FInfo.genjin_time + "'";
                DataTable ddt = data.Query(sqlid);
                foreach (DataRow dr in ddt.Rows)
                {
                    FInfo.iftixing = dr["iftixing"].ToString();
                }
                if (FInfo.iftixing == "1")
                {
                    checkBox1.Checked = true;
                    this.comboBox1.Text = FInfo.tixing_type;
                    this.dateTimePicker2.Text = FInfo.tixing_date;
                    this.dateTimePicker4.Text = FInfo.tixing_time;
                }
                else
                {
                    this.checkBox1.Checked = false;
                }
                if (this.comboBox1.Text != "")
                {
                    this.comboBox1.Text = FInfo.tixing_type;

                }
                else
                {
                    this.comboBox1.Text = "当次提醒";

                }
                this.dateTimePicker2.Text = FInfo.tixing_date;
                this.dateTimePicker4.Text = FInfo.tixing_time;
            }

        }
    }
}
