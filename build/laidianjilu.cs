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
    public partial class laidianjilu : Form
    {
        public laidianjilu()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void laidianjilu_Load(object sender, EventArgs e)
        {
            string sql = "select id as 号码,ld_kehuleixing as 客户类型,ld_name as 客户姓名,tele as 客户电话,date as 来电日期,ld_neirong as 来电内容 from laidian order by id";
            DataTable dat = data.Query(sql);
            this.dataGridView1.DataSource = dat;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                try
                {
                    int st = this.dataGridView1.SelectedRows[0].Index;
                    string str = this.dataGridView1.Rows[st].Cells[0].Value.ToString();
                    DialogResult df = MessageBox.Show("确定要删除本条记录吗?","信息提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                    if (df == DialogResult.OK)
                    {
                        string sql = "delete from laidian where id='"+str+"'";
                        int i = data.RunSql(sql);
                        if (i > 0)
                        {
                            MessageBox.Show("数据删除成功");
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("数据删除失败");
                    }

                }
                catch
                {
                    MessageBox.Show("数据删除失败");
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ldian ldd = new ldian();
            int i = this.dataGridView1.CurrentRow.Index;
            string id = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
            string sql_1 = "select * from laidian where id='"+id+"'";
            DataTable dt = data.Query(sql_1);
            foreach(DataRow dr in dt.Rows)
            {
                ldd.id = dr["id"].ToString();
                ldd.ld_kehuleixing = dr["ld_kehuleixing"].ToString();
                ldd.ld_name = dr["ld_name"].ToString();
                ldd.tele = dr["tele"].ToString();
                ldd.ld_neirong = dr["ld_neirong"].ToString();
                ldd.date = dr["date"].ToString();

            }
            laidiantixing ldtx = new laidiantixing(ldd);
            ldtx.idn = id;
            ldtx.ShowDialog();
        }
    }
}
