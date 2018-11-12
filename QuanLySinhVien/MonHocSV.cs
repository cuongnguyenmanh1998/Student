using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    public class MonHocSV
    {
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public string SoChi { get; set; }
        public MonHocSV(string MaMonHoc, string TenMonHoc, string SoChi)
        {
            this.MaMonHoc = MaMonHoc;
            this.TenMonHoc = TenMonHoc;
            this.SoChi = SoChi;
        }
    }
}
