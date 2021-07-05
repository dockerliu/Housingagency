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
    public partial class tixingxinxi : Form
    {
        public tixingxinxi()
        {
            InitializeComponent();
        }
        Database da = new Database();
        ContratInfo cInfo = new ContratInfo();
        string tixingduixiang1, lianxifangshi1, tixingneirong1, tixingshijian1;
        string tixingduixiang, lianxifangshi, tixingneirong, tixingriqi, tixingshijian;
        private void tixingxinxi_Load(object sender, EventArgs e)
        {
            if (cInfo.ContractName != null)
            {

                comboBox1.Text = cInfo.ContractName;
                textBox2.Text = cInfo.ContractAddress;
                textBox3.Text = cInfo.Warn2;
            }
            tixingduixiang1 = cInfo.ContractName;
            lianxifangshi1 = cInfo.ContractAddress;
            tixingneirong1 = cInfo.Warn2;
            tixingshijian1 = cInfo.Warn;
        }
        public tixingxinxi(ContratInfo contratInfo)
        {
            InitializeComponent();
            cInfo = contratInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("请选择提醒对象", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请输入提醒电话", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("请输入提醒内容", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            tixingduixiang = comboBox1.Text.Trim();
            lianxifangshi = textBox2.Text.Trim();
            tixingneirong = textBox3.Text.Trim();
            tixingriqi = dateTimePicker1.Value.ToString();
            tixingshijian = dateTimePicker2.Value.ToString();
            bool l = true;
            DataTable dt = this.selectWarn2(tixingduixiang, lianxifangshi,tixingshijian, tixingneirong);
            foreach (DataRow dr in dt.Rows)
            {
                if (tixingduixiang == dr["提醒对象"].ToString() && lianxifangshi == dr["联系方式"].ToString() && tixingshijian == dr["提醒时间"].ToString() && tixingneirong == dr["提醒内容"].ToString())
                {
                    l = false;
                }

            }
             if (cInfo.Warn2 != null)
            {
                if (l == false)
                {
                    MessageBox.Show("没有做任何更改!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else//更新
                {
                    this.updateWarn(tixingduixiang, lianxifangshi, tixingneirong, tixingriqi, tixingshijian, tixingduixiang1, lianxifangshi1, tixingneirong1, tixingshijian1);
                    this.Close();
                }
            }
            else
            {

                if (l == true)
                {
                    this.insertWarn( tixingduixiang, lianxifangshi, tixingneirong, tixingriqi, tixingshijian);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("请勿反复插入相同提醒!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
         public int insertWarn(string tixingduixiang, string lianxifangshi, string tixingneirong,string tixingriqi, string tixingshijian)
        {
            SqlParameter[] para ={
                                  da.MakeInParam("@tixingduixiang",SqlDbType.VarChar,tixingduixiang),
                                  da.MakeInParam("@lianxifangshi",SqlDbType.VarChar,lianxifangshi),
                                  da.MakeInParam("@tixingneirong",SqlDbType.VarChar,tixingneirong),
                                 
                                  da.MakeInParam("@tixingriqi",SqlDbType.VarChar,tixingriqi),
                                  da.MakeInParam("@tixingshijian",SqlDbType.VarChar,tixingshijian),
            };
            string str = "insert into tixing (tixingduixiang,lianxifangshi,tixingneirong,tixingriqi,tixingshijian,ted,yinyue,shanchu,guanbi)values(@tixingduixiang,@lianxifangshi,@tixingneirong,@tixingriqi,@tixingriqi,'false','false','false','20')";
            return da.RunSql(str, para);

        }
        
        public int updateWarn(string tixingduixiang, string lianxifangshi, string tixingneirong, string tixingriqi, string tixingshijian, string tixingduixiang1, string lianxifangshi1, string tixingneirong1, string tixingshijian1)
        {
            SqlParameter[] para ={
                                  da.MakeInParam("@tixingduixiang",SqlDbType.VarChar,tixingduixiang),
                                  da.MakeInParam("@lianxifangshi",SqlDbType.VarChar,lianxifangshi),
                                  da.MakeInParam("@tixingneirong",SqlDbType.VarChar,tixingneirong),
                                 
                                  da.MakeInParam("@tixingshijian",SqlDbType.VarChar,tixingshijian),
                                  da.MakeInParam("@tixingriqi",SqlDbType.VarChar,tixingriqi),
                                  da.MakeInParam("@tixingduixiang1",SqlDbType.VarChar,tixingduixiang1),
                                  da.MakeInParam("@lianxifangshi1",SqlDbType.VarChar,lianxifangshi1),
                                  da.MakeInParam("@tixingneirong1",SqlDbType.VarChar,tixingneirong1),
                                
                                  da.MakeInParam("@tixingshijian1",SqlDbType.VarChar,tixingshijian1),

                

                                    };
            string str = "update tixing set tixingduixiang=@tixingduixiang,lianxifangshi=@lianxifangshi,tixingneirong=@tixingneirong,tixingriqi=@tixingriqi,tixingshijian=@tixingshijian where tixingduixiang=@tixingduixiang1 and lianxifangshi=@lianxifangshi1 and tixingneirong=@tixingneirong1 and tixingshijian=@tixingshijian1";
            return da.RunSql(str, para);
        }
        public DataTable selectWarn2(string tixingduixiang, string lianxifangshi, string tixingneirong, string tixingshijian)//数据操作
        {
            SqlParameter[] para ={
                                  da.MakeInParam("@tixingduixiang",SqlDbType.VarChar,tixingduixiang),
                                  da.MakeInParam("@lianxifangshi",SqlDbType.VarChar,lianxifangshi),
                                  da.MakeInParam("@tixingneirong",SqlDbType.VarChar,tixingneirong),
                                  
                                  da.MakeInParam("@tixingshijian",SqlDbType.VarChar,tixingshijian),
                                 
            };
            string str = "select tixingduixiang as 提醒对象,lianxifangshi as 联系方式,tixingriqi as 提醒日期,tixingshijian as 提醒时间,tixingneirong as 提醒内容 from tixing where tixingduixiang=@tixingduixiang and lianxifangshi=@lianxifangshi and tixingneirong=@tixingneirong and tixingshijian=@tixingshijian";
            return da.Query(str, para);
        }

    }
}
