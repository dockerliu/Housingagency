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
    public partial class canshuguanli : Form
    {
        public canshuguanli()
        {
            InitializeComponent();
        }
        ParaNewsBind paraNewsBind = new ParaNewsBind();
        bool t = false;
        private void canshuguanli_Load(object sender, EventArgs e)
        {
            this.treeView1.ExpandAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (t == false)
            {
                ContratInfo contractInfo = new ContratInfo();
                contractInfo.ParaInfo = treeView1.SelectedNode.Text;
                xiugaicanshu ps = new xiugaicanshu(contractInfo);
                ps.ShowDialog();


            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                ContratInfo contractInfo = new ContratInfo();
                int i = dataGridView1.CurrentRow.Index;
                string CName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                DataTable dt = new DataTable();
                switch (treeView1.SelectedNode.Text)
                {
                    case "房屋来源":
                        dt = paraNewsBind.fwlySelect2(CName);
                        break;
                    case "房源状态":
                        dt = paraNewsBind.fyztSelect2(CName);
                        break;
                    case "物业用途":
                        dt = paraNewsBind.wyytSelect2(CName);
                        break;
                    case "物业类别":
                        dt = paraNewsBind.wylbSelect2(CName);
                        break;
                    case "装修程度":
                        dt = paraNewsBind.zxcdSelect2(CName);
                        break;
                    case "所处区域":
                        dt = paraNewsBind.scqySelect2(CName);
                        break;
                    case "房屋类型":
                        dt = paraNewsBind.fwlxSelect2(CName);
                        break;
                    case "配套设施":
                        dt = paraNewsBind.ptssSelect2(CName);
                        break;
                    case "客户状态":
                        dt = paraNewsBind.khztSelect2(CName);
                        break;
                    case "跟进方式":
                        dt = paraNewsBind.gjfsSelect2(CName);
                        break;
                    case "付款方式":
                        dt = paraNewsBind.fkfsSelect2(CName);
                        break;
                    case "分成说明":
                        dt = paraNewsBind.fcsmSelect2(CName);
                        break;

                }
                foreach (DataRow dr in dt.Rows)
                {
                    contractInfo.ParaSet = dr["名称"].ToString();

                }
                contractInfo.ParaInfo = treeView1.SelectedNode.Text;
                xiugaicanshu ps = new xiugaicanshu(contractInfo);
                ps.ShowDialog();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int i = dataGridView1.CurrentRow.Index;
                string str = dataGridView1.Rows[i].Cells["名称"].Value.ToString();
                if (MessageBox.Show("删除后将不能恢复！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    switch (treeView1.SelectedNode.Text)
                    {
                        case "房屋来源":
                            paraNewsBind.fwlyDelete(str);
                            dataGridView1.DataSource = paraNewsBind.fwlySelect();
                            break;
                        case "房源状态":
                            paraNewsBind.fyztDelete(str);
                            dataGridView1.DataSource = paraNewsBind.fyztSelect();
                            break;
                        case "物业用途":
                            paraNewsBind.wyytDelete(str);
                            dataGridView1.DataSource = paraNewsBind.wyytSelect();
                            break;
                        case "物业类别":
                            paraNewsBind.wylbDelete(str);
                            dataGridView1.DataSource = paraNewsBind.wylbSelect();
                            break;
                        case "装修程度":
                            paraNewsBind.zxcdDelete(str);
                            dataGridView1.DataSource = paraNewsBind.zxcdSelect();
                            break;
                        case "所处区域":
                            paraNewsBind.scqyDelete(str);
                            dataGridView1.DataSource = paraNewsBind.scqySelect();
                            break;
                        case "房屋类型":
                            paraNewsBind.fwlxDelete(str);
                            dataGridView1.DataSource = paraNewsBind.fwlxSelect();
                            break;
                        case "配套设施":
                            paraNewsBind.ptssDelete(str);
                            dataGridView1.DataSource = paraNewsBind.ptssSelect();
                            break;
                        case "客户状态":
                            paraNewsBind.khztDelete(str);
                            dataGridView1.DataSource = paraNewsBind.khztSelect();
                            break;
                        case "跟进方式":
                            paraNewsBind.gjfsDelete(str);
                            dataGridView1.DataSource = paraNewsBind.gjfsSelect();
                            break;
                        case "付款方式":
                            paraNewsBind.fkfsDelete(str);
                            dataGridView1.DataSource = paraNewsBind.fkfsSelect();
                            break;
                        case "分成说明":
                            paraNewsBind.fcsmDelete(str);
                            dataGridView1.DataSource = paraNewsBind.fcsmSelect();
                            break;

                    }

                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Text.Trim())
            {
                case "房屋来源":
                    dataGridView1.DataSource = paraNewsBind.fwlySelect();
                    t = false;
                    break;
                case "房源状态":
                    dataGridView1.DataSource = paraNewsBind.fyztSelect();
                    t = false;
                    break;
                case "物业用途":
                    dataGridView1.DataSource = paraNewsBind.wyytSelect();
                    t = false;
                    break;
                case "物业类别":
                    dataGridView1.DataSource = paraNewsBind.wylbSelect();
                    t = false;
                    break;
                case "装修程度":
                    dataGridView1.DataSource = paraNewsBind.zxcdSelect();
                    t = false;
                    break;
                case "所处区域":
                    dataGridView1.DataSource = paraNewsBind.scqySelect();
                    t = false;
                    break;
                case "房屋类型":
                    dataGridView1.DataSource = paraNewsBind.fwlxSelect();
                    t = false;
                    break;
                case "配套设施":
                    dataGridView1.DataSource = paraNewsBind.ptssSelect();
                    t = false;
                    break;
                case "客户状态":
                    dataGridView1.DataSource = paraNewsBind.khztSelect();
                    t = false;
                    break;
                case "跟进方式":
                    dataGridView1.DataSource = paraNewsBind.gjfsSelect();
                    t = false;
                    break;
                case "付款方式":
                    dataGridView1.DataSource = paraNewsBind.fkfsSelect();
                    t = false;
                    break;
                case "分成说明":
                    dataGridView1.DataSource = paraNewsBind.fcsmSelect();
                    t = false;
                    break;
                default:
                    t = true;
                    break;
            }


        }
    }
}
