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
    public partial class Deletes : Form
    {
        public Deletes()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("server=.;uid=home;pwd=;database=build");
        private void Deletes_Load(object sender, EventArgs e)
        {
            GetInfo();
        }
        private void GetInfo()
        {
            SqlDataAdapter apter = new SqlDataAdapter("select * from fangyuan",conn);
            DataSet ds = new DataSet();
            apter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
            ds.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string xzid = "";
                conn.Open();
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    if (row.Cells[0].Value != null)
                    {
                        if (bool.Parse(row.Cells[0].Value.ToString()) == true)
                        {
                            int row1 = row.Index;
                            xzid = xzid + "'" + this.dataGridView1[1, row1].Value.ToString() + "'" + ",";
                        }
                    }
                }
                if (xzid.Length > 0)
                {
                    xzid.Substring(0, xzid.Length - 1);
                }
                string sql = string.Format("delete from fangyuan where bianhao in {0}", xzid);
                if (MessageBox.Show("确定要删除指定的数据吗?", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand comm = new SqlCommand(sql, conn);
                    int g = comm.ExecuteNonQuery();
                    if (g > 0)
                    {
                        MessageBox.Show("数据删除成功");
                    }
                    else
                    {
                        MessageBox.Show("数据删除失败");
                    }
                }

            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }

        }
    
    }
}
