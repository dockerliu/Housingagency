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
    public partial class quanxian : Form
    {
        public quanxian()
        {
            InitializeComponent();
        }
        Database data = new Database();
        private void quanxian_Load(object sender, EventArgs e)
        {
            string sql = "select _jibie from jibie";
            DataTable dt = data.Query(sql);
            this.dataGridView1.DataSource = dt;

            string sql2="select _jibie,_name,_username,case when z1._sta='true' then '可用' when z1._sta='false' then '停用' end as '当前状态' from login_user z1 inner join jibie z2 on z1._jibieid=z2.id";
            DataTable da = data.Query(sql2);
            this.dataGridView2.DataSource = da;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            aboutquanxian aboutquan = new aboutquanxian();
            aboutquan.did = 0;
            aboutquan.freshdtv+=new aboutquanxian.freshdtvEventHandler(quanxian_Load);
            aboutquan.ShowDialog();
        }
        private void quanxian_Load(object sender,eventArgs2 e)
        {
            string sql = "select _jibie from jibie";
            DataTable dt = data.Query(sql);
            this.dataGridView1.DataSource = dt;
            int i = this.dataGridView1.RowCount;
            for (int j = 0; j < i; j++)
            {
                this.dataGridView1.Rows[j].Selected = false;

            }
            this.dataGridView1.Rows[e.ss_num].Selected = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                aboutquanxian aboutquan = new aboutquanxian();
                aboutquan.did = 1;
                aboutquan.ename = this.dataGridView1.SelectedCells[0].Value.ToString();
                aboutquan.ss_num = this.dataGridView1.SelectedCells[0].OwningRow.Index;
                aboutquan.freshdtv += new aboutquanxian.freshdtvEventHandler(quanxian_Load);
                aboutquan.ShowDialog();
            }
            else
            {
                DialogResult da = MessageBox.Show("目前没有管理人员，是否添加?","信息提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (da == DialogResult.OK)
                {
                    aboutquanxian aboutquan = new aboutquanxian();
                    aboutquan.did = 0;
                    aboutquan.freshdtv+=new aboutquanxian.freshdtvEventHandler(quanxian_Load);
                    aboutquan.ShowDialog();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                DialogResult da = MessageBox.Show("确定要删除吗?","删除信息",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (da == DialogResult.OK)
                {
                    string jibie = this.dataGridView1.SelectedCells[0].Value.ToString();
                    string sql = "delete from jibie where _jibie='"+jibie+"'";
                    data.RunSql(sql);
                    quanxian_Load(this,e);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _info inf = new _info();
           inf.i = 0;
            inf.fresh+=new _info.freshEventHandler(reload);
            inf.ShowDialog();

        }
        private void reload(object sender,eventArgs2 e)
        {
            string sql2 = "select _jibie,_name,_username,case when z1._sta='true' then '可用' when z1._sta='false' then '停用' end as '当前状态' from login_user z1 inner join jibie z2 on z1._jibieid=z2.id";
            DataTable da = data.Query(sql2);
            this.dataGridView2.DataSource = da;
            if (this.dataGridView2.Rows.Count > 0)
            {
                if (e.ss_num != -1)
                {
                    this.dataGridView2.Rows[e.ss_num].Selected = true;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.Rows.Count > 0)
            {
                _info inf = new _info();
                inf.i = 1;
                int st = this.dataGridView2.SelectedCells[0].OwningRow.Index;
                inf.k = st;
                inf.st = this.dataGridView2.Rows[st].Cells[1].Value.ToString();
                inf.fresh += new _info.freshEventHandler(reload);
                inf.ShowDialog();
            }
            else
            {
                MessageBox.Show("当前没有可供修改的数据");
            }

        }
    }
}
