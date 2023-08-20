using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.DAL
{
    public class nhanvienDAL : DBConnection
    {
        public List<nhanvienBEL> ReadNhanvienList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from nhanvien", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<nhanvienBEL> lstNCC = new List<nhanvienBEL>();
            while (reader.Read())
            {
                nhanvienBEL nhanvien = new nhanvienBEL();
                nhanvien.manhanvien = int.Parse(reader["manhanvien"].ToString());
                nhanvien.tennhanvien = reader["tennhanvien"].ToString();
                nhanvien.gioitinh = reader["gioitinh"].ToString();
                nhanvien.diachi = reader["diachi"].ToString();
                nhanvien.sodienthoai = int.Parse(reader["sodienthoai"].ToString());
                nhanvien.ngaysinh = DateTime.Parse(reader["ngaysinh"].ToString());
                lstNCC.Add(nhanvien);
            }
            conn.Close();
            return lstNCC;
        }
        public nhanvienBEL ReadNhanvien(int manhanvien)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from nhanvien where manhanvien=" + manhanvien.ToString(), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            nhanvienBEL nhanvien = new nhanvienBEL();
            if (reader.HasRows && reader.Read())
            {
                nhanvien.manhanvien = int.Parse(reader["manhanvien"].ToString());
                nhanvien.tennhanvien = reader["tennhanvien"].ToString();
                nhanvien.gioitinh = reader["gioitinh"].ToString();
                nhanvien.diachi = reader["diachi"].ToString();
                nhanvien.sodienthoai = int.Parse(reader["sodienthoai"].ToString());
                nhanvien.ngaysinh = DateTime.Parse(reader["ngaysinh"].ToString());
            }
            conn.Close();
            return nhanvien;
        }
        //    public void EditKhachhang(nhanvienBEL cus)
        //    {
        //        SqlConnection conn = CreateConnection();
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("update khachhang set tenkhach =@tenkhach, diachi = @diachi, sodienthoai=@sodienthoai where makhach = @makhach", conn);
        //        cmd.Parameters.Add(new SqlParameter("@makhach", cus.makhach));
        //        cmd.Parameters.Add(new SqlParameter("@tenkhach", cus.tenkhach));
        //        cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.sodienthoai));
        //        cmd.Parameters.Add(new SqlParameter("@diachi", cus.diachi));
        //        cmd.ExecuteNonQuery();
        //        conn.Close();
        //    }
        //    public void DeleteKhachhang(nhanvienBEL cus)
        //    {
        //        SqlConnection conn = CreateConnection();
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("delete from khachhang where makhach = @makhach", conn);
        //        cmd.Parameters.Add(new SqlParameter("@id", cus.makhach));
        //        cmd.ExecuteNonQuery();
        //        conn.Close();
        //    }
        //    public void NewKhachhang(nhanvienBEL cus)
        //    {
        //        SqlConnection conn = CreateConnection();
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("insert into khachhang values(@makhach, @tenkhach, @diachi, @sodienthoai)", conn);
        //        cmd.Parameters.Add(new SqlParameter("@makhach", cus.makhach));
        //        cmd.Parameters.Add(new SqlParameter("@tenkhach", cus.tenkhach));
        //        cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.sodienthoai));
        //        cmd.Parameters.Add(new SqlParameter("@diachi", cus.diachi));
        //        cmd.ExecuteNonQuery();
        //        conn.Close();

        //    }
        //}
    }
}
