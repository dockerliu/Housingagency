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
    public partial class xinxi : Form
    {
        public xinxi()
        {
            InitializeComponent();
        }
        keehuu khu = new keehuu();
        Database data = new Database();
        public string bianh;
        public xinxi(keehuu kh)
        {
            InitializeComponent();
            khu = kh;
        }

        private void xinxi_Load(object sender, EventArgs e)
        {

            #region 绑定combo
            string sql1 = "select _name from empl_info";
            DataTable dt = data.Query(sql1);
            comboBox8.DataSource = dt;
            comboBox8.DisplayMember = "_name";
            string sql_laiyuan = "select * from f_laiyuan";
            DataTable dd1 = data.Query(sql_laiyuan);
            comboBox1.DataSource = dd1;
            comboBox1.DisplayMember = "f_laiyuan";
            string sql_sta = "select * from k_sta";
            DataTable dd2 = data.Query(sql_sta);
            comboBox2.DataSource = dd2;
            comboBox2.DisplayMember = "k_sta";
            string sql_yongtu = "select * from f_yongtu";
            DataTable dd3 = data.Query(sql_yongtu);
            comboBox3.DataSource = dd3;
            comboBox3.DisplayMember = "f_yongtu";
            string sql_wuye = "select * from f_wuye";
            DataTable dd4 = data.Query(sql_wuye);
            comboBox4.DataSource = dd4;
            comboBox4.DisplayMember = "f_wuye";
            string sql_zhuangxiu = "select * from f_zhuangxiu";
            DataTable dd5 = data.Query(sql_zhuangxiu);
            comboBox5.DataSource = dd5;
            comboBox5.DisplayMember = "f_zhuangxiu";
            string sql_l = "select area from area";
            DataTable dd = data.Query(sql_l);
            comboBox6.DataSource = dd;
            comboBox6.DisplayMember = "area";
            string sql_leixing = "select * from f_leixing";
            DataTable dd6 = data.Query(sql_leixing);
            comboBox9.DataSource = dd6;
            comboBox9.DisplayMember = "f_leixing";
            #endregion
            string sj = "yyyyMMddHHmmss";
            this.textBox1.Text = "KH" + DateTime.Now.ToString(sj);

            if (khu.bianhao != null)
            {
                this.textBox1.Text = khu.bianhao;
                this.comboBox1.Text = khu.laiyuan;
                this.comboBox2.Text = khu.zhuangtai;
                this.comboBox8.Text = khu.guwen;
                this.textBox3.Text = khu.wuye;
                this.comboBox3.Text = khu.yongtu;
                this.comboBox4.Text = khu.wuye_type;
                this.comboBox5.Text = khu.chengdu;
                this.textBox4.Text = khu.address;
                this.comboBox6.Text = khu.area;
                this.comboBox9.Text = khu.fang_type;
                this.textBox15.Text = khu.xinxi;
                this.textBox16.Text = khu.yezhu_name;
                this.textBox17.Text = khu.tele;
                this.textBox18.Text = khu.MobliePhone;
                this.textBox19.Text = khu.yezhu_address;
                this.textBox24.Text = khu.beizhu;
                this.textBox2.Text = Convert.ToString(khu.fangshumin);
                this.textBox5.Text = Convert.ToString(khu.fangshumax);
                this.textBox10.Text = Convert.ToString(khu.mianjimin);
                this.textBox6.Text = Convert.ToString(khu.mianjimax);
                this.textBox7.Text = Convert.ToString(khu.jianchengmin);
                this.textBox8.Text = Convert.ToString(khu.jianchengmax);
                if (khu.lend == "1")
                {
                    this.checkBox1.Checked = true;
                    this.checkBox2.Checked = false;
                    this.textBox20.Text = khu.lend_price;
                    this.textBox21.Text = khu.lend_shuoming;
                    this.textBox22.Text = "";
                    this.textBox23.Text = "";
                }
                if (khu.sell == "1")
                {
                    this.checkBox1.Checked = false;
                    this.checkBox2.Checked = true;
                    this.textBox22.Text = khu.sell_price;
                    this.textBox23.Text = khu.sell_shuoming;
                    this.textBox20.Text = "";
                    this.textBox21.Text = "";
                }
                if (khu.lend == "1" && khu.sell == "1")
                {
                    this.checkBox1.Checked = true;
                    this.checkBox2.Checked = true;
                    this.textBox20.Text = khu.lend_price;
                    this.textBox21.Text = khu.lend_shuoming;
                    this.textBox22.Text = khu.sell_price;
                    this.textBox23.Text = khu.sell_shuoming;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 基础信息
            string date = DateTime.Now.ToString();
            string bianhao = this.textBox1.Text;
            string laiyuan = this.comboBox1.Text;
            string zhuangtai = this.comboBox2.Text;
            string guwen = this.comboBox8.Text;
            string wuye = this.textBox3.Text;
            string yongtu = this.comboBox3.Text;
            string wuye_type = this.comboBox4.Text;
            string chengdu = this.comboBox5.Text;
            string address = this.textBox4.Text;
            string area = this.comboBox6.Text;
            string fang_type = this.comboBox9.Text;
            string fangshumin = this.textBox2.Text;
            string fangshumax = this.textBox5.Text;
            string mianjimin = this.textBox10.Text;
            string mianjimax = this.textBox6.Text;
            string jianchengmin = this.textBox7.Text;
            string jianchengmax = this.textBox8.Text;
            string lend_price = this.textBox20.Text;
            string sell_price = this.textBox22.Text;
            string lend_shuoming = this.textBox21.Text;
            string sell_shuoming = this.textBox23.Text;
            string xinxi = this.textBox15.Text;
            string yezhu_name = this.textBox16.Text;
            string tele = this.textBox17.Text;
            string MobliePhone = this.textBox18.Text;
            string yezhu_address = this.textBox19.Text;
            string beizhu = this.textBox24.Text;
            string jichusheshi = "";
            if (this.checkBox6.Checked == true)
            {
                jichusheshi += this.checkBox6.Text + "" + ",";
            }
            if (this.checkBox5.Checked == true)
            {
                jichusheshi += this.checkBox5.Text + "" + ",";
            }
            if (this.checkBox3.Checked == true)
            {
                jichusheshi += this.checkBox3.Text + "" + ",";
            }
            if (this.checkBox4.Checked == true)
            {
                jichusheshi += this.checkBox4.Text + "";
            }
            string peitaosheshi = "";
            if (this.checkBox10.Checked == true)
            {
                peitaosheshi += this.checkBox10.Text + "" + ",";
            }
            if (this.checkBox9.Checked == true)
            {
                peitaosheshi += this.checkBox9.Text + "" + ",";
            }
            if (this.checkBox8.Checked == true)
            {
                peitaosheshi += this.checkBox8.Text + "" + ",";
            }
            if (this.checkBox7.Checked == true)
            {
                peitaosheshi += this.checkBox7.Text + "" + ",";
            }
            if (this.checkBox11.Checked == true)
            {
                peitaosheshi += this.checkBox11.Text + "" + ",";
            }
            if (this.checkBox12.Checked == true)
            {
                peitaosheshi += this.checkBox12.Text + "" + ",";
            }
            if (this.checkBox14.Checked == true)
            {
                peitaosheshi += this.checkBox14.Text + "" + ",";
            }
            if (this.checkBox13.Checked == true)
            {
                peitaosheshi += this.checkBox13.Text + "";
            }
            #endregion
            #region 插入
            if (this.checkBox1.Checked == true)
            {
                //string sql_ins1 = "insert into kehu (lend,sell,date,bianhao,laiyuan,zhuangtai,wuye,fangshumin,fangshumax,mianjimin,mianjimax,jianchengmin,jianchengmax,area,guwen,yongtu,wuye_type,chengdu,fang_type,address,lend_shuoming,sell_shuoming,xinxi,lend_price,sell_price,jichusheshi,peitaosheshi,yezhu_name,tele,MobliePhone,beizhu,yezhu_address) values (1,0,@date,@bianhao,@laiyuan,@zhuangtai,@wuye,@fangshumin,@fangshumax,@mianjimin,@mianjimax,@jianchengmin,@jianchengmax,@area,@guwen,@yongtu,@wuye_type,@chengdu,@fang_type,@address,@lend_shuoming,@sell_shuoming,@xinxi,@lend_price,@sell_price,@jichusheshi,@peitaosheshi,@yezhu_name,@tele,@MobliePhone,@beizhu,@yezhu_address)";
                try
                {
                    SqlParameter[] prams1 =
                {
                    data.MakeInParam("@bianhao",SqlDbType.VarChar,bianhao.ToString()),
                    data.MakeInParam("@laiyuan",SqlDbType.VarChar,laiyuan.ToString()),
                    data.MakeInParam("@zhuangtai",SqlDbType.VarChar,zhuangtai.ToString()),
                    data.MakeInParam("@wuye",SqlDbType.VarChar,wuye.ToString()),
                    data.MakeInParam("@area",SqlDbType.VarChar,area.ToString()),
                    data.MakeInParam("@guwen",SqlDbType.VarChar,guwen.ToString()),
                    data.MakeInParam("@yongtu",SqlDbType.VarChar,yongtu.ToString()),
                    data.MakeInParam("@wuye_type",SqlDbType.VarChar,wuye_type.ToString()),
                    data.MakeInParam("@chengdu",SqlDbType.VarChar,chengdu.ToString()),
                    data.MakeInParam("@fang_type",SqlDbType.VarChar,fang_type.ToString()),
                    data.MakeInParam("@address",SqlDbType.VarChar,address.ToString()),
                    data.MakeInParam("@jichusheshi",SqlDbType.VarChar,jichusheshi.ToString()),
                    data.MakeInParam("@peitaosheshi",SqlDbType.VarChar,peitaosheshi.ToString()),
                    data.MakeInParam("@yezhu_name",SqlDbType.VarChar,yezhu_name.ToString()),
                    data.MakeInParam("@tele",SqlDbType.VarChar,tele.ToString()),
                    data.MakeInParam("@MobliePhone",SqlDbType.VarChar,MobliePhone.ToString()),
                    data.MakeInParam("@yezhu_address",SqlDbType.VarChar,yezhu_address.ToString()),
                    data.MakeInParam("@fangshumin",SqlDbType.Int,fangshumin.ToString()),
                    data.MakeInParam("@fangshumax",SqlDbType.Int,fangshumax.ToString()),
                    data.MakeInParam("@mianjimin",SqlDbType.Int,mianjimin.ToString()),
                    data.MakeInParam("@mianjimax",SqlDbType.Int,mianjimax.ToString()),
                    data.MakeInParam("@jianchengmin",SqlDbType.Int,jianchengmin.ToString()),
                    data.MakeInParam("@jianchengmax",SqlDbType.Int,jianchengmax.ToString()),
                    data.MakeInParam("@lend_shuoming",SqlDbType.Text,lend_shuoming.ToString()),
                    data.MakeInParam("@sell_shuoming",SqlDbType.Text,sell_shuoming.ToString()),
                    data.MakeInParam("@xinxi",SqlDbType.Text,xinxi.ToString()),
                    data.MakeInParam("@beizhu",SqlDbType.Text,beizhu.ToString()),
                    data.MakeInParam("@lend_price",SqlDbType.Money,lend_price.ToString()),
                    data.MakeInParam("@sell_price",SqlDbType.Money,sell_price.ToString()),
                    data.MakeInParam("@date",SqlDbType.DateTime,date.ToString()),
                };
                    string sql_ins1 = "";
                    if (bianh == null)
                    {
                        sql_ins1 = "insert into kehu (lend,sell,date,bianhao,laiyuan,zhuangtai,wuye,fangshumin,fangshumax,mianjimin,mianjimax,jianchengmin,jianchengmax,area,guwen,yongtu,wuye_type,chengdu,fang_type,address,lend_shuoming,sell_shuoming,xinxi,lend_price,sell_price,jichusheshi,peitaosheshi,yezhu_name,tele,MobliePhone,beizhu,yezhu_address) values (1,0,@date,@bianhao,@laiyuan,@zhuangtai,@wuye,@fangshumin,@fangshumax,@mianjimin,@mianjimax,@jianchengmin,@jianchengmax,@area,@guwen,@yongtu,@wuye_type,@chengdu,@fang_type,@address,@lend_shuoming,@sell_shuoming,@xinxi,@lend_price,@sell_price,@jichusheshi,@peitaosheshi,@yezhu_name,@tele,@MobliePhone,@beizhu,@yezhu_address)";
                    }
                    else
                    {
                        sql_ins1 = "update kehu set lend=1,sell=0,date=@date,bianhao=@bianhao,laiyuan=@laiyuan,zhuangtai=@zhuangtai,wuye=@wuye,fangshumin=@fangshumin,fangshumax=@fangshumax,mianjimin=@mianjimin,mianjimax=@mianjimax,jianchengmin=@jianchengmin,jianchengmax=@jianchengmax,area=@area,guwen=@guwen,yongtu=@yongtu,wuye_type=@wuye_type,chengdu=@chengdu,fang_type=@fang_type,address=@address,lend_shuoming=@lend_shuoming,sell_shuoming=@sell_shuoming,xinxi=@xinxi,lend_price=@lend_price,sell_price=@sell_price,jichusheshi=@jichusheshi,peitaosheshi=@peitaosheshi,yezhu_name=@yezhu_name,tele=@tele,MobliePhone=@MobliePhone,beizhu=@beizhu,yezhu_address=@yezhu_address where bianhao='" + bianh + "'";
                    }

                    int a = data.RunSql(sql_ins1, prams1);
                    if (a > 0)
                    {
                        if (MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
                catch { }
                finally
                {
                    data.Close();
                }
            }
            if (this.checkBox2.Checked == true)
            {
                //string sql_ins2 = "insert into kehu (lend,sell,date,bianhao,laiyuan,zhuangtai,wuye,fangshumin,fangshumax,mianjimin,mianjimax,jianchengmin,jianchengmax,area,guwen,yongtu,wuye_type,chengdu,fang_type,address,lend_shuoming,sell_shuoming,xinxi,lend_price,sell_price,jichusheshi,peitaosheshi,yezhu_name,tele,MobliePhone,beizhu,yezhu_address) values (1,0,@date,@bianhao,@laiyuan,@zhuangtai,@wuye,@fangshumin,@fangshumax,@mianjimin,@mianjimax,@jianchengmin,@jianchengmax,@area,@guwen,@yongtu,@wuye_type,@chengdu,@fang_type,@address,@lend_shuoming,@sell_shuoming,@xinxi,@lend_price,@sell_price,@jichusheshi,@peitaosheshi,@yezhu_name,@tele,@MobliePhone,@beizhu,@yezhu_address)";
                try
                {
                    SqlParameter[] prams2 =
                {
                    data.MakeInParam("@bianhao",SqlDbType.VarChar,bianhao.ToString()),
                    data.MakeInParam("@laiyuan",SqlDbType.VarChar,laiyuan.ToString()),
                    data.MakeInParam("@zhuangtai",SqlDbType.VarChar,zhuangtai.ToString()),
                    data.MakeInParam("@wuye",SqlDbType.VarChar,wuye.ToString()),
                    data.MakeInParam("@area",SqlDbType.VarChar,area.ToString()),
                    data.MakeInParam("@guwen",SqlDbType.VarChar,guwen.ToString()),
                    data.MakeInParam("@yongtu",SqlDbType.VarChar,yongtu.ToString()),
                    data.MakeInParam("@wuye_type",SqlDbType.VarChar,wuye_type.ToString()),
                    data.MakeInParam("@chengdu",SqlDbType.VarChar,chengdu.ToString()),
                    data.MakeInParam("@fang_type",SqlDbType.VarChar,fang_type.ToString()),
                    data.MakeInParam("@address",SqlDbType.VarChar,address.ToString()),
                    data.MakeInParam("@jichusheshi",SqlDbType.VarChar,jichusheshi.ToString()),
                    data.MakeInParam("@peitaosheshi",SqlDbType.VarChar,peitaosheshi.ToString()),
                    data.MakeInParam("@yezhu_name",SqlDbType.VarChar,yezhu_name.ToString()),
                    data.MakeInParam("@tele",SqlDbType.VarChar,tele.ToString()),
                    data.MakeInParam("@MobliePhone",SqlDbType.VarChar,MobliePhone.ToString()),
                    data.MakeInParam("@yezhu_address",SqlDbType.VarChar,yezhu_address.ToString()),
                    data.MakeInParam("@fangshumin",SqlDbType.Int,fangshumin.ToString()),
                    data.MakeInParam("@fangshumax",SqlDbType.Int,fangshumax.ToString()),
                    data.MakeInParam("@mianjimin",SqlDbType.Int,mianjimin.ToString()),
                    data.MakeInParam("@mianjimax",SqlDbType.Int,mianjimax.ToString()),
                    data.MakeInParam("@jianchengmin",SqlDbType.Int,jianchengmin.ToString()),
                    data.MakeInParam("@jianchengmax",SqlDbType.Int,jianchengmax.ToString()),
                    data.MakeInParam("@lend_shuoming",SqlDbType.Text,lend_shuoming.ToString()),
                    data.MakeInParam("@sell_shuoming",SqlDbType.Text,sell_shuoming.ToString()),
                    data.MakeInParam("@xinxi",SqlDbType.Text,xinxi.ToString()),
                    data.MakeInParam("@beizhu",SqlDbType.Text,beizhu.ToString()),
                    data.MakeInParam("@lend_price",SqlDbType.Money,lend_price.ToString()),
                    data.MakeInParam("@sell_price",SqlDbType.Money,sell_price.ToString()),
                    data.MakeInParam("@date",SqlDbType.DateTime,date.ToString()),
                };
                    string sql_ins2 = "";
                    if (bianh == null)
                    {
                        sql_ins2 = "insert into kehu (lend,sell,date,bianhao,laiyuan,zhuangtai,wuye,fangshumin,fangshumax,mianjimin,mianjimax,jianchengmin,jianchengmax,area,guwen,yongtu,wuye_type,chengdu,fang_type,address,lend_shuoming,sell_shuoming,xinxi,lend_price,sell_price,jichusheshi,peitaosheshi,yezhu_name,tele,MobliePhone,beizhu,yezhu_address) values (0,1,@date,@bianhao,@laiyuan,@zhuangtai,@wuye,@fangshumin,@fangshumax,@mianjimin,@mianjimax,@jianchengmin,@jianchengmax,@area,@guwen,@yongtu,@wuye_type,@chengdu,@fang_type,@address,@lend_shuoming,@sell_shuoming,@xinxi,@lend_price,@sell_price,@jichusheshi,@peitaosheshi,@yezhu_name,@tele,@MobliePhone,@beizhu,@yezhu_address)";
                    }
                    else
                    {
                        sql_ins2 = "update kehu set lend=0,sell=1,date=@date,bianhao=@bianhao,laiyuan=@laiyuan,zhuangtai=@zhuangtai,wuye=@wuye,fangshumin=@fangshumin,fangshumax=@fangshumax,mianjimin=@mianjimin,mianjimax=@mianjimax,jianchengmin=@jianchengmin,jianchengmax=@jianchengmax,area=@area,guwen=@guwen,yongtu=@yongtu,wuye_type=@wuye_type,chengdu=@chengdu,fang_type=@fang_type,address=@address,lend_shuoming=@lend_shuoming,sell_shuoming=@sell_shuoming,xinxi=@xinxi,lend_price=@lend_price,sell_price=@sell_price,jichusheshi=@jichusheshi,peitaosheshi=@peitaosheshi,yezhu_name=@yezhu_name,tele=@tele,MobliePhone=@MobliePhone,beizhu=@beizhu,yezhu_address=@yezhu_address where bianhao='" + bianh + "'";
                    }
                    int b = data.RunSql(sql_ins2, prams2);
                    if (b > 0)
                    {
                        if (MessageBox.Show("保持成功！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
                catch { }
                finally
                {
                    data.Close();
                }
            }
            if (this.checkBox1.Checked == true && this.checkBox2.Checked == true)
            {
                //string sql_ins3 = "insert into kehu (lend,sell,date,bianhao,laiyuan,zhuangtai,wuye,fangshumin,fangshumax,mianjimin,mianjimax,jianchengmin,jianchengmax,area,guwen,yongtu,wuye_type,chengdu,fang_type,address,lend_shuoming,sell_shuoming,xinxi,lend_price,sell_price,jichusheshi,peitaosheshi,yezhu_name,tele,MobliePhone,beizhu,yezhu_address) values (1,0,@date,@bianhao,@laiyuan,@zhuangtai,@wuye,@fangshumin,@fangshumax,@mianjimin,@mianjimax,@jianchengmin,@jianchengmax,@area,@guwen,@yongtu,@wuye_type,@chengdu,@fang_type,@address,@lend_shuoming,@sell_shuoming,@xinxi,@lend_price,@sell_price,@jichusheshi,@peitaosheshi,@yezhu_name,@tele,@MobliePhone,@beizhu,@yezhu_address)";

                try
                {
                    SqlParameter[] prams3 =
                {
                    data.MakeInParam("@bianhao",SqlDbType.VarChar,bianhao.ToString()),
                    data.MakeInParam("@laiyuan",SqlDbType.VarChar,laiyuan.ToString()),
                    data.MakeInParam("@zhuangtai",SqlDbType.VarChar,zhuangtai.ToString()),
                    data.MakeInParam("@wuye",SqlDbType.VarChar,wuye.ToString()),
                    data.MakeInParam("@area",SqlDbType.VarChar,area.ToString()),
                    data.MakeInParam("@guwen",SqlDbType.VarChar,guwen.ToString()),
                    data.MakeInParam("@yongtu",SqlDbType.VarChar,yongtu.ToString()),
                    data.MakeInParam("@wuye_type",SqlDbType.VarChar,wuye_type.ToString()),
                    data.MakeInParam("@chengdu",SqlDbType.VarChar,chengdu.ToString()),
                    data.MakeInParam("@fang_type",SqlDbType.VarChar,fang_type.ToString()),
                    data.MakeInParam("@address",SqlDbType.VarChar,address.ToString()),
                    data.MakeInParam("@jichusheshi",SqlDbType.VarChar,jichusheshi.ToString()),
                    data.MakeInParam("@peitaosheshi",SqlDbType.VarChar,peitaosheshi.ToString()),
                    data.MakeInParam("@yezhu_name",SqlDbType.VarChar,yezhu_name.ToString()),
                    data.MakeInParam("@tele",SqlDbType.VarChar,tele.ToString()),
                    data.MakeInParam("@MobliePhone",SqlDbType.VarChar,MobliePhone.ToString()),
                    data.MakeInParam("@yezhu_address",SqlDbType.VarChar,yezhu_address.ToString()),
                    data.MakeInParam("@fangshumin",SqlDbType.Int,fangshumin.ToString()),
                    data.MakeInParam("@fangshumax",SqlDbType.Int,fangshumax.ToString()),
                    data.MakeInParam("@mianjimin",SqlDbType.Int,mianjimin.ToString()),
                    data.MakeInParam("@mianjimax",SqlDbType.Int,mianjimax.ToString()),
                    data.MakeInParam("@jianchengmin",SqlDbType.Int,jianchengmin.ToString()),
                    data.MakeInParam("@jianchengmax",SqlDbType.Int,jianchengmax.ToString()),
                    data.MakeInParam("@lend_shuoming",SqlDbType.Text,lend_shuoming.ToString()),
                    data.MakeInParam("@sell_shuoming",SqlDbType.Text,sell_shuoming.ToString()),
                    data.MakeInParam("@xinxi",SqlDbType.Text,xinxi.ToString()),
                    data.MakeInParam("@beizhu",SqlDbType.Text,beizhu.ToString()),
                    data.MakeInParam("@lend_price",SqlDbType.Money,lend_price.ToString()),
                    data.MakeInParam("@sell_price",SqlDbType.Money,sell_price.ToString()),
                    data.MakeInParam("@date",SqlDbType.DateTime,date.ToString()),
                };
                    string sql_ins3 = "";
                    if (bianh == null)
                    {
                        sql_ins3 = "insert into kehu (lend,sell,date,bianhao,laiyuan,zhuangtai,wuye,fangshumin,fangshumax,mianjimin,mianjimax,jianchengmin,jianchengmax,area,guwen,yongtu,wuye_type,chengdu,fang_type,address,lend_shuoming,sell_shuoming,xinxi,lend_price,sell_price,jichusheshi,peitaosheshi,yezhu_name,tele,MobliePhone,beizhu,yezhu_address) values (1,1,@date,@bianhao,@laiyuan,@zhuangtai,@wuye,@fangshumin,@fangshumax,@mianjimin,@mianjimax,@jianchengmin,@jianchengmax,@area,@guwen,@yongtu,@wuye_type,@chengdu,@fang_type,@address,@lend_shuoming,@sell_shuoming,@xinxi,@lend_price,@sell_price,@jichusheshi,@peitaosheshi,@yezhu_name,@tele,@MobliePhone,@beizhu,@yezhu_address)";
                    }
                    else
                    {
                        sql_ins3 = "update kehu set lend=1,sell=1,date=@date,bianhao=@bianhao,laiyuan=@laiyuan,zhuangtai=@zhuangtai,wuye=@wuye,fangshumin=@fangshumin,fangshumax=@fangshumax,mianjimin=@mianjimin,mianjimax=@mianjimax,jianchengmin=@jianchengmin,jianchengmax=@jianchengmax,area=@area,guwen=@guwen,yongtu=@yongtu,wuye_type=@wuye_type,chengdu=@chengdu,fang_type=@fang_type,address=@address,lend_shuoming=@lend_shuoming,sell_shuoming=@sell_shuoming,xinxi=@xinxi,lend_price=@lend_price,sell_price=@sell_price,jichusheshi=@jichusheshi,peitaosheshi=@peitaosheshi,yezhu_name=@yezhu_name,tele=@tele,MobliePhone=@MobliePhone,beizhu=@beizhu,yezhu_address=@yezhu_address where bianhao='" + bianh + "'";
                    }
                    int c = data.RunSql(sql_ins3, prams3);
                    if (c > 0)
                    {
                        if (MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
                catch { }
                finally
                {
                    data.Close();
                }
            }
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
