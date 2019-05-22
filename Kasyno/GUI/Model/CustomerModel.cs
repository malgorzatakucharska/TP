using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;
using DataRepository;

namespace GUI.Model
{
    public class CustomerModel
    {
        public IEnumerable<Customer> Customer
        {
            get { return DataRepository.DataRepository.SelectAllCustomer(); }
        }
    }
}