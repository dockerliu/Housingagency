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
    public partial class xinzengfangyuan : Form
    {
        public xinzengfangyuan()
        {
            InitializeComponent();
        }
        Database da = new Database();
        string sd = "yyyyMMddHHmmss";
        Fnewsinfo fInfo = new Fnewsinfo();
        public xinzengfangyuan(Fnewsinfo fnewsinfo)
        {
            fInfo = fnewsinfo;

        }

        private void xinzengfangyuan_Load(object sender, EventArgs e)
        {
            string sql = "select _name from empl_info";
            DataTable dt = da.Query(sql);
            comboBox8.DataSource = dt;
            comboBox8.DisplayMember = "_name";

            string sql_1 = "select area from area";
            dt= da.Query(sql_1);
            this.comboBox10.DataSource = dt;
            this.comboBox10.DisplayMember = "area";

            string sql_laiyuan = "select * from f_laiyuan";
            dt = da.Query(sql_laiyuan);
            this.comboBox1.DataSource = dt;
            this.comboBox1.DisplayMember = "f_laiyuan";

            string sql_sta = "select * from f_sta";
            dt = da.Query(sql_sta);
            this.comboBox2.DataSource = dt;
            this.comboBox2.DisplayMember = "f_sta";

            string sql_yongtu = "select * from f_yongtu";
            dt = da.Query(sql_yongtu);
            this.comboBox9.DataSource = dt;
            this.comboBox9.DisplayMember = "f_yongtu";


            string sql_wuye = "select * from f_wuye";
            dt = da.Query(sql_wuye);
            this.comboBox3.DataSource = dt;
            this.comboBox3.DisplayMember = "f_wuye";

            string sql_zhuangxiu = "select * from f_zhuangxiu";
            dt = da.Query(sql_zhuangxiu);
            this.comboBox4.DataSource = dt;
            this.comboBox4.DisplayMember = "f_zhuangxiu";

            string sql_leixing = "select * from f_leixing";
            dt = da.Query(sql_leixing);
            this.comboBox5.DataSource = dt;
            this.comboBox5.DisplayMember = "f_leixing";


            this.textBox1.Text = DateTime.Now.ToString(sd);

            if (fInfo.bianhao != null)
            {
                this.textBox1.Enabled = false;
                this.textBox1.Text = fInfo.bianhao;
                this.comboBox1.Text = fInfo.laiyuan;
                this.comboBox2.Text = fInfo.zhuangtai;
                
                this.comboBox8.Text = fInfo.guwen;
                this.textBox3.Text = fInfo.wuye;
                this.comboBox9.Text = fInfo.yongtu;
                this.comboBox3.Text = fInfo.wuye_type;
                this.comboBox4.Text = fInfo.chengdu;
                this.textBox4.Text = fInfo.address;
                this.comboBox10.Text = fInfo.area;
                this.textBox5.Text = fInfo.jiancheng;
                this.comboBox5.Text = fInfo.fang_type;
                this.textBox10.Text = fInfo.mianji.ToString();
                this.textBox16.Text = fInfo.yezhu_name;
                this.textBox17.Text = fInfo.tele;
                this.textBox18.Text = fInfo.mobliephone;
                this.textBox19.Text = fInfo.yezhu_address;
                this.textBox24.Text = fInfo.beizhu;
                this.textBox15.Text = fInfo.xiangxi;
                this.textBox11.Text = fInfo.z_floor.ToString();
                this.textBox12.Text = fInfo.n_floor.ToString();

                if (fInfo.lend == true)
                {
                    this.checkBox1.Checked = true;
                    this.checkBox2.Checked = false;
                    this.textBox20.Text = fInfo.lend_price;
                    this.textBox21.Text = fInfo.lend_shuoming;
                    this.textBox22.Text = "";
                    this.textBox23.Text = "";
                }
                if (fInfo.sell == true)
                {
                    this.checkBox1.Checked = false;
                    this.checkBox2.Checked = true;
                    this.textBox22.Text = fInfo.sell_price;
                    this.textBox23.Text = fInfo.sell_shuoming;
                    this.textBox20.Text = "";
                    this.textBox21.Text = "";

                }
                if (fInfo.lend == true && fInfo.sell == true)
                {
                    this.checkBox1.Checked = true;
                    this.checkBox2.Checked = true;
                    this.textBox20.Text = fInfo.lend_price;
                    this.textBox21.Text = fInfo.lend_shuoming;
                    this.textBox22.Text = fInfo.sell_price;
                    this.textBox23.Text = fInfo.sell_shuoming;
                }

            }



        }

        Fnewsinfo fn = new Fnewsinfo();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox3.Text == "")
                {
                    MessageBox.Show("物业名称不能为空");
                    return;
                }
                if (this.textBox4.Text == "")
                {
                    MessageBox.Show("具体地址不能为空");
                    return;
                }
                if (this.textBox5.Text == "")
                {
                    MessageBox.Show("建成年份不能为空");
                    return;
                }
                if (this.textBox16.Text == "")
                {
                    MessageBox.Show("业主姓名不能为空");
                    return;
                }
                if (this.textBox17.Text == "")
                {
                    MessageBox.Show("必须填写联系电话");
                    return;
                }
                if (this.textBox19.Text == "")
                {
                    MessageBox.Show("请填写您的具体地址");
                    return;
                }
                if (this.textBox24.Text == "")
                {
                    MessageBox.Show("请填写备注信息");
                    return;
                }
                if (this.textBox15.Text == "")
                {
                    MessageBox.Show("请填写房源详细信息");
                    return;
                }
                if (this.textBox15.Text.Length < 10)
                {
                    MessageBox.Show("内容太少");
                    return;
                }



                fn.bianhao = this.textBox1.Text;
                string date = DateTime.Now.ToString();
                fn.zhuangtai = this.comboBox2.Text;
                fn.laiyuan = this.comboBox1.Text;
                fn.wuye = this.textBox3.Text;
                fn.huxing = this.textBox6.Text + this.label14.Text + this.textBox7.Text + this.label15.Text + this.textBox8.Text + this.label16.Text + this.textBox9.Text + this.label17.Text;
                fn.mianji = Convert.ToInt32(this.textBox10.Text);
                fn.area = this.comboBox10.Text;
                fn.z_floor = Convert.ToInt32(this.textBox11.Text);
                fn.n_floor = Convert.ToInt32(this.textBox12.Text);
                fn.guwen = this.comboBox8.Text;

                fn.yongtu = this.comboBox9.Text;
                fn.wuye_type = this.comboBox3.Text;
                fn.chengdu = this.comboBox4.Text;
                fn.fang_type = this.comboBox5.Text;
                fn.jiancheng = this.textBox5.Text;
                fn.address = this.textBox4.Text;
                fn.yezhu_name = this.textBox16.Text;
                fn.tele = this.textBox17.Text;
                fn.mobliephone = this.textBox18.Text;
                fn.beizhu = this.textBox24.Text;
                fn.xiangxi = this.textBox15.Text;
                fn.yezhu_address = this.textBox19.Text;
                fn.jichusheshi = "";
                if (this.checkBox6.Checked == true)
                {
                    fn.jichusheshi += this.checkBox6.Text + "" + ",";
                }
                if (this.checkBox5.Checked == true)
                {
                    fn.jichusheshi += this.checkBox5.Text + "" + ",";
                }
                if (this.checkBox3.Checked == true)
                {
                    fn.jichusheshi += this.checkBox3.Text + "" + ",";
                }
                if (this.checkBox4.Checked == true)
                {
                    fn.jichusheshi += this.checkBox4.Text + "";
                }

                fn.peitaosheshi = "";
                if (this.checkBox10.Checked == true)
                {
                    fn.peitaosheshi += this.checkBox10.Text + "" + ",";
                }
                if (this.checkBox9.Checked == true)
                {
                    fn.peitaosheshi += this.checkBox9.Text + "" + ",";
                }
                if (this.checkBox8.Checked == true)
                {
                    fn.peitaosheshi += this.checkBox8.Text + "" + ",";
                }
                if (this.checkBox7.Checked == true)
                {
                    fn.peitaosheshi += this.checkBox7.Text + "" + ",";
                }
                if (this.checkBox11.Checked == true)
                {
                    fn.peitaosheshi += this.checkBox11.Text + "" + ",";
                }
                if (this.checkBox12.Checked == true)
                {
                    fn.peitaosheshi += this.checkBox12.Text + "" + ",";
                }

                if (this.checkBox14.Checked == true)
                {
                    fn.peitaosheshi += this.checkBox14.Text + "" + ",";
                }
                if (this.checkBox13.Checked == true)
                {
                    fn.peitaosheshi += this.checkBox13.Text + "";
                }


                if (fn.n_floor > fn.z_floor)
                {
                    MessageBox.Show("位于楼层不能大于总层数");
                    return;
                }

                if (this.checkBox1.Checked == true)
                {
                    fn.lend = true;
                    fn.sell = false;
                    fn.lend_price = this.textBox20.Text;
                    fn.lend_shuoming = this.textBox21.Text;
                }
                if (this.checkBox2.Checked == true)
                {
                    fn.lend = false;
                    fn.sell = true;
                    fn.sell_price = this.textBox22.Text;
                    fn.sell_shuoming = this.textBox23.Text;
                }
                if (this.checkBox1.Checked == true && this.checkBox2.Checked == true)
                {
                    fn.lend = true;
                    fn.sell = true;
                    fn.lend_price = this.textBox20.Text;
                    fn.sell_price = this.textBox22.Text;
                    fn.lend_shuoming = this.textBox21.Text;
                    fn.sell_shuoming = this.textBox23.Text;
                }

                if (fInfo.bianhao != null)
                {
                    string strsql = "update fangyuan set zhuangtai='" + fn.zhuangtai + "',laiyuan='" + fn.laiyuan + "',wuye='" + fn.wuye + "',huxing='" + fn.huxing + "',mianji='" + fn.mianji + "',area='" + fn.area + "',z_floor='" + fn.z_floor + "',n_floor='" + fn.n_floor + "',guwen='" + fn.guwen + "',yongtu='" + fn.yongtu + "',wuye_type='" + fn.wuye_type + "',chengdu='" + fn.chengdu + "',fang_type='" + fn.fang_type + "',jiancheng='" + fn.jiancheng + "',address='" + fn.address + "',jichusheshi='" + fn.jichusheshi + "',peitaosheshi='" + fn.peitaosheshi + "',yezhu_name='" + fn.yezhu_name + "',tele='" + fn.tele + "',Mobliephone='" + fn.mobliephone + "',beizhu='" + fn.beizhu + "',xiangxi='" + fn.xiangxi + "',len='" + fn.lend + "',lend_price='" + fn.lend_price + "',lend_shuoming='" + fn.lend_shuoming + "',sell='" + fn.sell + "',sell_price='" + fn.sell_price + "',sell_shuoming='" + fn.sell_shuoming + "',yezhu_address='" + fn.yezhu_address + "' where bianhao='" + fn.bianhao + "'";
                    int p = da.RunSql(strsql);
                    if (p > 0)
                    {
                        MessageBox.Show("修改成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("数据更新失败");
                        this.Close();
                    }
                }
                else
                {
                    string sql = "insert into fangyuan (lend,sell,bianhao,jichusheshi,huxing,laiyuan,zhuangtai,wuye,mianji,area,z_floor,n_floor,guwen,yongtu,wuye_type,chengdu,fang_type,jiancheng,address,yezhu_name,tele,mobliephone,beizhu,xiangxi,peitaosheshi,yezhu_address,date,lend_shuoming,lend_price,sell_shuoming,sell_price) values ('" + fn.lend + "','" + fn.sell + "','" + fn.bianhao+ "','" + fn.jichusheshi + "','" + fn.huxing + "','" + fn.laiyuan + "','" + fn.zhuangtai + "','" + fn.wuye + "','" + fn.mianji + "','" + fn.area + "','" + fn.z_floor + "','" + fn.n_floor + "','" + fn.guwen + "','" + fn.yongtu + "','" + fn.wuye_type + "','" + fn.chengdu + "','" + fn.fang_type + "','" + fn.jiancheng + "','" + fn.address + "','" + fn.yezhu_name + "','" + fn.tele + "','" + fn.mobliephone + "','" + fn.beizhu + "','" + fn.xiangxi + "','" + fn.peitaosheshi + "','" + fn.yezhu_address + "','" + date + "','" + fn.lend_shuoming + "','" + fn.lend_price + "','" + fn.sell_shuoming + "','" + fn.sell_price + "')";
                    int i = da.RunSql(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("数据保存成功");
                        this.Close();
                    }
                }


            }
            catch
            {
            }
            finally
            {
                da.Close();
            }


        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                if (this.textBox17.Text.Length < 8)
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
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                if (this.textBox6.Text.Length < 2)
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
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                if (this.textBox6.Text.Length < 2)
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
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                if (this.textBox6.Text.Length < 2)
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
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                if (this.textBox6.Text.Length < 2)
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
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                if (this.textBox6.Text.Length < 2)
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
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                if (this.textBox6.Text.Length < 2)
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
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                if (this.textBox6.Text.Length < 2)
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
                e.Handled = true;
            }
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                if (this.textBox6.Text.Length==11)
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
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要关闭此窗口吗", "信息提示对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }



     
    }
}
