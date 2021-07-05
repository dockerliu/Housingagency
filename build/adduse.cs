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
    public partial class adduse : Form
    {
        public adduse()
        {
            InitializeComponent();
        }
        public string  f_num;
        public delegate void proeEventHandler(object sender, NameEventArgs e);
        public event proeEventHandler proe;
        Database data = new Database();
        private void adduse_Load(object sender, EventArgs e)
        {
            string sql = "select _num as 员工编号,_name as 员工姓名 from empl_info where _name not in(select empnumber from divide where fnumber='"+f_num+"')";
            DataTable dt = data.Query(sql);
            this.dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount > 0)
            {
                proeEventHandler hand = proe;
                NameEventArgs ave = new NameEventArgs();
                ave.Str = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                if (hand != null)
                {
                    hand(this,ave);
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("当前没有可选择的员工 ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployee add = new AddEmployee();
            add.Show();
        }
    }
}
