using NguyenVoLinh_2121110083.DAL;
using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.BAL
{
    public class HoaDonBAL
    {
        HoaDonDAL dal = new HoaDonDAL();
        public List<HoaDonBEL> ReadHoadon()
        {
            List<HoaDonBEL> lstCus = dal.ReadHoadon();
            return lstCus;
        }
        public void NewHoadon(HoaDonBEL cus)
        {
            dal.NewHoadon(cus);
        }
        public void DeleteHoadon(HoaDonBEL cus)
        {
            dal.DeleteHoadon(cus);
        }
        public void EditHoadon(HoaDonBEL cus)
        {
            dal.EditHoadon(cus);
        }

        public HoaDonBEL GetHoadonById(int hoadonId)
        {
            List<HoaDonBEL> hoadon = ReadHoadon();
            return hoadon.FirstOrDefault(c => c.id == hoadonId);
        }


    }
}
