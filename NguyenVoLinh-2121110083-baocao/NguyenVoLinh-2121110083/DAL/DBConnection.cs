using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.DAL
{
    public class DBConnection
    {
        public DBConnection() { }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=.;Initial Catalog=QLBHtest1;User Id=sa; Password=sa";
            return conn;
        }
        public string GetFieldValues(string sql)
        {
            string result = null;
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        object queryResult = command.ExecuteScalar();
                        if (queryResult != null)
                        {
                            result = queryResult.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return result;
        }
    }
}
