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
    public partial class AboutEmployee : Form
    {
        public AboutEmployee()
        {
            InitializeComponent();
        }

        Database data = new Database();
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string sql = "select _name,_num,_tel,_addr,_xueli,_hunyin,_cdk,_chushengdt,_jiuzhidt,_beizhu,_sex,_jiguan from empl_info where _name like '%"+this.textBox1.Text.Trim()+"'";
            DataTable da = data.Query(sql);
            this.dataGridView1.DataSource = da;
        }

        private void AboutEmployee_Load(object sender, EventArgs e)
        {
            frushdtv(0);
        }
        private void frushdtv(int se_num)
        {
            string sql = "select _name,_num,_tel,_addr,_xueli,_hunyin,_cdk,_chushengdt,_jiuzhidt,_beizhu,_sex,_jiguan from empl_info";
            DataTable da = data.Query(sql);
            this.dataGridView1.DataSource = da;
            if (this.dataGridView1.Rows.Count > 0)
            {
                this.dataGridView1.Rows[se_num].Selected = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int st = this.dataGridView1.SelectedRows[0].Index;
                string str = this.dataGridView1.Rows[st].Cells[1].Value.ToString();
                AddEmployee aa = new AddEmployee();
                aa.freshdtv += new AddEmployee.freshdtvEventHandler(frushdtv);
                aa.idNum = str;
                aa.se_num = this.dataGridView1.SelectedRows[0].Index;
                aa.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有信息可以修改，或者你没有选择数据");
            }
        }
        private void frushdtv(object sender, eventArgs2 e)
        {
            frushdtv(e.ss_num);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                DialogResult df = MessageBox.Show("确定要删除该记录吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (df == DialogResult.OK)
                {
                    int st = this.dataGridView1.SelectedRows[0].Index;
                    string str = this.dataGridView1.Rows[st].Cells[1].Value.ToString();
                    string sql = "delete from empl_info where _num='" + str + "'";
                    int i = data.RunSql(sql);
                    if (i > 0)
                    {
                        frushdtv(0);
                    }
                    else
                    {
                        MessageBox.Show("信息删除失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("当前没有可供删除的信息");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddEmployee adddnew = new AddEmployee();
          
            adddnew.ShowDialog();
        }
    }

}
