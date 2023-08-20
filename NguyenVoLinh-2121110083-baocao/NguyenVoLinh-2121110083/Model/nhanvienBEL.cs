using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.Model
{
    public class nhanvienBEL
    {
        public int manhanvien { get; set; }
        public string tennhanvien { get; set; }
        public string gioitinh { get; set; }
        public string diachi { get; set; }
        public int sodienthoai { get; set; }
        public DateTime ngaysinh { get; set; }
        public List<HoaDonBEL> hoadon { get; set; }
    }
}
