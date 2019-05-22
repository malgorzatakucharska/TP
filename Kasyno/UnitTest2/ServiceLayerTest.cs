using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest2
{
    [TestClass]
    public class ServiceLayerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int oldCustomersNumber = DataRepository.DataRepository.SelectAllCustomer().Count;

            Customer cust = new Customer()
            {
                Id = 1000,
                Name = "Jan",
                Surname = "Kowalski",
                Age = 30,
                Email = "jkowalski@gmail.com",
                Phone = "600100200",
            };

            DataRepository.DataRepository.AddCustomer(cust);
            int newCustomersNumber = DataRepository.DataRepository.SelectAllCustomer().Count;

            //check if number of records is greater than 0
            Assert.IsTrue(oldCustomersNumber < newCustomersNumber);
        }
    }
}
