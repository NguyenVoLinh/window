using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.Model
{
    public class HoaDonBEL
    {
        public int id { get; set; }
        public string ngaylap { get; set; }
        public string nhanvienlap { get; set; }
        public string tenkhachhang { get; set; }
        public int sodienthoai { get; set; }
        public int gia { get; set; }
        public int soluong { get; set; }
        public CustomerBEL customer { get; set; }
        public string CustomerName
        {
            get { return customer.Name; }
        }

    }
}
