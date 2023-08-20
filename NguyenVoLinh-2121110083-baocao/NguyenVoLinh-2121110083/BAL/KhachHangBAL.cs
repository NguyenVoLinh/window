using NguyenVoLinh_2121110083.DAL;
using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.BAL
{
    public class KhachHangBAL
    {
        KhachHangDAL dal = new KhachHangDAL();
        public List<KhachHangBEL> ReadKhachhangList()
        {
            List<KhachHangBEL> lstDM = dal.ReadKhachhangList();
            return lstDM;
        }

        public void NewKhachhang(KhachHangBEL cus)
        {
            dal.NewKhachhang(cus);
        }
        public void DeleteKhachhang(KhachHangBEL cus)
        {
            dal.DeleteKhachhang(cus);
        }
        public void EditKhachhang(KhachHangBEL cus)
        {
            dal.EditKhachhang(cus);
        }

        public KhachHangBEL GetKhachHangId(int khachhangId)
        {
            List<KhachHangBEL> khachhang = ReadKhachhangList();
            return khachhang.FirstOrDefault(c => c.makhach == khachhangId);
        }
        //public KhachHangBEL GetKhachHangById(string maKhach)
        //{
        //    // Implement the logic to query the database or data source to get the desired object
        //    // Return the KhachHangBEL object if found, otherwise return null

        //    // Example logic to retrieve KhachHangBEL based on maKhach
        //    KhachHangBEL khachHang = null; // Initialize with null

        //    // Your logic to retrieve the KhachHangBEL object
        //    // If found, assign the object to the 'khachHang' variable

        //    return khachHang; // Return the retrieved KhachHangBEL object or null if not found
        //}
        //public List<KhachHangBEL> Timkiem(KhachHangBEL c)
        //{
        //    List<KhachHangBEL> lstCus = dal.ReadKhachhangList(c);
        //    return lstCus;
        //}


    }
}

