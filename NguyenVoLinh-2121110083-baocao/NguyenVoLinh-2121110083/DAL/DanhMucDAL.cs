using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.DAL
{
    public class DanhMucDAL : DBConnection
    {
        public List<DanhMucBEL> ReadDanhmucList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from danhmuc", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<DanhMucBEL> lstNCC = new List<DanhMucBEL>();
            while (reader.Read())
            {
                DanhMucBEL danhmuc = new DanhMucBEL();
                danhmuc.id = int.Parse(reader["id"].ToString());
                danhmuc.name = reader["name"].ToString();
                danhmuc.diachi = reader["diachi"].ToString();
                danhmuc.sodienthoai = int.Parse(reader["sodienthoai"].ToString());
                lstNCC.Add(danhmuc);
            }
            conn.Close();
            return lstNCC;
        }
        public DanhMucBEL ReadDanhmuc(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from danhmuc where id=" + id.ToString(), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DanhMucBEL danhmuc = new DanhMucBEL();
            if (reader.HasRows && reader.Read())
            {
                danhmuc.id = int.Parse(reader["id"].ToString());
                danhmuc.name = reader["name"].ToString();
                danhmuc.diachi = reader["diachi"].ToString();
                danhmuc.sodienthoai = int.Parse(reader["sodienthoai"].ToString());
            }
            conn.Close();
            return danhmuc;
        }
        public void EditDanhmuc(DanhMucBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update danhmuc set name =@name, diachi = @diachi, sodienthoai=@sodienthoai where id = @id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.id));
            cmd.Parameters.Add(new SqlParameter("@name", cus.name));
            cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.sodienthoai));
            cmd.Parameters.Add(new SqlParameter("@diachi", cus.diachi));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteDanhmuc(DanhMucBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from danhmuc where id = @id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewDanhmuc(DanhMucBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into danhmuc values(@id, @name, @diachi, @sodienthoai)", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.id));
            cmd.Parameters.Add(new SqlParameter("@name", cus.name));
            cmd.Parameters.Add(new SqlParameter("@diachi", cus.diachi));
            cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.sodienthoai));
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
