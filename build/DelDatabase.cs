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
    public partial class DelDatabase : Form
    {
        public DelDatabase()
        {
            InitializeComponent();
        }
        Database data = new Database();
        string sql = null;
        string sql2 = null;
        private void DelDatabase_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt1, dt2;
            dt1 = this.dateTimePicker1.Value;
            dt2 = this.dateTimePicker2.Value;
            if (this.radioButton1.Checked == true)
            {
                sql = "delete from fangyuan";
            }
            if (this.radioButton2.Checked == true)
            {
                sql = "delete from kehu";
            }
            if (this.radioButton3.Checked == true)
            {
                sql = "delete from kehu where date>'"+dt1+"' and date<'"+dt2+"'";
            }
            if (this.radioButton4.Checked == true)
            {
                sql = "delete from fangyuan where date>'"+dt1+"' and date<'"+dt2+"'";

            }
            if (this.radioButton5.Checked == true)
            {
                sql = "delete from kehu";
                sql2 = "delete from fangyuan";
            }
            if (sql2 != null)
            {
                try
                {
                    int i = data.RunSql(sql);
                    int j = data.RunSql(sql2);
                    if (i > 0 && j > 0)
                    {
                        MessageBox.Show("删除成功");
                    }
                }
                catch
                {
                    MessageBox.Show("出现未知错误，删除失败");
                }
            }
            else
            {
                int i = data.RunSql(sql);
                if (i > 0)
                {
                    MessageBox.Show("删除成功");
                }
            }

        }
    }
}
