using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSinhVien sv = new frmSinhVien();
            sv.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Show();

            Login lg = new Login();
            DialogResult result = lg.ShowDialog();
            if(result==DialogResult.OK)
            {
                this.Enabled = true;
                lbten.Text = " Hệ Thống Quản Lý Sinh Viên";
            }
        }

        private void điểmSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiem diem = new frmDiem();
            diem.ShowDialog();
        }

        private void lớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLopHoc frmlh = new frmLopHoc();
            frmlh.ShowDialog();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonHoc frmmh = new frmMonHoc();
            frmmh.ShowDialog();
        }
    }
}
