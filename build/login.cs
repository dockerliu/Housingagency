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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        bool t = false;
        public static string _UserName;
        public static string _Pass;
        public static bool _RCGL;
        public static bool _FYGL;
        public static bool _KHGL;
        public static bool _NBGL;
        public static bool _XTSZ;
        Database data = new Database();
        dl dl = new dl();
        public login(bool bb)
        {
            t = bb;
        }
        private void login_Load(object sender, EventArgs e)
        {
            this.skinEngine1.SkinFile = "DiamondBlue.ssk";
            try
            {
                string sql = "select * from login_user";
                DataTable dd = data.Query(sql);
                this.comboBox1.DataSource = dd;
                this.comboBox1.DisplayMember = "_name";



            }
            catch
            {

            }
            finally
            {
                data.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sysHandleInfo syshandleInfo = new sysHandleInfo();
                bool b = false;
                int jiebie_Id = 0;
                string sql = "select * from login_user";
                DataTable dt = data.Query(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (this.comboBox1.Text == dr["_name"].ToString() && this.textBox1.Text == dr["_pass"].ToString())
                    {
                        b = true;
                        _UserName = dr["_name"].ToString();
                        _Pass = dr["_pass"].ToString();
                        jiebie_Id = Convert.ToInt32(dr["_jibieid"]);
                        string sql_id = "select * from jibie where id='"+jiebie_Id+"'";
                        DataTable dt1 = data.Query(sql_id);
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            _RCGL = Convert.ToBoolean(dr1["_richang"]);
                            _FYGL = Convert.ToBoolean(dr1["_fangyuan"]);
                            _KHGL = Convert.ToBoolean(dr1["_kehu"]);
                            _NBGL = Convert.ToBoolean(dr1["_neibu"]);
                            _XTSZ = Convert.ToBoolean(dr1["_xitong"]);
                        }

                    }

                }
                if (b == true)
                {
                    syshandleInfo.HandlePerson = this.comboBox1.Text;
                    syshandleInfo.HandleContent = "操作员登录";
                    syshandleInfo.HandleRemark = this.comboBox1.Text + "登录系统";
                    dl.InsertHandle(syshandleInfo);
                    if (t != true)
                    {
                        mainform main = new mainform();
                        main.Show();
                        this.Visible = false;

                    }
                    else
                    {
                        this.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("用户名或密码错误!","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
