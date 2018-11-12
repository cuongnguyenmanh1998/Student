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
    public partial class frmLopHoc : Form
    {
        public frmLopHoc()
        {
            InitializeComponent();
        }
        private List<LopHocSV> getLopHocSinhVien()
        {
            string cnStr = "Server=DESKTOP-L99J7R8\\SQLEXPRESS;Database = QLHocVien;Integrated security=true";
            SqlConnection cn = new SqlConnection(cnStr);
            string sql = "SELECT *FROM LOPHOC";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<LopHocSV> list = new List<LopHocSV>();
            string MaGV, MaMH, MaLop;
            while (dr.Read())
            {
                MaGV = dr[0].ToString();
                MaMH = dr[1].ToString();
                MaLop = dr[2].ToString();
                LopHocSV sv = new LopHocSV(MaGV, MaMH,MaLop);
                list.Add(sv);
            }
            dr.Close();
            cn.Close();

            return list;
        }

        private void frmLopHoc_Load(object sender, EventArgs e)
        {
            List<LopHocSV> list = getLopHocSinhVien();
            dataGridView1.DataSource = list;
            textBox1.DataBindings.Add("Text", list, "MaGV");
            textBox2.DataBindings.Add("Text", list, "MaMH");
            textBox3.DataBindings.Add("Text", list, "MaLop");
        }
    }
}
