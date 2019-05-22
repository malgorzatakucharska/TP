using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;

namespace DataRepository
{
    public class DataRepository
    {
        private static CustomersDataContext context = new CustomersDataContext();

        public static List<Customer> SelectAllCustomer()
        {
            List<Customer> allCustomers =
                 (from customers in context.customers
                  select customers).ToList();

            return allCustomers;
        }
    }
}
