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
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }
        Database data = new Database();
        public string str345;
        private void mainform_Load(object sender, EventArgs e)
        {
            this.MaximumSize.Height.CompareTo(this.Height);
            if (login._RCGL == true)
            {
                this.pictureBox7.Enabled = true;
            }
            else
            {
                this.pictureBox7.Enabled = false;
            }
            if (login._FYGL == true)
            {
                this.pictureBox11.Enabled = true;
            }
            else
            {
                this.pictureBox11.Enabled = false;
            }
            if (login._KHGL == true)
            {
                this.pictureBox10.Enabled = true;
            }
            else
            {
                this.pictureBox10.Enabled = false;
            }
            if (login._NBGL == true)
            {
                this.pictureBox9.Enabled = true;
            }
            else
            {
                this.pictureBox9.Enabled = false;
            }
            if (login._XTSZ == true)
            {
                this.pictureBox8.Enabled = true;
            }
            else
            {
                this.pictureBox8.Enabled = false;
            }
            this.panel1.Visible = true;
            string sql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在的区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan order by bianhao";
            DataTable da = data.Query(sql);
            this.dataGridView1.DataSource = da;
            str345 = this.dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString();
           // MessageBox.Show(str345);
           // this.panel1.Visible = true;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            
            this.panel2.Visible = false;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string str;

            try
            {
               str = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                
                string strsql = "select * from fangyuan where bianhao='"+str+"'";
                DataTable dt = data.Query(strsql);
                foreach(DataRow dbl in dt.Rows)
                {
                    try
                    {
                        string area = dbl["area"].ToString();
                        string address = dbl["address"].ToString();
                        string sql_a = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where (area=@area or address=@address) and bianhao!='"+str+"'";
                        SqlParameter[] par ={
                                                data.MakeInParam("@area",SqlDbType.VarChar,area),
                                                data.MakeInParam("@address",SqlDbType.VarChar,address),
                                                
                                           };
                        DataTable dtb = data.Query(sql_a, par);
                        this.dataGridView2.DataSource = dtb;

                    }
                    catch
                    {

                    }
                }

            }
            catch
            {

            }
            try
            {
                str = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sql_genjin = "select f_genjin,genjinren,genjin_time,neirong from f_genjin_fy where bianhao='"+str+"'";
                DataTable dd = data.Query(sql_genjin);
                this.dataGridView3.DataSource = dd;
            }
            catch
            {
            }
            try
            {
                if (this.dataGridView1.RowCount > 0)
                {
                    str = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string strsql = "select wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,yongtu as 物业用途,jiancheng as 建成年份,address as 地址 from fangyuan where bianhao='" + str + "'";
                    DataTable da = data.Query(strsql);
                    this.dataGridView4.DataSource = da;
                }


            }
            catch
            {
                MessageBox.Show("出现问题");
            }
            finally
            {
                data.Close();
            }
            try
            {
                str = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sql_yezhu = "select yezhu_name as 业主名称,tele as 业主电话,Mobliephone as 业主移动电话,yezhu_address as 业主地址 from fangyuan  where bianhao='"+str+"'";
                DataTable db = data.Query(sql_yezhu);
                this.dataGridView5.DataSource = db;
            }
            catch
            {
                
            }
            finally
            {
                data.Close();
            }

        }
        /// <summary>
        /// 查询出租的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                string sql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where lend=1";
                DataTable da = data.Query(sql);
                this.dataGridView1.DataSource = da;
                this.dataGridView1.Refresh();
                    
            }
            if (this.checkBox1.Checked == true && this.checkBox2.Checked == true)
            {
                string sql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan";
                DataTable da = data.Query(sql);
                this.dataGridView1.DataSource = da;
                this.dataGridView1.Refresh();
            }
            if (this.checkBox1.Checked == false)
            {
                string sql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where sell=1";
                DataTable da = data.Query(sql);
                this.dataGridView1.DataSource = da;
                this.dataGridView1.Refresh();
            }
            if (this.checkBox1.Checked == false && this.checkBox2.Checked == false)
            {
                string sql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan";
                DataTable da = data.Query(sql);
                this.dataGridView1.DataSource = da;
                this.dataGridView1.Refresh();
            }

        }
        #region 查询出售的信息
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked == true)
            {
                string sql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where sell=1";
                DataTable da = data.Query(sql);
                this.dataGridView1.DataSource = da;
                this.dataGridView1.Refresh();
            }
            if (this.checkBox1.Checked == true && this.checkBox2.Checked == true)
            {
                string sql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan";
                DataTable da = data.Query(sql);
                this.dataGridView1.DataSource = da;
                this.dataGridView1.Refresh();
            }
            if(this.checkBox2.Checked==false)
            {
                string sql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where lend=1";
                DataTable da = data.Query(sql);
                this.dataGridView1.DataSource = da;
                this.dataGridView1.Refresh();
            }
            if(this.checkBox2.Checked==false && this.checkBox1.Checked==false)
            {
                string sql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan";
                DataTable da = data.Query(sql);
                this.dataGridView1.DataSource = da;
                this.dataGridView1.Refresh();

            }
        }
       

        #endregion

        #region 具体天数查询
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.checkBox3.Checked == true)
                {
                    string selectsql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where ";
                    if (this.textBox1.Text != "")
                    {
                        DateTime dateTime = DateTime.Now.Date.AddDays(-Convert.ToInt32(this.textBox1.Text));
                        selectsql = selectsql + "date<='" + DateTime.Now.AddDays(1) + "'and date>='" + dateTime + "'";
                    }
                    DataTable da = data.Query(selectsql);
                    this.dataGridView1.DataSource = da;
                    this.dataGridView1.Refresh();
                    this.checkBox1.Enabled = false;
                    this.checkBox2.Enabled = false;

                }
                else
                {
                    this.textBox1.Text = "";
                    this.checkBox1.Enabled = true;
                    this.checkBox2.Enabled = true;
                    string sql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan";
                    DataTable da = data.Query(sql);
                    this.dataGridView1.DataSource = da;
                    this.dataGridView1.Refresh();


                }
            }
            catch
            {
            }
            finally
            {
                data.Close();
            }
        }
        #endregion

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            try
            {
                string sesql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where ";
                if (this.textBox2.Text == "")
                {
                    sesql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan";

                }
                else
                {
                    sesql = sesql + "(bianhao like '%" + textBox2.Text + "%' or date like '%" + textBox2.Text + "%' or wuye like '%" + textBox2.Text + "%' or fang_type like '%" + textBox2.Text + "' or area like '%" + textBox2.Text + "%' or address like '%" + textBox2.Text + "%')";
                }
                DataTable da = data.Query(sesql);
                this.dataGridView1.DataSource = da;
                this.textBox2.Text = "";
                this.dataGridView1.Refresh();
            }
            catch
            {
            }
            finally
            {
                data.Close();
            }
        }

        private void pictureBox13_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Bitmap map = new Bitmap(Application.StartupPath + "//img/cz2.jpg");
            this.pictureBox13.Image = map;
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            System.Drawing.Bitmap map = new Bitmap(Application.StartupPath+"//img/cz1.jpg");
            this.pictureBox13.Image = map;
        }
        //刷新按钮功能实现
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan";
                DataTable da = data.Query(sql);
                this.dataGridView1.DataSource = da;
            }
            catch
            {
                MessageBox.Show("数据出现异常");
            }
            finally
            {
                data.Close();
            }
            this.textBox2.Text = "";
            this.checkBox1.Checked = false;
            this.checkBox2.Checked = false;
            this.checkBox3.Checked = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 ||(int)e.KeyChar==8)
            {
                if (this.textBox1.Text.Length < 1)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
                MessageBox.Show("请输入数字");
               
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要退出该系统吗？", "退出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("你确定要退出该系统吗?", "退出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                System.Environment.Exit(0);
            }
        }

        private void mainform_Activated(object sender, EventArgs e)
        {
            if (login._RCGL == true)
            {
                this.pictureBox7.Enabled = true;
            }
            else
            {
                this.pictureBox7.Enabled = false;
            }
            if (login._FYGL == true)
            {
                this.pictureBox11.Enabled = true;
            }
            else
            {
                this.pictureBox11.Enabled = false;

            }
            if(login._KHGL==true)
            {
                this.pictureBox10.Enabled = true;
            }
            else
            {
                this.pictureBox10.Enabled = false;
            }
            if (login._NBGL == true)
            {
                this.pictureBox9.Enabled = true;
            }
            else
            {
                this.pictureBox9.Enabled = false;
            }
            if (login._XTSZ == true)
            {
                this.pictureBox8.Enabled = true;

            }
            else
            {
                this.pictureBox8.Enabled = false;
            }
            string sql = "select bianhao as 编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan order by bianhao";
            DataTable da = data.Query(sql);
            this.dataGridView1.DataSource = da;
        }
        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            LiuLan ss = new LiuLan();
            ss.id = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ss.Show();
        }
        /// <summary>
        /// 报表打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=.;uid=home;pwd=;database=build");
            conn.Open();
            CrystalDecisions.Windows.Forms.CrystalReportViewer view = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            CrystalDecisions.CrystalReports.Engine.ReportDocument document = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            SqlDataAdapter apter = new SqlDataAdapter("select * from fangyuan where bianhao="+this.dataGridView1.CurrentRow.Cells[0].Value.ToString(),conn);
            DataTable da = new DataTable();
            apter.Fill(da);
            document.FileName = "PrintView.rpt";
            document.SetDataSource(da);
            view.ReportSource = document;
            view.PrintReport();//打印报表
            conn.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           try
            {
                LockCreen lockg = new LockCreen();
                lockg.ShowDialog() ;
            }
            catch
            {
            }
        }

        /// <summary>
        /// 对用户名进行查询
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public DataTable Login_out(string UserName)
        {
            SqlParameter[] para = { 
                                   data.MakeInParam("@UserName",SqlDbType.VarChar,UserName),
                                  };
            string strsql = "select * from Login_user where _name=@UserName";
            return data.Query(strsql,para);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Bitmap aa = new Bitmap(Application.StartupPath + "//img/1.jpg");
            this.pictureBox1.Image = aa;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Image = null;
            this.pictureBox1.BackColor = Color.Transparent;
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Bitmap aa = new Bitmap(Application.StartupPath+"//img/2.jpg");
            this.pictureBox6.Image = aa;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox6.Image = null;
            this.pictureBox6.BackColor = Color.Transparent;
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Bitmap aa = new Bitmap(Application.StartupPath+"//img/3.jpg");
            this.pictureBox5.Image = aa;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox5.Image = null;
            this.pictureBox5.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Bitmap aa = new Bitmap(Application.StartupPath+"//img/3.jpg");
            this.pictureBox4.Image = aa;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = null;
            this.pictureBox4.BackColor = Color.Transparent;
        }
        #region 租房查询
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                zufangchaxun zc = new zufangchaxun();
                zc.ShowDialog();
            }
            catch
            {
            }
        }
        #endregion
        /// <summary>
        /// 买房查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                maifangchaxun chaxun = new maifangchaxun();
                chaxun.ShowDialog();
            }
            catch
            {
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                xinzengfangyuan xz = new xinzengfangyuan();
                xz.Show();
            }
            catch
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                xinzengfangyuan xz = new xinzengfangyuan();
                xz.ShowDialog();
            }
            catch
            {
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                xinxi xx = new xinxi();
                xx.ShowDialog();
            }
            catch
            {

            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

            System.Drawing.Bitmap zx = new System.Drawing.Bitmap(Application.StartupPath + "//img/back2.jpg");
            this.BackgroundImage = zx;
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            this.panel3.Visible = true;
            this.panel4.Visible = false;
        
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            System.Drawing.Bitmap zx = new System.Drawing.Bitmap(Application.StartupPath + "//img/back1.jpg");
            this.BackgroundImage = zx;
            this.panel1.Visible = true;
            this.panel3.Visible = false;
            this.panel2.Visible = false;
            this.panel4.Visible = false;
     
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Drawing.Bitmap zx = new System.Drawing.Bitmap(Application.StartupPath + "//img/back3.jpg");
            this.BackgroundImage = zx;
            this.panel1.Visible = false;
            this.panel3.Visible = false;
            this.panel2.Visible = true;
            this.panel4.Visible = false;
         
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                fangyuanguanli gl = new fangyuanguanli();
                gl.ShowDialog();
            }
            catch
            {
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                chengjiao cj = new chengjiao();
                cj.ShowDialog();

            }
            catch
            {
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                fangyuangenjin ff = new fangyuangenjin();
                ff.ShowDialog();

            }
            catch
            {

            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            try
            {
                Kehuguanli ku = new Kehuguanli();
                ku.ShowDialog();
            }
            catch { }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            try
            {
                qianyuechaxun qy = new qianyuechaxun();
                qy.ShowDialog();
            }
            catch
            {
            }

        }

        private void button41_Click(object sender, EventArgs e)
        {
            try
            {
                kehugenjin gj = new kehugenjin();
                gj.ShowDialog();
            }
            catch
            {

            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            laidianjilu ss = new laidianjilu();
            ss.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            System.Drawing.Bitmap zx = new System.Drawing.Bitmap(Application.StartupPath + "//img/back4.jpg");
            this.BackgroundImage = zx;
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = true;
         
            
        }

        private void button47_Click(object sender, EventArgs e)
        {
            try
            {
                fangyuan Fy = new fangyuan();
                Fy.ShowDialog();
            }
            catch
            {
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            try
            {
                tichenghuizong tc = new tichenghuizong();
                tc.ShowDialog();
            }
            catch
            {
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            try
            {
                zonghetongji zt = new zonghetongji();
                zt.ShowDialog();
            }
            catch
            {

            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            try
            {
                tixingguanli tx = new tixingguanli();
                tx.ShowDialog();
            }
            catch
            {
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            try
            {
                tichengmingxi tc = new tichengmingxi();
                tc.ShowDialog();
            }
            catch
            {
            }

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Xtsz xz = new Xtsz();
            xz.ShowDialog();
          
            
        }

        private void button37_Click(object sender, EventArgs e)
        {
         
        }



    }
}
