using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.DAL
{
    public class KhachHangDAL : DBConnection
    {
        public List<KhachHangBEL> ReadKhachhangList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from khachhang", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<KhachHangBEL> lstNCC = new List<KhachHangBEL>();
            while (reader.Read())
            {
                KhachHangBEL khachhang = new KhachHangBEL();
                khachhang.makhach = int.Parse(reader["makhach"].ToString());
                khachhang.tenkhach = reader["tenkhach"].ToString();
                khachhang.diachi = reader["diachi"].ToString();
                khachhang.sodienthoai = int.Parse(reader["sodienthoai"].ToString());
                lstNCC.Add(khachhang);
            }
            conn.Close();
            return lstNCC;
        }
        public KhachHangBEL ReadKhachhang(int makhach)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from khachhang where makhach=" + makhach.ToString(), conn);

            SqlDataReader reader = cmd.ExecuteReader();
            KhachHangBEL khachhang = new KhachHangBEL();
            if (reader.HasRows && reader.Read())
            {
                khachhang.makhach = int.Parse(reader["makhach"].ToString());
                khachhang.tenkhach = reader["tenkhach"].ToString();
                khachhang.diachi = reader["diachi"].ToString();
                khachhang.sodienthoai = int.Parse(reader["sodienthoai"].ToString());
            }
            conn.Close();
            return khachhang;
        }

        //public List<KhachHangBEL> ReadKhachhangList(KhachHangBEL c)
        //{
        //    SqlConnection conn = CreateConnection();
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("select*from khachhang where makhach=@makhach", conn);
        //    cmd.Parameters.Add(new SqlParameter("@makhach", c.makhach));
        //    SqlDataReader reader = cmd.ExecuteReader();


        //    List<KhachHangBEL> lstNCC = new List<KhachHangBEL>();
        //    while (reader.Read())
        //    {
        //        KhachHangBEL khachhang = new KhachHangBEL();
        //        khachhang.makhach = reader["makhach"].ToString();
        //        khachhang.tenkhach = reader["tenkhach"].ToString();
        //        khachhang.diachi = reader["diachi"].ToString();
        //        khachhang.sodienthoai = int.Parse(reader["sodienthoai"].ToString());
        //        lstNCC.Add(khachhang);
        //    }
        //    conn.Close();
        //    return lstNCC;
        //}

        public void EditKhachhang(KhachHangBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update khachhang set tenkhach =@tenkhach, diachi = @diachi, sodienthoai=@sodienthoai where makhach = @makhach", conn);
            cmd.Parameters.Add(new SqlParameter("@makhach", cus.makhach));
            cmd.Parameters.Add(new SqlParameter("@tenkhach", cus.tenkhach));
            cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.sodienthoai));
            cmd.Parameters.Add(new SqlParameter("@diachi", cus.diachi));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteKhachhang(KhachHangBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from khachhang where makhach = @makhach", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.makhach));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewKhachhang(KhachHangBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into khachhang values(@makhach, @tenkhach, @diachi, @sodienthoai)", conn);
            cmd.Parameters.Add(new SqlParameter("@makhach", cus.makhach));
            cmd.Parameters.Add(new SqlParameter("@tenkhach", cus.tenkhach));
            cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.sodienthoai));
            cmd.Parameters.Add(new SqlParameter("@diachi", cus.diachi));
            cmd.ExecuteNonQuery();
            conn.Close();

        }




    }
}
