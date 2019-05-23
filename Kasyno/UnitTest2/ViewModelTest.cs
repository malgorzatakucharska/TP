using ServiceLayer;
using DataRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using GUI.ViewModel;

namespace UnitTest2
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>

    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void TestInitialization()
        {
            Customer cust1 = new Customer()
            {
                Id = 1000,
                Name = "Jan",
                Surname = "Kowalski",
                Age = 30,
                Email = "jkowalski@gmail.com",
                Phone = "600100200",
            };

            Customer cust2 = new Customer()
            {
                Id = 2000,
                Name = "Mateusz",
                Surname = "Nowak",
                Age = 45,
                Email = "mn@gmail.com",
                Phone = "600100200",
            };

            Customer cust3 = new Customer()
            {
                Id = 3000,
                Name = "Ilona",
                Surname = "Grabarczyk",
                Age = 34,
                Email = "ig@gmail.com",
                Phone = "600100200",
            };
            DataRepository.DataRepository.AddCustomer(cust1);
            DataRepository.DataRepository.AddCustomer(cust2);
            DataRepository.DataRepository.AddCustomer(cust3);
        }
        [TestMethod]
        public void AddCustomerCommandTest()
        {
            CustomerViewModel vm = new CustomerViewModel();
            Assert.IsTrue(vm.AddCustomerCommand.CanExecute(null));
        }

        [TestMethod]
        public void DeleteCustomerCommandTest()
        {
            CustomerViewModel vm = new CustomerViewModel();
            Assert.IsTrue(vm.DeleteCustomerCommand.CanExecute(null));
        }

        [TestMethod]
        public void UpdateCustomerCommandTest()
        {
            CustomerViewModel vm = new CustomerViewModel();
            Assert.IsTrue(vm.AddCustomerCommand.CanExecute(null));
        }

        [TestMethod]
        public void FetchCustomerCommandTest()
        {
            CustomerViewModel vm = new CustomerViewModel();
            Assert.IsTrue(vm.AddCustomerCommand.CanExecute(null));
        }
    
    }
}
