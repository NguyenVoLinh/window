using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.Model
{
    public class CustomerBEL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public string Anh { get; set; }
        public AreaBEL Area { get; set; }
        public DanhMucBEL DM { get; set; }
        public string AreaName
        {
            get { return Area.Name; }
        }
        public string DanhMucName
        {
            get { return DM.name; }
        }

        public List<HoaDonBEL> hoadon { get; set; }
    }
}
