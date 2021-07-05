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
    public partial class Xtsz : Form
    {
        public Xtsz()
        {
            InitializeComponent();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            AddCompany ac = new AddCompany();
            ac.ShowDialog();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Update_Data ud = new Update_Data();
            ud.ShowDialog();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            AboutEmployee ae = new AboutEmployee();
            ae.ShowDialog();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            DelDatabase Da = new DelDatabase();
            Da.ShowDialog();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            quanxian qx = new quanxian();
            qx.ShowDialog();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            canshuguanli cs = new canshuguanli();
            cs.ShowDialog();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                gaiPass gai = new gaiPass();
                gai.ShowDialog();
            }
            catch { }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                rizhi rizhi = new rizhi();
                rizhi.ShowDialog();
            }
            catch { }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            try
            {
                hetong hetong = new hetong();
                hetong.ShowDialog();
            }
            catch { }
        }
    }
}
