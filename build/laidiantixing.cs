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
    public partial class laidiantixing : Form
    {
        public laidiantixing()
        {
            InitializeComponent();
        }
       
        ldian laid = new ldian();
        Database data = new Database();
        public string idn;
        public laidiantixing(ldian ldd)
        {
            InitializeComponent();
            laid = ldd;
                
        }
        private void laidiantixing_Load(object sender, EventArgs e)
        {
            string sj = "yyyy-MM-dd HH:mm:ss";
            this.textBox3.Text = DateTime.Now.ToString(sj);
            if (laid.id != null)
            {
                this.comboBox1.Text = laid.ld_kehuleixing;
                this.textBox1.Text = laid.ld_name;
                this.textBox2.Text = laid.tele;
                this.textBox3.Text = laid.date;
                this.textBox4.Text = laid.ld_neirong;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ld_kehuleixing = this.comboBox1.Text;
            string ld_name = this.textBox1.Text;
            string tele = this.textBox2.Text;
            string ld_neirong = this.textBox4.Text;
            string date = this.textBox3.Text;
            
            SqlParameter[] prames =
            {
                data.MakeInParam("@ld_kehuleixing",SqlDbType.VarChar,ld_kehuleixing.ToString()),
                data.MakeInParam("@ld_name",SqlDbType.VarChar,ld_name.ToString()),
                data.MakeInParam("@tele",SqlDbType.VarChar,tele.ToString()),
                data.MakeInParam("@ld_neirong",SqlDbType.VarChar,ld_neirong.ToString()),
                data.MakeInParam("@date",SqlDbType.DateTime,date.ToString()),
            };
            string sql_in = "";
            if (idn == null)
            {
                sql_in = "insert into laidian (ld_kehuleixing,ld_name,tele,ld_neirong,date) values (@ld_kehuleixing,@ld_name,@tele,@ld_neirong,@date)";
            }
            else
            {
                sql_in = "update laidian set ld_kehuleixing=@ld_kehuleixing,ld_name=@ld_name,tele=@tele,ld_neirong=@ld_neirong,date=@date where id='" + idn + "'";
            }
            int i = data.RunSql(sql_in, prames);
            if (i > 0)
            {
                if (MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
