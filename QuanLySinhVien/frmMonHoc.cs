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
    public partial class frmMonHoc : Form
    {
        public frmMonHoc()
        {
            InitializeComponent();
        }
        private List<MonHocSV> getMonHocSinhVien()
        {
            string cnStr = "Server=DESKTOP-L99J7R8\\SQLEXPRESS;Database = QLHocVien;Integrated security=true";
            SqlConnection cn = new SqlConnection(cnStr);
            string sql = "SELECT *FROM MONHOC";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<MonHocSV> list = new List<MonHocSV>();
            string MaMonHoc, TenMonHoc, SoChi;
            while (dr.Read())
            {
                MaMonHoc = dr[0].ToString();
                TenMonHoc = dr[1].ToString();
                SoChi = dr[2].ToString();
                MonHocSV sv = new MonHocSV(MaMonHoc, TenMonHoc, SoChi);
                list.Add(sv);
            }
            dr.Close();
            cn.Close();

            return list;
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            List<MonHocSV> list = getMonHocSinhVien();
            dataGridView1.DataSource = list;
            textBox1.DataBindings.Add("Text", list, "MaMonHoc");
            textBox2.DataBindings.Add("Text", list, "TenMonHoc");
            textBox3.DataBindings.Add("Text", list, "SoChi");
        }
    }
}
