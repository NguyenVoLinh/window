using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.DAL
{
    public class CustomerDAL : DBConnection
    {
        public List<CustomerBEL> ReadCustomerList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Customer", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CustomerBEL> lstCus = new List<CustomerBEL>();
            NhaCungCapDAL are = new NhaCungCapDAL();
            DanhMucDAL danhmuc = new DanhMucDAL();

            while (reader.Read())
            {
                CustomerBEL cus = new CustomerBEL();
                cus.Id = int.Parse(reader["id"].ToString());
                cus.Name = reader["name"].ToString();
                cus.SoLuong = int.Parse(reader["soluong"].ToString());
                cus.Gia = int.Parse(reader["gia"].ToString());
                cus.Anh = reader["anh"].ToString();
                cus.Area = are.ReadArea(int.Parse(reader["id_area"].ToString()));
                cus.DM = danhmuc.ReadDanhmuc(int.Parse(reader["id_DM"].ToString()));
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }
        public CustomerBEL ReadCustomer(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from customer where id=" + id.ToString(), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            CustomerBEL customer = new CustomerBEL();
            NhaCungCapDAL are = new NhaCungCapDAL();
            DanhMucDAL danhmuc = new DanhMucDAL();
            if (reader.HasRows && reader.Read())
            {
                customer.Id = int.Parse(reader["id"].ToString());
                customer.Name = reader["name"].ToString();
                customer.SoLuong = int.Parse(reader["soluong"].ToString());
                customer.Gia = int.Parse(reader["gia"].ToString());
                customer.Anh = reader["anh"].ToString();
                customer.Area = are.ReadArea(int.Parse(reader["id_area"].ToString()));
                customer.DM = danhmuc.ReadDanhmuc(int.Parse(reader["id_DM"].ToString()));
            }
            conn.Close();
            return customer;
        }

        public void EditCustomer(CustomerBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Customer set name =@name,soluong=@soluong,gia=@gia,  anh=@anh, id_area = @id_area,id_DM= @id_DM where id = @id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.Parameters.Add(new SqlParameter("@name", cus.Name));
            cmd.Parameters.Add(new SqlParameter("@soluong", cus.SoLuong));
            cmd.Parameters.Add(new SqlParameter("@gia", cus.Gia));
            cmd.Parameters.Add(new SqlParameter("@anh", cus.Anh));
            cmd.Parameters.Add(new SqlParameter("@id_area", cus.Area.Id));
            cmd.Parameters.Add(new SqlParameter("@id_DM", cus.DM.id));
            
                
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteCustomer(CustomerBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Customer where id = @id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewCustomer(CustomerBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Customer values(@id, @name, @soluong, @gia, @anh, @id_area, @id_DM)", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.Parameters.Add(new SqlParameter("@name", cus.Name));
            cmd.Parameters.Add(new SqlParameter("@soluong", cus.SoLuong));
            cmd.Parameters.Add(new SqlParameter("@gia", cus.Gia));
            cmd.Parameters.Add(new SqlParameter("@anh", cus.Anh));
            cmd.Parameters.Add(new SqlParameter("@id_area", cus.Area.Id));
            cmd.Parameters.Add(new SqlParameter("@id_DM", cus.DM.id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
