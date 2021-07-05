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
    public partial class tixingguanli : Form
    {
        public tixingguanli()
        {
            InitializeComponent();
        }
        Database da = new Database();
        private void tixingguanli_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.selectWarn();
            comboBox1.SelectedItem = "所有提醒";
        }
        public DataTable selectWarn()
        {
            string str = "select tixingduixiang as 提醒对象,lianxifangshi as 联系方式,tixingriqi as 提醒日期,tixingshijian as 提醒时间,tixingneirong as 提醒内容 from tixing ";
            return da.Query(str);
        }

        public DataTable selectWarn2(string WarnObject, string Tel, string WarnTime, string WarnContent)//数据操作
        {
            SqlParameter[] para ={
                                  da.MakeInParam("@WarnObject",SqlDbType.VarChar,WarnObject),
                                  da.MakeInParam("@Tel",SqlDbType.VarChar,Tel),
                                  da.MakeInParam("@WarnContent",SqlDbType.VarChar,WarnContent),
                                 
                                  da.MakeInParam("@WarnTime",SqlDbType.VarChar,WarnTime),
                                 
            };
            string str = "select tixingduixiang as 提醒对象,lianxifangshi as 联系方式,tixingriqi as 提醒日期,tixingshijian as 提醒时间,tixingneirong as 提醒内容 from tixing where tixingduixiang=@WarnObject and lianxifangshi=@Tel and tixingneirong=@WarnContent and tixingshijian=@WarnTime";
            return da.Query(str, para);
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    ContratInfo contractInfo = new ContratInfo();
                    int i = dataGridView1.CurrentRow.Index;
                    string Warn1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string Warn2 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string Warn3 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string Warn5 = dataGridView1.Rows[i].Cells[4].Value.ToString();


                    DataTable dt = this.selectWarn2(Warn1, Warn2, Warn3, Warn5);
                    foreach (DataRow dr in dt.Rows)
                    {
                        contractInfo.ContractName = dr["提醒对象"].ToString();
                        contractInfo.ContractAddress = dr["联系方式"].ToString();

                        contractInfo.ParaSet = dr["提醒日期"].ToString();
                        contractInfo.Warn = dr["提醒时间"].ToString();
                        contractInfo.Warn2 = dr["提醒内容"].ToString();

                    }
                    tixingxinxi txadd = new tixingxinxi(contractInfo);
                    txadd.ShowDialog();
                    dataGridView1.DataSource = this.selectWarn();
                }
            }
            catch
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            tixingxinxi txadd = new tixingxinxi();
            txadd.ShowDialog();
            dataGridView1.DataSource = this.selectWarn();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectstr = "";
            if (textBox1.Text != "")
            {
                selectstr = selectstr + "tixingduixiang like '%" + textBox1.Text.Trim() + "%' and ";
            }
            if (comboBox1.Text != "所有提醒")
            {
                if (comboBox1.Text == "未提醒的")
                {
                    selectstr = selectstr + "ted='false' and ";
                }

                else
                {
                    selectstr = selectstr + "ted='true' and ";
                }

            }
            dataGridView1.DataSource = this.selectWarn3(selectstr);
           
        }
        public DataTable selectWarn3(string selectstr)//查找按钮
        {
            SqlParameter[] para ={
                                   da.MakeInParam("@selectstr",SqlDbType.VarChar,selectstr),
                                 
            };
            string SelectSql;
            string SelectSql1 = "select tixingduixiang as 提醒对象,lianxifangshi as 联系方式,tixingriqi as 提醒日期,tixingshijian as 提醒时间,tixingneirong as 提醒内容 from tixing ";
            selectstr = selectstr.Trim();
            if (selectstr != "")
            {
                if (selectstr.Substring((selectstr.Length - 3), 3) == "and")
                    selectstr = selectstr.Remove(selectstr.Length - 3);
                SelectSql = SelectSql1 + " where " + selectstr;
            }
            else
            {
                SelectSql = SelectSql1;
            }

            return da.Query(SelectSql, para);
        }

    }
}
