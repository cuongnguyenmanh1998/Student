using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    public class DiemSV
    {
        public string MaHV { get; set; }
        public string MaMonHoc { get; set; }
        public string LanThi { get; set; }
        public string Diem { get; set; }
        public DiemSV(string MaHV, string MaMonHoc, string LanThi, string Diem)
        {
            this.MaHV = MaHV;
            this.MaMonHoc = MaMonHoc;
            this.LanThi = LanThi;
            this.Diem = Diem;
        }
    }
}
