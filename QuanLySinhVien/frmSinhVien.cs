using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien()
        {
            InitializeComponent();
        }
        
        private List<SinhVien> getSinhVien()
        {
            string cnStr = "Server=DESKTOP-L99J7R8\\SQLEXPRESS;Database = QLHocVien;Integrated security=true";
            SqlConnection cn = new SqlConnection(cnStr);
            string sql = "SELECT *FROM HOCVIEN";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<SinhVien> list = new List<SinhVien>();
            string MaHocVien, TenHocVien, NgaySinh, TinhTrang,Lop;
            while(dr.Read())
            {
                MaHocVien = dr[0].ToString();
                TenHocVien = dr[1].ToString();
                NgaySinh = dr[2].ToString();
                TinhTrang = dr[3].ToString();
                Lop = dr[4].ToString();
                SinhVien sv = new SinhVien(MaHocVien, TenHocVien, NgaySinh, TinhTrang,Lop);
                list.Add(sv);
            }
            dr.Close();
            cn.Close();

            return list;
        }
        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            List<SinhVien> list = getSinhVien();
            dataGridView1.DataSource = list;
            textBox1.DataBindings.Add("Text", list, "MaHocVien");
            textBox2.DataBindings.Add("Text", list, "TenHocVien");
            textBox3.DataBindings.Add("Text", list, "NgaySinh");
            textBox4.DataBindings.Add("Text", list, "TinhTrang");
            textBox5.DataBindings.Add("Text", list, "Lop");
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string cnStr = "Server=DESKTOP-L99J7R8\\SQLEXPRESS;Database = QLHocVien;Integrated security=true";
            SqlConnection cn = new SqlConnection(cnStr);

            string MaHocVien, TenHocVien, NgaySinh, TinhTrang,Lop;
            MaHocVien = textBox1.Text;
            TenHocVien = textBox2.Text;
            NgaySinh = textBox3.Text;
            TinhTrang = textBox4.Text;
            Lop = textBox5.Text;

            //Kiem tra 3 thong tin 

            if (string.IsNullOrEmpty(MaHocVien))
                return;
            string sql = "INSERT INTO HOCVIEN VALUES('" + MaHocVien + "',N'" + TenHocVien + "',N'" + NgaySinh + "',N'" + TinhTrang + "',N'"+Lop+"')";
            SqlCommand cmd = new SqlCommand(sql, cn);

            cn.Open();
            int numberOfRows = cmd.ExecuteNonQuery();
            if (numberOfRows <= 0)
            {
                MessageBox.Show("Them that bai ", "Them sinh vien ");
            }
            else
                MessageBox.Show("Them thanh cong ", "Them sinh vien ");
            dataGridView1.DataSource = getSinhVien();
            cn.Close();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string cnStr = "Server=DESKTOP-L99J7R8\\SQLEXPRESS;Database = QLHocVien;Integrated security=true";
            SqlConnection cn = new SqlConnection(cnStr);

            string MaHocVien, TenHocVien, NgaySinh, TinhTrang,Lop;
            MaHocVien = textBox1.Text;
            TenHocVien = textBox2.Text;
            NgaySinh = textBox3.Text;
            TinhTrang = textBox4.Text;
            Lop = textBox5.Text;

            string sql = "DELETE FROM HOCVIEN WHERE MaHocVien='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int numberOfRows = cmd.ExecuteNonQuery();
            if (numberOfRows >= 0)
            {
                MessageBox.Show("Xoa thanh cong ");
            }
            else
                MessageBox.Show("Xoa that bai ");
            dataGridView1.DataSource = getSinhVien();
            cn.Close();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string cnStr = "Server=DESKTOP-L99J7R8\\SQLEXPRESS;Database = QLHocVien;Integrated security=true";
            SqlConnection cn = new SqlConnection(cnStr);

            string MaHocVien, TenHocVien, NgaySinh, TinhTrang,Lop;
            MaHocVien = textBox1.Text;
            TenHocVien = textBox2.Text;
            NgaySinh = textBox3.Text;
            TinhTrang = textBox4.Text;
            Lop = textBox5.Text;

            //Kiem tra 3 thong tin 

            if (string.IsNullOrEmpty(MaHocVien))
                return;
            string sql = "UPDATE HOCVIEN SET TenHocVien='" + textBox2.Text + "',NgaySinh='" + textBox3.Text + "',TinhTrang='" + textBox4.Text + "',Lop='" + textBox5.Text + "'WHERE MaHocVien='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, cn);
 
            cn.Open();
            int numberOfRows = cmd.ExecuteNonQuery();
            if (numberOfRows <= 0)
            {
                MessageBox.Show("sửa thất bại ");
            }
            else
                MessageBox.Show("sửa thành công ");
            dataGridView1.DataSource = getSinhVien();
            cn.Close();     
        }

    }
}
