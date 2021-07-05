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
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }
        public string idNum;
        public int se_num;
        Database data = new Database();
        public delegate void freshdtvEventHandler(object sender, eventArgs2 e);//委托的定义
        public event freshdtvEventHandler freshdtv;//事件的定义

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("请输入员工的编号","信息提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                return;
            }
            if (this.textBox2.Text.Trim() == "")
            {
                MessageBox.Show("员工姓名不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.textBox3.Text.Trim() == "")
            {
                MessageBox.Show("员工身份证号不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.textBox4.Text.Trim() == "")
            {
                MessageBox.Show("员工联系电话不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.textBox5.Text.Trim() == "")
            {
                MessageBox.Show("员工籍贯不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.richTextBox1.Text.Trim() == "")
            {
                MessageBox.Show("员工备注不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string z1 = this.textBox1.Text.Trim();
            string z2 = this.textBox2.Text.Trim();
            string z3 = this.textBox3.Text.Trim();
            string z4 = this.textBox4.Text.Trim();
            string z5 = this.textBox5.Text.Trim();
            string z6 = this.textBox6.Text.Trim();
            string xx = this.richTextBox1.Text.Trim();
            string c1 = this.comboBox1.Text.ToString().Trim();
            string c2 = this.comboBox2.Text.ToString().Trim();
            string c3 = this.comboBox3.Text.ToString().Trim();
            DateTime chushengdt = this.dateTimePicker1.Value;
            DateTime jiuzhidt = this.dateTimePicker2.Value;
            SqlParameter[] para ={
                                 
                              
                            data.MakeInParam("@z1",SqlDbType.VarChar,z1.ToString()),
                            data.MakeInParam("@z2",SqlDbType.VarChar,z2.ToString()),
                            data.MakeInParam("@z3",SqlDbType.VarChar,z3.ToString()),
                            data.MakeInParam("@z4",SqlDbType.VarChar,z4.ToString()),
                            data.MakeInParam("@z5",SqlDbType.VarChar,z5.ToString()),
                            data.MakeInParam("@z6",SqlDbType.VarChar,z6.ToString()),
                            data.MakeInParam("@xx",SqlDbType.VarChar,xx.ToString()),
                            data.MakeInParam("@c1",SqlDbType.VarChar,c1.ToString()),
                            data.MakeInParam("@c2",SqlDbType.VarChar,c2.ToString()),
                            data.MakeInParam("@c3",SqlDbType.VarChar,c3.ToString()),
                            data.MakeInParam("@chudt",SqlDbType.DateTime,Convert.ToDateTime(chushengdt)),
                           data.MakeInParam("@rudt",SqlDbType.DateTime,Convert.ToDateTime(jiuzhidt)),
                        
            };
            string sql = "";
            if (idNum == null)
            {
                sql = "insert into empl_info (_num,_name,_cdk,_tel,_jiguan,_addr,_sex,_xueli,_hunyin,_chushengdt,_jiuzhidt,_beizhu) values (@z1,@z2,@z3,@z4,@z5,@z6,@c1,@c2,@c3,@chudt,@rudt,@xx)";

            }
            else
            {
                sql = "update empl_info set _num=@z1,_name=@z2,_cdk=@z3,_tel=@z4,_jiguan=@z5,_addr=@z6,_sex=@c1,_xueli=@c2,_hunyin=@c3,_chushengdt=@chudt,_jiuzhidt=@rudt,_beizhu=@xx where _num='" + idNum + "'";

            }
            int i = data.RunSql(sql, para);
            if (i > 0)
            {
                DialogResult aa = MessageBox.Show("更新员工信息成功！");

                if (aa == DialogResult.OK)
                {
                    freshdtvEventHandler hand = freshdtv;
                    if (hand != null)
                    {
                        eventArgs2 eva = new eventArgs2();

                        eva.ss_num = se_num;
                        hand(this, eva);


                    }

                }




                this.Close();

            }
            else
            {
                MessageBox.Show("添加信息失败！");

            }

        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            if (idNum == null)
            {

                this.comboBox1.Text = this.comboBox1.Items[0].ToString().Trim();
                this.comboBox2.Text = this.comboBox2.Items[0].ToString().Trim();
                this.comboBox3.Text = this.comboBox3.Items[0].ToString().Trim();


                this.textBox1.Enabled = false;
                string da = "yyyyMMddHHmmss";
                this.textBox1.Text = "HP" + DateTime.Now.ToString(da);
            }
            else
            {
                string sql = "select * from empl_info where _num='" + idNum + "'";
               DataTable dt = data.Query(sql);
               if (dt.Rows.Count > 0)
               {
                   this.textBox1.Enabled = false;
                   this.textBox1.Text = dt.Rows[0][2].ToString();
                   this.textBox2.Text = dt.Rows[0][1].ToString();
                   this.textBox3.Text = dt.Rows[0][3].ToString();
                   this.textBox4.Text = dt.Rows[0][4].ToString();
                   this.textBox5.Text = dt.Rows[0][9].ToString();
                   this.textBox6.Text = dt.Rows[0][5].ToString();
                   this.richTextBox1.Text = dt.Rows[0][12].ToString();
                   this.comboBox1.Text = dt.Rows[0][6].ToString().Trim();
                   this.comboBox2.Text = dt.Rows[0][7].ToString().Trim();
                   this.comboBox3.Text = dt.Rows[0][8].ToString().Trim();
                   this.dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0][10].ToString());
                   this.dateTimePicker2.Value = Convert.ToDateTime(dt.Rows[0][11].ToString());
               }
               else
               {
                   MessageBox.Show("没有找到数据");
               }

            }
        }


    }
}
