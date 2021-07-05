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
    public partial class CaiDan : Form
    {
        public CaiDan()
        {
            InitializeComponent();
        }

        private void CaiDan_Load(object sender, EventArgs e)
        {
            CreateMenu();
        }
        private void CreateMenu()
        {
            //定义一个主菜单
            MenuStrip mainMenu = new MenuStrip();
            DataSet ds = new DataSet();
            //从XML文件中读取数据
            ds.ReadXml(@"..\..\Menu.xml");
            DataView dv = ds.Tables[0].DefaultView;
            //通过DataView来过滤，首先得到最顶层的菜单
            dv.RowFilter = "ParentItemID=0";
            for (int i = 0; i < dv.Count;i++ )
            {
                //创建一个菜单项
                ToolStripMenuItem topMenu = new ToolStripMenuItem();
                //给菜单赋值
                topMenu.Text = dv[i]["Text"].ToString();
                //如果是有下级菜单，通过CreateSubMenu方法来创建下级菜单
                if (Convert.ToInt32(dv[i]["IsModule"]) == 1)
                {
                    CreateSubMenu(ref topMenu,Convert.ToInt32(dv[i]["ItemID"]),ds.Tables[0]);
                }
                //显示应用程序中已经打开的MDI子窗体列表的菜单项
                mainMenu.MdiWindowListItem = topMenu;
                //讲递归附加好的菜单加到主菜单上。

                mainMenu.Items.Add(topMenu);

            }
            mainMenu.Dock = DockStyle.Top;
            this.MainMenuStrip = mainMenu;
            this.Controls.Add(mainMenu);



        }
        /// <summary>
        /// 创建当前菜单子菜单
        /// </summary>
        /// <param name="topMenu">父菜单</param>
        /// <param name="ItemID">父菜单的编号</param>
        /// <param name="dt">菜单需要的数据内容</param>
        private void CreateSubMenu(ref ToolStripMenuItem topMenu,int ItemID,DataTable dt)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = "ParentItemID="+ItemID;
            for (int i = 0; i < dv.Count; i++)
            {
                //创建子菜单项
                ToolStripMenuItem subMenu = new ToolStripMenuItem();
                subMenu.Text = dv[i]["Text"].ToString();
                //如果还子菜单则继续递归加载
                if (Convert.ToInt32(dv[i]["IsModule"]) == 1)
                {
                    //递归调用
                    CreateSubMenu(ref subMenu, Convert.ToInt32(dv[i]["ItemID"].ToString()), dt);
                }
                else
                {
                    subMenu.Tag = dv[i]["FormName"].ToString();
                    subMenu.Click += new EventHandler(SubMenu_Click);
                }

                topMenu.DropDownItems.Add(subMenu);
            }


        }
        private void SubMenu_Click(object sender, EventArgs e)
        {
            string formName = ((ToolStripMenuItem)sender).Tag.ToString();
            //CreateForm(formName);

        }
    }
}
