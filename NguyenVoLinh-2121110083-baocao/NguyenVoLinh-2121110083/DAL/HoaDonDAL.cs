using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.DAL
{
    public class HoaDonDAL : DBConnection
    {
        public List<HoaDonBEL> ReadHoadon()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from hoadon", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<HoaDonBEL> lstHd = new List<HoaDonBEL>();
            CustomerDAL sp = new CustomerDAL();
            KhachHangDAL kh1 = new KhachHangDAL();
            nhanvienDAL nv1 = new nhanvienDAL();

            while (reader.Read())
            {
                HoaDonBEL cus = new HoaDonBEL();
                cus.id = int.Parse(reader["id"].ToString());
                cus.ngaylap = reader["ngaylap"].ToString();
                //cus.nhanvienlap = reader["nhanvienlap"].ToString();
                //cus.tenkhachhang = reader["tenkhachhang"].ToString();
                cus.sodienthoai = int.Parse(reader["sodienthoai"].ToString());
                cus.customer = sp.ReadCustomer(int.Parse(reader["id_customer"].ToString()));
                cus.nv = nv1.ReadNhanvien(int.Parse(reader["ma_nv"].ToString()));
                cus.kh = kh1.ReadKhachhang(int.Parse(reader["ma_kh"].ToString()));
                cus.gia = int.Parse(reader["gia"].ToString());
                cus.soluong = int.Parse(reader["soluong"].ToString());

                cus.tongtien = float.Parse(reader["tongtien"].ToString());
                lstHd.Add(cus);
            }
            conn.Close();
            return lstHd;
        }
        public void EditHoadon(HoaDonBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update hoadon set ngaylap =@ngaylap, nhanvienlap = @nhanvienlap,tenkhachhang=@tenkhachhang,sodienthoai=@sodienthoai,gia=@gia, id_customer=@id_customer,soluong=@soluong where id = @id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.id));
            cmd.Parameters.Add(new SqlParameter("@ngaylap", cus.ngaylap));
            //cmd.Parameters.Add(new SqlParameter("@nhanvienlap", cus.nhanvienlap));
            //cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cus.tenkhachhang));
            cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.sodienthoai));
            cmd.Parameters.Add(new SqlParameter("@id_customer", cus.customer.Id));
            cmd.Parameters.Add(new SqlParameter("@gia", cus.gia));
            cmd.Parameters.Add(new SqlParameter("@soluong", cus.soluong));

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteHoadon(HoaDonBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from hoadon where id = @id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewHoadon(HoaDonBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into hoadon values(@id, @ngaylap, @sodienthoai,@id_customer,@ma_nv,@ma_kh,@gia,@soluong,@tongtien)", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.id));
            cmd.Parameters.Add(new SqlParameter("@ngaylap", cus.ngaylap));
            cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.sodienthoai));
            cmd.Parameters.Add(new SqlParameter("@id_customer", cus.customer.Id));
            cmd.Parameters.Add(new SqlParameter("@ma_nv", cus.nv.manhanvien));
            cmd.Parameters.Add(new SqlParameter("@ma_kh", cus.kh.makhach));
            cmd.Parameters.Add(new SqlParameter("@gia", cus.gia));
            cmd.Parameters.Add(new SqlParameter("@soluong", cus.soluong));
            cmd.Parameters.Add(new SqlParameter("@tongtien", cus.tongtien));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
