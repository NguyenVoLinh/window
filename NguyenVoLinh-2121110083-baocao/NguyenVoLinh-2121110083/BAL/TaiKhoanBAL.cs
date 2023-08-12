using NguyenVoLinh_2121110083.DAL;
using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.BAL
{
    public class TaiKhoanBAL
    {
        TaiKhoanDAL dal = new TaiKhoanDAL();
        public List<TaiKhoanBEL> ReadTaiKhoan()
        {
            List<TaiKhoanBEL> lstCus = dal.ReadTaiKhoan();
            return lstCus;
        }
    }
}
