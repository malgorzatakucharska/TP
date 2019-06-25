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
        private static dcontext context = new dcontext();
         
        public static List<Customer> SelectAllCustomers()
        {
            List<Customer> allCustomers =
                 (from customers in context.Customer
                  select customers).ToList(); 

            return allCustomers;
        }
        public static void AddCustomer(Customer customer)
        {

            context.Customer.InsertOnSubmit(customer);
            SaveChanges();
        }

        public static void DeleteCustomer(int customerID)
        {

            var matchedCustomers =
                from customers in context.Customer
                where customers.Id == customerID
                select customers;

            foreach (Customer customer in matchedCustomers)
            {
                context.Customer.DeleteOnSubmit(customer);
            }

            SaveChanges();
        }

        public static void UpdateCustomer(Customer cust)
        {

            var matchedCustomers =
                from customers in context.Customer
                where customers.Id == cust.Id
                select customers;

            foreach (Customer customer in matchedCustomers)
            {
                customer.Name = cust.Name;
                customer.Surname = cust.Surname;
                customer.Age = cust.Age;
                customer.Email = cust.Email;
            }

            SaveChanges();
        }

        public static bool CheckIfIDIsUnique(int currentID)
        {
            bool isIDUnique = true;

            var matchedCustomer =
                from customers in context.Customer
                where customers.Id == currentID
                select customers;

            if (matchedCustomer.Any())
            {
                isIDUnique = false;
            }

            return isIDUnique;
        }

        public static void SaveChanges()
        {

            try
            {
                context.SubmitChanges();
            }
            catch (Exception e)
            {
            }

        }
    }
}
