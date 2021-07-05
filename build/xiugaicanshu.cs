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
    public partial class xiugaicanshu : Form
    {
        public xiugaicanshu()
        {
            InitializeComponent();
        }
        ContratInfo cInfo = new ContratInfo();
        public xiugaicanshu(ContratInfo contratInfo)
        {
            InitializeComponent();
            cInfo = contratInfo;
        }

        private void xiugaicanshu_Load(object sender, EventArgs e)
        {

            if (cInfo.ParaSet != null)
            {
                groupBox1.Text = cInfo.ParaInfo;
                textBox1.Text = cInfo.ParaSet;
            }
            else
            {
                groupBox1.Text = cInfo.ParaInfo;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ParaNewsBind pbind = new ParaNewsBind();
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                DataTable dt = new DataTable();//判断重名
                switch (groupBox1.Text)
                {
                    case "房屋来源":
                        dt = pbind.fwlySelect();
                        break;
                    case "房源状态":
                        dt = pbind.fyztSelect();
                        break;
                    case "物业用途":
                        dt = pbind.wyytSelect();
                        break;
                    case "物业类别":
                        dt = pbind.wylbSelect();
                        break;
                    case "装修程度":
                        dt = pbind.zxcdSelect();
                        break;
                    case "所处区域":
                        dt = pbind.scqySelect();
                        break;
                    case "房屋类型":
                        dt = pbind.fwlxSelect();
                        break;
                    case "配套设施":
                        dt = pbind.ptssSelect();
                        break;
                    case "客户状态":
                        dt = pbind.khztSelect();
                        break;
                    case "跟进方式":
                        dt = pbind.gjfsSelect();
                        break;
                    case "付款方式":
                        dt = pbind.fkfsSelect();
                        break;
                    case "分成说明":
                        dt = pbind.fcsmSelect();
                        break;

                }
                bool t = false;
                foreach (DataRow dr in dt.Rows)
                {
                    if (textBox1.Text == dr["名称"].ToString())
                    {
                        t = true;
                    }
                }
                if (t != true)
                {
                    if (cInfo.ParaSet == null)
                    {

                        switch (groupBox1.Text)//插入数据
                        {
                            case "房屋来源":
                                pbind.fwlyInsert(textBox1.Text.Trim());
                                break;
                            case "房源状态":
                                pbind.fyztInsert(textBox1.Text.Trim());
                                break;
                            case "物业用途":
                                pbind.wyytInsert(textBox1.Text.Trim());
                                break;
                            case "物业类别":
                                pbind.wylbInsert(textBox1.Text.Trim());
                                break;
                            case "装修程度":
                                pbind.zxcdInsert(textBox1.Text.Trim());
                                break;
                            case "所处区域":
                                pbind.scqyInsert(textBox1.Text.Trim());
                                break;
                            case "房屋类型":
                                pbind.fwlxInsert(textBox1.Text.Trim());
                                break;
                            case "配套设施":
                                pbind.ptssInsert(textBox1.Text.Trim());
                                break;
                            case "客户状态":
                                pbind.khztInsert(textBox1.Text.Trim());
                                break;
                            case "跟进方式":
                                pbind.gjfsInsert(textBox1.Text.Trim());
                                break;
                            case "付款方式":
                                pbind.fkfsInsert(textBox1.Text.Trim());
                                break;
                            case "分成说明":
                                pbind.fcsmInsert(textBox1.Text.Trim());
                                break;

                        }
                    }
                    else
                    {
                        //更行数据
                        switch (groupBox1.Text)
                        {
                            case "房屋来源":
                                pbind.fwlyUpdate(cInfo.ParaSet, textBox1.Text.Trim());
                                break;
                            case "房源状态":
                                pbind.fyztUpdate(cInfo.ParaSet, textBox1.Text.Trim());
                                break;
                            case "物业用途":
                                pbind.wyytUpdate(cInfo.ParaSet, textBox1.Text.Trim());
                                break;
                            case "物业类别":
                                pbind.wylbUpdate(cInfo.ParaSet, textBox1.Text.Trim());
                                break;
                            case "装修程度":
                                pbind.zxcdUpdate(cInfo.ParaSet, textBox1.Text.Trim());
                                break;
                            case "所处区域":
                                pbind.scqyUpdate(cInfo.ParaSet, textBox1.Text.Trim());
                                break;
                            case "房屋类型":
                                pbind.fwlxUpdate(cInfo.ParaSet, textBox1.Text.Trim());
                                break;
                            case "配套设施":
                                pbind.ptssUpdate(cInfo.ParaSet, textBox1.Text.Trim());
                                break;
                            case "客户状态":
                                pbind.khztUpdate(cInfo.ParaSet, textBox1.Text.Trim());
                                break;
                            case "跟进方式":
                                pbind.gjfsUpdate(cInfo.ParaSet, textBox1.Text.Trim());
                                break;
                            case "付款方式":
                                pbind.fkfsUpdate(cInfo.ParaSet, textBox1.Text.Trim());
                                break;
                            case "分成说明":
                                pbind.fcsmUpdate(cInfo.ParaSet, textBox1.Text.Trim());
                                break;

                        }
                    }
                    this.Close();

                }
                else
                {
                    MessageBox.Show("名称已存在!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                }




            }
            else
            {
                MessageBox.Show("名称不能为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
            }
        }


    }
}

