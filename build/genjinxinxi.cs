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
    public partial class genjinxinxi : Form
    {
        public genjinxinxi()
        {
            InitializeComponent();
        }
        #region 房源跟进
        public string Fnumber;
        public genjinxinxi(string FNumber)
        {
            InitializeComponent();
            Fnumber = FNumber;
        }

        FollowInfo FInfo = new FollowInfo();
        bool FFollow = false;
        public genjinxinxi(FollowInfo followInfo, bool bb)
        {
            InitializeComponent();
            FInfo = followInfo;
            FFollow = bb;
        }
        #endregion
        Database data = new Database();
        private void genjinxinxi_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "当次提醒";
            comboBox1.Items.Add("当次提醒");
            comboBox1.Items.Add("每次提醒");
            comboBox1.Items.Add("每月提醒");
            comboBox1.Items.Add("每年提醒");
            string sql = "select * from empl_info";
            DataTable dt = data.Query(sql);

            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "_name";
            string sqla = "select * from f_genjin";
            DataTable dd = data.Query(sqla);
            comboBox2.DataSource = dd;
            comboBox2.DisplayMember = "f_genjin";
            if (Fnumber != "")
            {
                textBox1.Text = Fnumber;
            }
            if (FInfo.neirong != null && FFollow == true)
            {
                textBox1.Text = FInfo.bianhao;
                string[] str = FInfo.genjin_time.ToString().Split(' ');
                dateTimePicker1.Text = str[0].ToString();
                dateTimePicker3.Text = str[1].ToString();
                comboBox2.Text = FInfo.f_genjin;
                comboBox3.Text = FInfo.genjinren;
                textBox4.Text = FInfo.neirong;
               
                string sqld = "select * from f_genjin_fy where genjin_time='" + FInfo.genjin_time + "'";
                DataTable dbt = data.Query(sqld);
                foreach (DataRow dr in dbt.Rows)
                {
                    FInfo.iftixing = dr["iftixing"].ToString();
                }
                if (FInfo.iftixing == "1")
                {
                    checkBox1.Checked = true;
                    comboBox1.Text = FInfo.tixing_type;
                    dateTimePicker2.Text = FInfo.tixing_date;
                    dateTimePicker4.Text = FInfo.tixing_time;


                }
                else
                {
                    checkBox1.Checked = false;
                }
                if (comboBox1.Text != "")
                {
                    comboBox1.Text = FInfo.tixing_type;
                }
                else
                {
                    comboBox1.Text = "当次提醒";
                }
                dateTimePicker2.Text = FInfo.tixing_date;
                dateTimePicker4.Text = FInfo.tixing_time;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox2.Text == "")
            {
                MessageBox.Show("跟进方式不能为空");
                return;

            }
            if (this.comboBox3.Text == "")
            {
                MessageBox.Show("跟进员工不能为空");
                return;
            }
            if (this.textBox4.Text == "")
            {
                MessageBox.Show("跟进信息不能为空");
                return;
            }

            FollowInfo followinfo = new FollowInfo();
            followinfo.bianhao = this.textBox1.Text;
            followinfo.f_genjin = this.comboBox2.Text;
            followinfo.neirong = this.textBox4.Text;
            followinfo.genjin_time = Convert.ToDateTime(this.dateTimePicker1.Text + " " + this.dateTimePicker3.Text);
            followinfo.genjinren = this.comboBox3.Text;
            if (this.checkBox1.Checked == true)
            {
                followinfo.tixing_type = this.comboBox1.Text;
                followinfo.tixing_date = this.dateTimePicker2.Text;
                followinfo.tixing_time = this.dateTimePicker4.Text;
                followinfo.iftixing = "1";
            }
            if (this.checkBox1.Checked == false)
            {
                followinfo.tixing_time = "";
                followinfo.tixing_type = "";
                followinfo.tixing_date = "";
                followinfo.iftixing = "0";
            }

            if (FInfo.neirong != null && FFollow == true)
            {
                try
                {
                    string strSql = "update f_genjin_fy set bianhao='"+followinfo.bianhao+"',genjin_time='"+followinfo.genjin_time+"',f_genjin='"+followinfo.f_genjin+"',genjinren='"+followinfo.genjinren+"',neirong='"+followinfo.neirong+"',iftixing='"+followinfo.iftixing+"',tixing_type='"+followinfo.tixing_type+"',tixing_date='"+followinfo.tixing_date+"',tixing_time='"+followinfo.tixing_time+"' where genjin_time='"+followinfo.genjin_time+"'";
                    int j = data.RunSql(strSql);
                    if (j > 0)
                    {
                        MessageBox.Show("信息修改成功");
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("更新失败");
                }
            }


            if (Fnumber != null)
            {
                try
                {
                    string strsql = "insert into f_genjin_fy(bianhao,genjin_time,f_genjin,genjinren,neirong,iftixing,tixing_type,tixing_date,tixing_time) values('"+followinfo.bianhao+"','"+followinfo.genjin_time+"','"+followinfo.f_genjin+"','"+followinfo.genjinren+"','"+followinfo.neirong+"','"+followinfo.iftixing+"','"+followinfo.tixing_type+"','"+followinfo.tixing_date+"','"+followinfo.tixing_time+"')";
                    int i = data.RunSql(strsql);
                    if (i > 0)
                    {
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                }
                catch
                {

                }
            }
                
        }
    }
}
