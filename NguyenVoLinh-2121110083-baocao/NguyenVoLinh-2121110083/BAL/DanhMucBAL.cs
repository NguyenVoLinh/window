using NguyenVoLinh_2121110083.DAL;
using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.BAL
{
    public class DanhMucBAL
    {
        DanhMucDAL dal = new DanhMucDAL();
        public List<DanhMucBEL> ReadDanhmucList()
        {
            List<DanhMucBEL> lstDM = dal.ReadDanhmucList();
            return lstDM;
        }

        public void NewDanhmuc(DanhMucBEL cus)
        {
            dal.NewDanhmuc(cus);
        }
        public void DeleteDanhmuc(DanhMucBEL cus)
        {
            dal.DeleteDanhmuc(cus);
        }
        public void EditDanhmuc(DanhMucBEL cus)
        {
            dal.EditDanhmuc(cus);
        }

        public DanhMucBEL GetDanhmucId(int danhmucId)
        {
            List<DanhMucBEL> danhmuc = ReadDanhmucList();
            return danhmuc.FirstOrDefault(c => c.id == danhmucId);
        }

    }
}
