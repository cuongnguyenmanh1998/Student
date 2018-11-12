using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    public class SinhVien
    {
        public string MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public string NgaySinh { get; set; }
        public string TinhTrang { get; set; }
        public string Lop { get; set; }
        public SinhVien(string MaHocVien, string TenHocVien, string NgaySinh, string TinhTrang,string Lop)
        {
            this.MaHocVien = MaHocVien;
            this.TenHocVien = TenHocVien;
            this.NgaySinh = NgaySinh;
            this.TinhTrang = TinhTrang;
            this.Lop = Lop;
        }
    }
}
