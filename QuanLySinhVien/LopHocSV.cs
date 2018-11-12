using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    public class LopHocSV
    {
        public string MaGV { get; set; }
        public string MaMH { get; set; }
        public string MaLop { get; set; }
        public LopHocSV(string MaGV, string MaMH, string MaLop)
        {
            this.MaGV = MaGV;
            this.MaMH = MaMH;
            this.MaLop = MaLop;
        }
    }
}
