using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace build
{
    public partial class fangyuan : Form
    {
        public fangyuan()
        {
            InitializeComponent();
        }
        Database da = new Database();
        private void fangyuan_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddDays(-30);
            dateTimePicker2.Value = DateTime.Now.AddDays(1);
            string SelectSql = "select bianhao as 房源编号,date as 登录日期,laiyuan as 房产来源,yezhu_name as 业主姓名,zhuangtai as 当前状态,area as 所处区域,wuye as 物业名称,mianji as 建筑面积,fang_type as 房型,z_floor as 层高,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,huxing as 户型结构,chengdu as 装修度,jiancheng as 建成年份,address as 具体地址,tele as 联系电话,yezhu_address as 具体位置 from fangyuan ";
            DataTable dt2 = da.Query(SelectSql);
            this.dataGridView1.DataSource = dt2;


            #region 显示详细信息
            if (dataGridView1.Rows.Count > 0)
            {
                int index = dataGridView1.CurrentRow.Index;
                string FyNumber = dataGridView1.Rows[index].Cells[0].Value.ToString();
                string sql = "select * from fangyuan where bianhao='" + FyNumber + "'";
                DataTable dt = da.Query(sql);

                //foreach (DataRow dr in dt.Rows)
                //{
                DataRow dr = dt.Rows[index];
                string Lend = dr["lend"].ToString();
                if (Lend == "1")
                {
                    checkBox2.Checked = false;
                    textBox46.Text = "";
                    textBox45.Text = "";
                }
                else
                {
                    checkBox2.Checked = true;
                    textBox46.Text = dr["lend_price"].ToString();
                    textBox45.Text = dr["lend_shuoming"].ToString();
                }
                string sell = dr["sell"].ToString();
                if (sell == "1")
                {
                    checkBox1.Checked = false;
                    textBox44.Text = "";
                    textBox43.Text = "";
                }
                else
                {
                    checkBox1.Checked = true;
                    textBox44.Text = dr["sell_price"].ToString();
                    textBox43.Text = dr["sell_shuoming"].ToString();
                }
                if (Lend == "0" && sell == "0")
                {
                    checkBox2.Checked = true;
                    checkBox1.Checked = true;
                    textBox46.Text = dr["lend_price"].ToString();
                    textBox45.Text = dr["lend_shuoming"].ToString();
                    textBox44.Text = dr["sell_price"].ToString();
                    textBox43.Text = dr["sell_shuoming"].ToString();
                }
                textBox42.Text = dr["zhuangtai"].ToString();
                textBox41.Text = dr["guwen"].ToString();
                textBox40.Text = dr["jiancheng"].ToString();
                textBox39.Text = dr["wuye"].ToString();
                textBox38.Text = dr["yongtu"].ToString();
                textBox37.Text = dr["wuye_type"].ToString();
                textBox36.Text = dr["area"].ToString();
                textBox35.Text = dr["chengdu"].ToString();
                textBox34.Text = dr["fang_type"].ToString();
                textBox33.Text = dr["huxing"].ToString();
                textBox32.Text = dr["mianji"].ToString();
                string LayerNumber = dr["z_floor"].ToString();
                string Stand = dr["n_floor"].ToString();
                textBox31.Text = Stand + "/" + LayerNumber;
                textBox30.Text = dr["jichusheshi"].ToString();
                textBox29.Text = dr["peitaosheshi"].ToString();
                textBox28.Text = dr["address"].ToString();
                textBox2.Text = dr["xiangxi"].ToString();
                textBox47.Text = dr["yezhu_name"].ToString();
                textBox48.Text = dr["tele"].ToString();
                textBox49.Text = dr["mobliephone"].ToString();
                textBox50.Text = dr["yezhu_address"].ToString();
                textBox51.Text = dr["beizhu"].ToString();
            }
            //}
            #endregion
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region 单击Grid显示详细信息
            if (dataGridView1.Rows.Count > 0)
            {
                int index = dataGridView1.CurrentRow.Index;
                string FyNumber = dataGridView1.Rows[index].Cells["房源编号"].Value.ToString();
                string sql = "select * from fangyuan where bianhao='" + FyNumber + "'";
                DataTable dt = da.Query(sql);

                foreach (DataRow dr in dt.Rows)
                {
                    // DataRow dr = dt.Rows[index];
                    bool Lend = Convert.ToBoolean(dr["lend"]);
                    if (Lend == true)
                    {
                        checkBox2.Checked = false;
                        textBox46.Text = "";
                        textBox45.Text = "";
                    }
                    else
                    {
                        checkBox2.Checked = true;
                        textBox46.Text = dr["lend_price"].ToString();
                        textBox45.Text = dr["lend_shuoming"].ToString();
                    }
                    bool sell = Convert.ToBoolean(dr["sell"]);
                    if (sell == true)
                    {
                        checkBox1.Checked = false;
                        textBox44.Text = "";
                        textBox43.Text = "";
                    }
                    else
                    {
                        checkBox1.Checked = true;
                        textBox44.Text = dr["sell_price"].ToString();
                        textBox43.Text = dr["sell_shuoming"].ToString();
                    }
                    if (Lend == false && sell == false)
                    {
                        checkBox2.Checked = true;
                        checkBox1.Checked = true;
                        textBox46.Text = dr["lend_price"].ToString();
                        textBox45.Text = dr["lend_shuoming"].ToString();
                        textBox44.Text = dr["sell_price"].ToString();
                        textBox43.Text = dr["sell_shuoming"].ToString();
                    }
                    textBox42.Text = dr["zhuangtai"].ToString();
                    textBox41.Text = dr["guwen"].ToString();
                    textBox40.Text = dr["jiancheng"].ToString();
                    textBox39.Text = dr["wuye"].ToString();
                    textBox38.Text = dr["yongtu"].ToString();
                    textBox37.Text = dr["wuye_type"].ToString();
                    textBox36.Text = dr["area"].ToString();
                    textBox35.Text = dr["chengdu"].ToString();
                    textBox34.Text = dr["fang_type"].ToString();
                    textBox33.Text = dr["huxing"].ToString();
                    textBox32.Text = dr["mianji"].ToString();
                    string LayerNumber = dr["z_floor"].ToString();
                    string Stand = dr["n_floor"].ToString();
                    textBox31.Text = Stand + "/" + LayerNumber;
                    textBox30.Text = dr["jichusheshi"].ToString();
                    textBox29.Text = dr["peitaosheshi"].ToString();
                    textBox28.Text = dr["address"].ToString();
                    textBox2.Text = dr["xiangxi"].ToString();
                    textBox47.Text = dr["yezhu_name"].ToString();
                    textBox48.Text = dr["tele"].ToString();
                    textBox49.Text = dr["mobliephone"].ToString();
                    textBox50.Text = dr["yezhu_address"].ToString();
                    textBox51.Text = dr["beizhu"].ToString();
                }
            }
            #endregion
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            #region 导出
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "xls";
                saveFileDialog.Filter = "EXCEL文件(*.XLS)|*.xls";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.FileName = "房源信息";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.CreatePrompt = true;
                saveFileDialog.Title = "导出到EXCEL";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName == "")
                    return;
                Stream myStream;
                myStream = saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string str = "";
                try
                {
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        if (i > 0)
                        {
                            str += "\t";
                        }
                        str += dataGridView1.Columns[i].HeaderText;
                    }
                    sw.WriteLine(str);
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        string tempStr = "";
                        for (int k = 0; k < dataGridView1.Columns.Count; k++)
                        {
                            if (k > 0)
                            {
                                tempStr += "\t";
                            }
                            tempStr += dataGridView1.Rows[j].Cells[k].Value.ToString();
                        }
                        sw.WriteLine(tempStr);
                    }
                    sw.Close();
                    myStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string SelectSql = "";
                SelectSql = SelectSql + "date between'" + dateTimePicker1.Value + "'and '" + dateTimePicker2.Value + "' and ";
                if (comboBox1.Text != "所有")
                {
                    SelectSql = SelectSql + "laiyuan='" + comboBox1.Text + "' and ";
                }
                if (comboBox2.Text != "所有")
                {
                    SelectSql = SelectSql + "zhuangtai='" + comboBox2.Text + "' and ";
                }
                if (textBox1.Text != "")
                {
                    SelectSql = SelectSql + "guwen='" + textBox1.Text + "' and";
                }
                if (comboBox3.Text != "所有")
                {
                    if (comboBox3.Text == "出租")
                    {
                        SelectSql = SelectSql + "Lend=1 and ";
                    }
                    if (comboBox3.Text == "出售")
                    {
                        SelectSql = SelectSql + "sell=1 and ";
                    }
                }

                dataGridView1.DataSource = this.QueryFNews(SelectSql);

            }
            catch
            {

            }
        }

        public DataTable QueryFNews(string Condition)
        {
            #region 查询
            string SelectSql;
            Condition = Condition.Trim();
            if (Condition != "")
            {
                if (Condition.Substring((Condition.Length - 3), 3) == "and")
                    Condition = Condition.Remove(Condition.Length - 3);
                SelectSql = selectFNews() + " where " + Condition;
            }
            else
            {
                SelectSql = selectFNews();
            }
            return da.Query(SelectSql);
            #endregion
        }
        public string selectFNews()
        {
            #region 查询房源信息
            string strSql = "select bianhao as 房源编号,date as 登录日期,laiyuan as 房产来源,yezhu_name as 业主姓名,zhuangtai as 当前状态,area as 所处区域,wuye as 物业名称,mianji as 建筑面积,fang_type as 房型,z_floor as 层高,guwen as 置业顾问,yongtu as 物业用途,wuye_type as 物业类别,huxing as 户型结构,chengdu as 装修度,jiancheng as 建成年份,address as 具体地址,tele as 联系电话,yezhu_address as 具体位置 from fangyuan ";
            return strSql;
            #endregion
        }
    }
}
