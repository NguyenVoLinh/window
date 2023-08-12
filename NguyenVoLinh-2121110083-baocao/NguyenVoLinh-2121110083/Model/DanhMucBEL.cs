using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.Model
{
    public class DanhMucBEL
    {
        public int id { get; set; }
        public string name { get; set; }
        public string diachi { get; set; }
        public int sodienthoai { get; set; }
        public List<CustomerBEL> Customers { get; set; }
    }
}
