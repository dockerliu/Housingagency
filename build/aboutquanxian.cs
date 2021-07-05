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
    public partial class aboutquanxian : Form
    {
        public aboutquanxian()
        {
            InitializeComponent();
        }
        Database data = new Database();
        public int did;
        public string ename;
        public int ss_num;
        public int id;
        public delegate void freshdtvEventHandler(object sender,eventArgs2 e);
        public event freshdtvEventHandler freshdtv;
        private void aboutquanxian_Load(object sender, EventArgs e)
        {
            if (did == 1)
            {
                try
                {
                    string sql = "select * from jibie where _jibie='"+ename+"'";
                    DataTable dt = data.Query(sql);
                    this.textBox1.Text = dt.Rows[0][1].ToString();
                    this.checkBox1.Checked = Convert.ToBoolean(dt.Rows[0][2]);
                    this.checkBox2.Checked = Convert.ToBoolean(dt.Rows[0][3]);
                    this.checkBox3.Checked = Convert.ToBoolean(dt.Rows[0][4]);
                    this.checkBox4.Checked = Convert.ToBoolean(dt.Rows[0][5]);
                    this.checkBox5.Checked = Convert.ToBoolean(dt.Rows[0][6]);
                    id = Convert.ToInt32(dt.Rows[0][0].ToString());


                }
                catch
                {
                    MessageBox.Show("数据出现错误");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入权限组的名称");
                return;
            }
            try
            {
                string name = this.textBox1.Text;
                bool sta1, sta2, sta3, sta4, sta5;
                sta1 = this.checkBox1.Checked;
                sta2 = this.checkBox2.Checked;
                sta3 = this.checkBox3.Checked;
                sta4 = this.checkBox4.Checked;
                sta5 = this.checkBox5.Checked;
                string sql = "";
                if (did == 0)
                {
                    sql = "insert into jibie(_jibie,_richang,_fangyuan,_kehu,_neibu,_xitong) values('" + name + "','" + sta1 + "','" + sta2 + "','" + sta3 + "','" + sta4 + "','" + sta5 + "')";

                }
                if (did == 1)
                {
                    sql = "update jibie set _jibie='" + name + "',_richang='" + sta1 + "',_fangyuan='" + sta2 + "',_kehu='" + sta3 + "',_neibu='" + sta4 + "',_xitong='" + sta5 + "' where id='" + id + "'";
                }
                int dd = data.RunSql(sql);
                if (dd > 0)
                {
                    MessageBox.Show("操作成功");
                    freshdtvEventHandler hand = freshdtv;
                    if (hand != null)
                    {
                        eventArgs2 avs = new eventArgs2();
                        avs.ss_num = ss_num;
                        hand(this, avs);
                    }
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("操作失败");

            }
            finally
            {
                data.Close();
            }
        }
    }
}
