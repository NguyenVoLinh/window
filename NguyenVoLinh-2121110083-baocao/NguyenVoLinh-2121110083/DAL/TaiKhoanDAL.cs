using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.DAL
{
    public class TaiKhoanDAL : DBConnection
    {
        public List<TaiKhoanBEL> ReadTaiKhoan()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from taikhoan", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<TaiKhoanBEL> lstCus = new List<TaiKhoanBEL>();
            while (reader.Read())
            {
                TaiKhoanBEL cus = new TaiKhoanBEL();
                cus.id = reader["id"].ToString();
                cus.tentaikhoan = reader["tentaikhoan"].ToString();
                cus.matkhau = reader["matkhau"].ToString();
                lstCus.Add(cus);
            }
            conn.Close();

            return lstCus;
        }
    }
}
