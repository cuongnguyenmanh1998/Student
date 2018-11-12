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
    public partial class frmDiem : Form
    {
        public frmDiem()
        {
            InitializeComponent();
        }
        private List<DiemSV> getDiemSinhVien()
        {
            string cnStr = "Server=DESKTOP-L99J7R8\\SQLEXPRESS;Database = QLHocVien;Integrated security=true";
            SqlConnection cn = new SqlConnection(cnStr);
            string sql = "SELECT *FROM KETQUA";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<DiemSV> list = new List<DiemSV>();
            string MaHV, MaMonHoc, LanThi, Diem;
            while (dr.Read())
            {
                MaHV = dr[0].ToString();
                MaMonHoc = dr[1].ToString();
                LanThi = dr[2].ToString();
                Diem = dr[3].ToString();
                DiemSV sv = new DiemSV(MaHV, MaMonHoc, LanThi, Diem);
                list.Add(sv);
            }
            dr.Close();
            cn.Close();

            return list;
        }

        private void frmDiem_Load(object sender, EventArgs e)
        {
            List<DiemSV> list = getDiemSinhVien();
            dataGridView1.DataSource = list;
            textBox1.DataBindings.Add("Text", list, "MaHV");
            textBox2.DataBindings.Add("Text", list, "MaMonHoc");
            textBox3.DataBindings.Add("Text", list, "LanThi");
            textBox4.DataBindings.Add("Text", list, "Diem");
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string cnStr = "Server=DESKTOP-L99J7R8\\SQLEXPRESS;Database = QLHocVien;Integrated security=true";
            SqlConnection cn = new SqlConnection(cnStr);

            string MaHV, MaMonHoc, LanThi, Diem;
            MaHV = textBox1.Text;
            MaMonHoc = textBox2.Text;
            LanThi = textBox3.Text;
            Diem = textBox4.Text;
            

            //Kiem tra 3 thong tin 

            if (string.IsNullOrEmpty(MaHV))
                return;
            string sql = "INSERT INTO KETQUA VALUES('" + MaHV + "',N'" + MaMonHoc + "',N'" + LanThi + "',N'" + Diem + "')";
            SqlCommand cmd = new SqlCommand(sql, cn);

            cn.Open();
            int numberOfRows = cmd.ExecuteNonQuery();
            if (numberOfRows <= 0)
            {
                MessageBox.Show("Them that bai ", "Them sinh vien ");
            }
            else
                MessageBox.Show("Them thanh cong ", "Them sinh vien ");
            dataGridView1.DataSource = getDiemSinhVien();
            cn.Close();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string cnStr = "Server=DESKTOP-L99J7R8\\SQLEXPRESS;Database = QLHocVien;Integrated security=true";
            SqlConnection cn = new SqlConnection(cnStr);

            string MaHV, MaMonHoc, LanThi, Diem;
            MaHV = textBox1.Text;
            MaMonHoc = textBox2.Text;
            LanThi = textBox3.Text;
            Diem = textBox4.Text;


            //Kiem tra 3 thong tin 

            if (string.IsNullOrEmpty(MaHV))
                return;
            string sql = "DELETE FROM KETQUA WHERE MaHV='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int numberOfRows = cmd.ExecuteNonQuery();
            if (numberOfRows >= 0)
            {
                MessageBox.Show("Xoa thanh cong ");
            }
            else
                MessageBox.Show("Xoa that bai ");
            dataGridView1.DataSource = getDiemSinhVien();
            cn.Close();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string cnStr = "Server=DESKTOP-L99J7R8\\SQLEXPRESS;Database = QLHocVien;Integrated security=true";
            SqlConnection cn = new SqlConnection(cnStr);

            string MaHV, MaMonHoc, LanThi, Diem;
            MaHV = textBox1.Text;
            MaMonHoc = textBox2.Text;
            LanThi = textBox3.Text;
            Diem = textBox4.Text;


            //Kiem tra 3 thong tin 

            if (string.IsNullOrEmpty(MaHV))
                return;
            string sql = "UPDATE KETQUA SET MaMonHoc='" + textBox2.Text + "',LanThi='" + textBox3.Text + "',Diem='" + textBox4.Text  + "'WHERE MaHV='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, cn);

            cn.Open();
            int numberOfRows = cmd.ExecuteNonQuery();
            if (numberOfRows <= 0)
            {
                MessageBox.Show("Sua that bai ", "Sua sinh vien ");
            }
            else
                MessageBox.Show("Sua thanh cong ", "Sua sinh vien ");
            dataGridView1.DataSource = getDiemSinhVien();
            cn.Close();
        }
    }
}
