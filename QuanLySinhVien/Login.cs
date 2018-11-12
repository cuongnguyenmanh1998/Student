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
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user, password;
            user = txtUserName.Text;
            password = txtPassword.Text;
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                DialogResult result;
                result = MessageBox.Show(" Yeu cau nhap day du thong tin ", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    txtUserName.Focus();
            }
            else // Nhap day du thong tin 
            {
                if (user == "admin" && password == "111")
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Username hoac password khong dung ! ", "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                        txtUserName.Focus();
                    else
                        Application.Exit();
                }
            }
        }
    }
}
