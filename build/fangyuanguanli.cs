using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace build
{
    public partial class fangyuanguanli : Form
    {
        public fangyuanguanli()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void fangyuanguanli_Load(object sender, EventArgs e)
        {
            string sql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as  置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan order by bianhao";
            DataTable da = data.Query(sql);
            this.dataGridView1.DataSource = da;



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sql = "select * from fangyuan where bianhao='"+str+"'";
                DataTable da = data.Query(sql);
                foreach (DataRow dr in da.Rows)
                {
                    bool lend = Convert.ToBoolean(dr["lend"]);
                    if (lend == false)
                    {
                        this.checkBox4.Checked = false;
                        this.textBox3.Text = "";
                        this.textBox4.Text = "";
                    }
                    else
                    {
                        this.checkBox4.Checked = true;
                        this.textBox3.Text = dr["lend_price"].ToString();
                        this.textBox4.Text = dr["lend_shuoming"].ToString();
                    }
                    bool sele = Convert.ToBoolean(dr["sell"]);
                    if (sele == false)
                    {
                        this.checkBox5.Checked = false;
                        this.textBox5.Text = "";
                        this.textBox6.Text = "";
                    }
                    else
                    {
                        this.checkBox5.Checked = true;
                        this.textBox5.Text = dr["sell_price"].ToString();
                        this.textBox6.Text = dr["sell_shuoming"].ToString();
                    }
                    if (lend == true && sele == true)
                    {
                        this.checkBox4.Checked = true;
                        this.checkBox5.Checked = true;
                        this.textBox3.Text = dr["lend_price"].ToString();
                        this.textBox4.Text = dr["lend_shuoming"].ToString();
                        this.textBox5.Text = dr["sell_price"].ToString();
                        this.textBox6.Text = dr["sell_shuoming"].ToString();
                    }
                    this.textBox7.Text = dr["zhuangtai"].ToString();
                    this.textBox8.Text = dr["guwen"].ToString();
                    this.textBox9.Text = dr["jiancheng"].ToString();
                    this.textBox10.Text = dr["wuye"].ToString();
                    this.textBox11.Text = dr["yongtu"].ToString();
                    this.textBox12.Text = dr["wuye_type"].ToString();
                    this.textBox13.Text = dr["area"].ToString();
                    this.textBox14.Text = dr["chengdu"].ToString();
                    this.textBox15.Text = dr["fang_type"].ToString();
                    this.textBox16.Text = dr["huxing"].ToString();
                    this.textBox17.Text = dr["mianji"].ToString();
                   string LagerNumber= dr["z_floor"].ToString();
                   string sand = dr["n_floor"].ToString();
                   this.textBox18.Text = sand + "/" + LagerNumber;
                   this.textBox19.Text = dr["jichusheshi"].ToString();
                   this.textBox20.Text = dr["peitaosheshi"].ToString();
                   this.textBox21.Text = dr["address"].ToString();
                   this.textBox22.Text = dr["xiangxi"].ToString();
                   this.textBox23.Text = dr["yezhu_name"].ToString();
                   this.textBox24.Text = dr["tele"].ToString();
                   this.textBox25.Text = dr["Mobliephone"].ToString();
                   this.textBox26.Text = dr["yezhu_address"].ToString();
                   this.textBox27.Text = dr["beizhu"].ToString();

                   string area = dr["area"].ToString();
                   string address = dr["address"].ToString();
                   string sql_a = " select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as  置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where(area=@area or address=@address) and bianhao!='"+str+"'";

                   SqlParameter[] par = { 
                                        data.MakeInParam("@area",SqlDbType.VarChar,area),
                                        data.MakeInParam("@address",SqlDbType.VarChar,address),
                                        
                                        };
                   DataTable dt = data.Query(sql_a, par);
                   this.dataGridView2.DataSource = dt;

                }
            }
            catch
            {
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable da;
            if (this.checkBox1.Checked == true)
            {
                string sql = " select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as  置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where lend=1";
                 da = data.Query(sql);
                this.dataGridView1.DataSource = da;
            }
            if (this.checkBox1.Checked == true && this.checkBox2.Checked == true)
            {
                string sql = " select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as  置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan";
                 da = data.Query(sql);
                this.dataGridView1.DataSource = da;
            }
            if (this.checkBox1.Checked == false)
            {
                string sql = " select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as  置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where sell=1";
                da = data.Query(sql);
                this.dataGridView1.DataSource = da;
            }
            if (this.checkBox1.Checked == false && this.checkBox2.Checked == false)
            {
                string sql = " select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as  置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan";
                da = data.Query(sql);
                this.dataGridView1.DataSource = da;
            }
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            DataTable da;
            if (this.checkBox2.Checked == true)
            {
                string sql = " select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as  置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where sell=1";
                da = data.Query(sql);
                this.dataGridView1.DataSource = da;

            }
            if (this.checkBox2.Checked == true && this.checkBox1.Checked == true)
            {
                string sql = " select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as  置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan";
                da = data.Query(sql);
                this.dataGridView1.DataSource = da;
            }
            if (this.checkBox2.Checked == false)
            {
                string sql = " select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as  置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where lend=1";
                da = data.Query(sql);
                this.dataGridView1.DataSource = da;

            }
            if (this.checkBox2.Checked == false && this.checkBox1.Checked == false)
            {
                string sql = " select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 位于层数,guwen as  置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan";
                da = data.Query(sql);
                this.dataGridView1.DataSource = da;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkBox3.Checked == true)
                {
                    checkBox3.Enabled = true;
                    string SelectSql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称, huxing as 户型结构,mianji as 建筑面积, area as 所在区域, z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份, address as 具体地址 from fangyuan where ";
                    if (textBox2.Text != "")
                    {
                        DateTime dateTime = DateTime.Now.Date.AddDays(-Convert.ToInt32(textBox2.Text));
                        SelectSql = SelectSql + "date<='" + DateTime.Now.Date.AddDays(1) + "' and date>='" + dateTime + "' ";
                    }
                    DataTable da = data.Query(SelectSql);
                    this.dataGridView1.DataSource = da;
                    this.dataGridView1.Refresh();
                    this.checkBox1.Enabled = false;
                    this.checkBox2.Enabled = false;
                }
                else
                {
                    this.textBox2.Text = "";
                    this.checkBox1.Enabled = true;
                    this.checkBox2.Enabled = true;
                    string sql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称, huxing as 户型结构,mianji as 建筑面积, area as 所在区域, z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份, address as 具体地址 from fangyuan ";
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string SelectSql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称, huxing as 户型结构,mianji as 建筑面积, area as 所在区域, z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份, address as 具体地址 from fangyuan where ";
            try
            {
                if (this.textBox1.Text == "")
                {
                    SelectSql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态,wuye as 物业名称, huxing as 户型结构,mianji as 建筑面积, area as 所在区域, z_floor as 总层数,n_floor as 位于层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份, address as 具体地址 from fangyuan";
                }
                if (this.textBox1.Text != "")
                {
                    SelectSql = SelectSql + "(bianhao like '%"+this.textBox1.Text+"%' or date like '%"+this.textBox1.Text+"%' or wuye like '%"+this.textBox1.Text+"%' or fang_type like '%"+this.textBox1.Text+"%' or area like '%"+this.textBox1.Text+"%' or address like '%"+this.textBox1.Text+"%')";

                }
                DataTable da = data.Query(SelectSql);
                this.dataGridView1.DataSource = da;
                this.textBox1.Text = "";
            }
            catch
            {
            }
            finally
            {
                data.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows.Count > 0)
                {
                    for (int i = this.dataGridView1.SelectedRows.Count; i > 0; i--)
                    {
                        string id = this.dataGridView1.SelectedRows[i - 1].Cells[0].Value.ToString();
                        DialogResult df = MessageBox.Show("确定要删除选择的信息吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (df == DialogResult.OK)
                        {
                            string sql = "delete from fangyuan where bianhao='" + id + "'";
                            int a = data.RunSql(sql);
                            if (a > 0)
                            {
                                MessageBox.Show("数据删除成功");
                            }
                        }
                    }
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

        //数据导出Excel文件中.
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "xls";
                saveFileDialog.Filter = "Excel文件(*.xls)|*.xls";
                saveFileDialog.FileName = "房源信息";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.CreatePrompt = true;
                saveFileDialog.Title = "导出到EXCEL";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName == "")
                {
                    return;
                }
                Stream myStream;
                myStream = saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string str="";
                try
                {
                    for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                    {
                        if (i > 0)
                        {
                            str += "\t";
                        }
                        str += dataGridView1.Columns[i].HeaderText;
                    }
                    sw.WriteLine(str);

                    for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                    {
                        string tempStr = "";
                        for (int k = 0; k < this.dataGridView1.Columns.Count; k++)
                        {
                            if (k > 0)
                            {
                                tempStr += "\t";
                            }
                            tempStr += this.dataGridView1.Rows[j].Cells[k].Value.ToString();
                        }
                        sw.WriteLine(tempStr);
                       
                    }
                }
                catch
                {
                }
                finally
                {
                    sw.Close();
                    myStream.Close();

                }
            }
        }
    }
}
