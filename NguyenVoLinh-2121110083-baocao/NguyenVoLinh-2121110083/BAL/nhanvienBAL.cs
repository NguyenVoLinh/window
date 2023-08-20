using NguyenVoLinh_2121110083.DAL;
using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.BAL
{
    public class nhanvienBAL
    {
        nhanvienDAL dal = new nhanvienDAL();
        public List<nhanvienBEL> ReadNhanvienList()
        {
            List<nhanvienBEL> lstDM = dal.ReadNhanvienList();
            return lstDM;
        }
        //public nhanvienBEL GetNhanVienById(string maKhach)
        //{
        //    // Implement the logic to query the database or data source to get the desired object
        //    // Return the KhachHangBEL object if found, otherwise return null

        //    // Example logic to retrieve KhachHangBEL based on maKhach
        //    nhanvienBEL nhanvien = null; // Initialize with null

        //    // Your logic to retrieve the KhachHangBEL object
        //    // If found, assign the object to the 'khachHang' variable

        //    return nhanvien; // Return the retrieved KhachHangBEL object or null if not found
        //}

    }
}
