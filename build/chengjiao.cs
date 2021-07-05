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
    public partial class chengjiao : Form
    {
        public chengjiao()
        {
            InitializeComponent();
        }
        Database data = new Database();
        dl dd = new dl();
        private void chengjiao_Load(object sender, EventArgs e)
        {
            try
            {
                string sql;
                DataTable dt;
                string sql43 = "update fangyuan set zhuangtai='正常状态' where bianhao in(select f_num from htnews where date<(select getdate())and sell_or_lend='false')";
                data.RunSql(sql43);
                sql = "update fangyuan set zhuangtai='已经成交' where bianhao in(select f_num from htnews where date>(select(getdate()) and sell_or_lend='false')";
                data.RunSql(sql);

                 sql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态, wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 所在的层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan";
                 dt = data.Query(sql);
                this.dataGridView1.DataSource = dt;
                sql = "select * from f_sta";
                 dt = data.Query(sql);
                this.comboBox1.DataSource = dt;
                this.comboBox1.ValueMember = "f_sta";

                sql = "select case when sell_or_lend='true' then '已出售' when sell_or_lend='false' then case when date>(select getdate())then '正在租赁期' when date<(select getdate()) then '签约期已过' end end as 租售状态,f_num as 房源编号,wu_name as 物业名称,yezhu_name as 业主名称,kh_type as 客户类型,kh_num as 客户编号,kh_name as 客户名称,kh_tele as 客户电话,kh_mob as 客户手机,kh_address as 客户地址,kh_cdk as 客户身份证号,ht_num as 合同编号,ht_money as 交易金额,kh_money as 客户佣金,yz_money as 业主佣金,all_money as 总金额,ticheng as 提成比例,tc_money as 提成金额,date as 到期时间,beizhu as 备注,f_fukuan as 付款方式,qy_date as 签约时间 from htnews";
                dt = data.Query(sql);
                this.dataGridView3.DataSource = dt;
                
            }
            catch
            {
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.RowCount > 0)
            {

                string f_num = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
              
                string sql_genjin = "select genjin_time as 跟进时间,genjinren as 跟进人,f_genjin as 跟进方式,neirong as 跟进内容 from f_genjin_fy where bianhao='" + f_num + "'";
                
                DataTable dd = data.Query(sql_genjin);
                this.dataGridView2.DataSource = dd;

                string sqljkl = "select lend,sell,lend_price,sell_price,zhuangtai,wuye,area,huxing,lend_shuoming,sell_shuoming,guwen,yongtu,chengdu,mianji,jiancheng,wuye_type,fang_type,z_floor,jichusheshi,peitaosheshi,address,xiangxi,yezhu_name,tele,mobliephone,yezhu_address,beizhu from fangyuan where bianhao='" + f_num + "'";
              DataTable  dt = data.Query(sqljkl);
                if (Convert.ToBoolean(dt.Rows[0][0].ToString()) == true)
                {
                    this.checkBox4.Checked = true;
                    this.textBox3.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    this.checkBox4.Checked = false;
                    this.textBox3.Text = "";
                }
                if (Convert.ToBoolean(dt.Rows[0][1].ToString()))
                {
                    this.checkBox5.Checked = true;
                    this.textBox4.Text = dt.Rows[0][3].ToString();
                }
                else
                {
                    this.checkBox5.Checked = false;
                    this.textBox4.Text = "";
                }
                this.textBox5.Text = dt.Rows[0][4].ToString();
                this.textBox6.Text = dt.Rows[0][5].ToString();
                this.textBox7.Text = dt.Rows[0][6].ToString();
                this.textBox8.Text = dt.Rows[0][7].ToString();
                this.textBox9.Text = dt.Rows[0][8].ToString();
                this.textBox10.Text = dt.Rows[0][9].ToString();
                this.textBox11.Text = dt.Rows[0][10].ToString();
                this.textBox12.Text = dt.Rows[0][11].ToString();
                this.textBox13.Text = dt.Rows[0][12].ToString();
                this.textBox14.Text = dt.Rows[0][13].ToString();
                this.textBox15.Text = dt.Rows[0][14].ToString();
                this.textBox16.Text = dt.Rows[0][15].ToString();
                this.textBox17.Text = dt.Rows[0][16].ToString();
                this.textBox18.Text = dt.Rows[0][17].ToString();
                this.textBox19.Text = dt.Rows[0][18].ToString();
                this.textBox20.Text = dt.Rows[0][19].ToString();
                this.textBox21.Text = dt.Rows[0][20].ToString();
                this.richTextBox1.Text = dt.Rows[0][21].ToString();
                this.textBox22.Text = dt.Rows[0][22].ToString();
                this.textBox23.Text = dt.Rows[0][23].ToString();
                this.textBox24.Text = dt.Rows[0][24].ToString();
                this.textBox25.Text = dt.Rows[0][25].ToString();
                this.richTextBox2.Text = dt.Rows[0][26].ToString();

            }


        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态, wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 所在的层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where zhuangtai='"+this.comboBox1.Text+"'";
                DataTable dt = data.Query(sql);
                this.dataGridView1.DataSource = dt;
            }
            catch
            {
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select  bianhao as 房源编号,date as 登记日期,zhuangtai as 当前状态, wuye as 物业名称,huxing as 户型结构,mianji as 建筑面积,area as 所在区域,z_floor as 总层数,n_floor as 所在的层数,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,chengdu as 装修程度,fang_type as 房型,jiancheng as 建成年份,address as 具体地址 from fangyuan where(bianhao like '%"+this.textBox1.Text+"%' or date like '%"+this.textBox1.Text+"%' or zhuangtai like '%"+this.textBox1.Text+"%')";
                if (this.checkBox1.Checked == true)
                {
                    sql += " and lend=1";
                }
                if (this.checkBox2.Checked == true)
                {
                    sql += " and sell=1";
                }
                if (this.checkBox3.Checked)
                {
                    if (this.textBox2.Text.Trim().ToString() != "")
                    {
                        sql += " and date>'"+DateTime.Now.Date.AddDays(-Convert.ToInt32(this.textBox2.Text))+"'";
                    }
                }
                DataTable dt = data.Query(sql);
                this.dataGridView1.DataSource = dt;
            }
            catch
            {
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dt1, dt2;
                dt1 = this.dateTimePicker1.Value;
                dt2 = this.dateTimePicker2.Value;
                string sql = "select case when sell_or_lend='true' then '已售出' when sell_or_lend='false' then case when date>(select getdate()) then '正在租赁期' when date<(select getdate()) then '签约期已过' end end as 租售状态,f_num as 房源编号,wu_name as 物业名称,yezhu_name as 业主名称,kh_type as 客户类型,kh_num as 客户编号,kh_name as 客户名称,kh_tele as 客户电话,kh_mob as  客户手机,kh_address as 客户地址,kh_cdk as 客户身份证号,ht_num as 合同编号,ht_money as 交易金额,kh_money as 客户佣金,yz_money as 业主佣金,all_money as 总金额,ticheng as 提成比例,tc_money as 提成金额,date as 到期时间,beizhu as 备注,f_fukuan as 付款方式,qy_date as 签约时间 from htnews where qy_date>'"+dt1+"' and qy_date<'"+dt2+"'";
                if (this.checkBox6.Checked == true)
                {
                    sql += " and sell_or_lend='false'";
                }
                DataTable dnb = data.Query(sql);
                this.dataGridView3.DataSource = dnb;
            }
            catch
            {
            }
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //怎样讲数据导出到Excel文件
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                int st = this.dataGridView2.SelectedRows[0].Index;
                DateTime str_1 = Convert.ToDateTime(this.dataGridView2.Rows[st].Cells[0].Value.ToString());
                DialogResult df = MessageBox.Show("确定要删除本条记录","删除确认",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (df == DialogResult.OK)
                {
                    string sql = "delete from f_genjin_fy where genjin_time='"+str_1+"'";
                    int i = data.RunSql(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("信息删除成功");

                    }
                }


            }
            catch
            {
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select case when sell_or_lend='true' then '已售出' when sell_or_lend='false' then case when date>(select getdate()) then '正在租赁期' when date<(select getdate()) then '签约期已过' end end as 租售状态,f_num as 房源编号,wu_name as 物业名称,yezhu_name as 业主名称,kh_type as 客户类型,kh_num as 客户编号,kh_name as 客户名称,kh_tele as 客户电话,kh_mob as  客户手机,kh_address as 客户地址,kh_cdk as 客户身份证号,ht_num as 合同编号,ht_money as 交易金额,kh_money as 客户佣金,yz_money as 业主佣金,all_money as 总金额,ticheng as 提成比例,tc_money as 提成金额,date as 到期时间,beizhu as 备注,f_fukuan as 付款方式,qy_date as 签约时间 from htnews";
            DataTable dt = data.Query(sql);
            this.dataGridView3.DataSource = dt;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.Rows.Count > 0)
            {
                FollowInfo followInfo = new FollowInfo();
                int index = this.dataGridView2.CurrentRow.Index;
                int i = this.dataGridView1.CurrentRow.Index;
                string FollowTime = this.dataGridView2.Rows[index].Cells["跟进时间"].Value.ToString();
                string FNumber = this.dataGridView1.Rows[i].Cells["房源编号"].Value.ToString();
                string strSql = "select * from f_genjin_fy where genjin_time='"+FollowTime+"'";
                DataTable dt = data.Query(strSql);
                foreach (DataRow dr in dt.Rows)
                {
                    followInfo.bianhao = dr["bianhao"].ToString();
                    followInfo.genjin_time = Convert.ToDateTime(dr["genjin_time"]);
                    followInfo.f_genjin = dr["f_genjin"].ToString();
                    followInfo.genjinren = dr["genjinren"].ToString();
                    followInfo.neirong = dr["neirong"].ToString();
                    followInfo.tixing_type = dr["tixing_type"].ToString();
                    followInfo.tixing_date = dr["tixing_date"].ToString();
                    followInfo.tixing_time = dr["tixing_time"].ToString();
                }
              genjinxinxi addFollow = new genjinxinxi(followInfo,true);
              addFollow.ShowDialog();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                int index = this.dataGridView1.CurrentRow.Index;
                string FNumber = this.dataGridView1.Rows[index].Cells[0].Value.ToString();
                genjinxinxi addFollow = new genjinxinxi(FNumber);
                addFollow.ShowDialog();
                this.dataGridView2.DataSource = dd.SeleFollow(FNumber);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount > 0)
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (this.dataGridView1.SelectedRows[0].Cells["当前状态"].Value.ToString() == "已经成交")
                    {
                        MessageBox.Show("当前房源仍处于签约期");
                    }
                    else
                    {
                        try
                        {
                            qychengjiao qycj = new qychengjiao();
                            qycj.f_num = this.dataGridView1.SelectedRows[0].Cells["房源编号"].Value.ToString();
                            qycj.ShowDialog();
                        }
                        catch
                        {

                        }


                    }

                }
            }
            else
            {
                MessageBox.Show("当前没有数据");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount > 0)
            {
                if (this.dataGridView1.SelectedRows[0].Cells["当前状态"].Value.ToString() != "已经成交")
                {
                    MessageBox.Show("当前房源没有签约");
                    return;
                }
                else
                {
                    if (this.dataGridView1.SelectedRows.Count > 0)
                    {
                        try
                        {
                            qychengjiao qyc = new qychengjiao();
                            string str1 = this.dataGridView1.SelectedRows[0].Cells["房源编号"].Value.ToString();
                            string str2 = this.textBox6.Text;
                            string str3 = this.textBox22.Text;
                            qyc.f_num = str1;
                            qyc.update = true;
                            qyc.ShowDialog();

                        }
                        catch
                        {

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("当前没有可修改的数据!");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                ht_demo htnew = new ht_demo();
                htnew.ShowDialog();
            }
            catch
            {

            }


        }
    }
}
