using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
namespace build
{
    public partial class LiuLan : Form
    {
        public LiuLan()
        {
            InitializeComponent();
        }
        public string  id;//要浏览的记录的编号

        private void LiuLan_Load(object sender, EventArgs e)
        {
            

        }

        private void LiuLan_Load_1(object sender, EventArgs e)
        {
            ReportDocument document = new ReportDocument();//声明一个报表
            SqlConnection conn = new SqlConnection("server=.;uid=home;pwd=;database=build");
            conn.Open();
            SqlDataAdapter apter = new SqlDataAdapter("select * from fangyuan where bianhao=" + id, conn);
            DataTable da = new DataTable();
            apter.Fill(da);
            document.FileName = "PrintView.rpt";//指定报表文件
            document.SetDataSource(da);//将DataTable中的数据，绑定到报表文件上.
            this.crystalReportViewer1.ReportSource = document;//将报表文件绑定到控件 CrystalReportViewer上，以便显示具体报表内容。
            conn.Close();
        }

    }
}
