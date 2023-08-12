using NguyenVoLinh_2121110083.DAL;
using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.BAL
{
    public class CustomerBAL
    {
        CustomerDAL dal = new CustomerDAL();
        public List<CustomerBEL> ReadCustomerList()
        {
            List<CustomerBEL> lstCus = dal.ReadCustomerList();
            return lstCus;
        }
        public void NewCustomer(CustomerBEL cus)
        {
            dal.NewCustomer(cus);
        }
        public void DeleteCustomer(CustomerBEL cus)
        {
            dal.DeleteCustomer(cus);
        }
        public void EditCustomer(CustomerBEL cus)
        {
            dal.EditCustomer(cus);
        }

        public CustomerBEL GetCustomerById(int customerId)
        {
            List<CustomerBEL> customers = ReadCustomerList();
            return customers.FirstOrDefault(c => c.Id == customerId);
        }
    }
}
