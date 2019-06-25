using System;
using Kasyno.MainLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TestyWydajnosci
    {
        DataContext data;
        DataFiller filler;
        DataRepository dataRepository;

        [TestInitialize]
        public void InitializeTests()
        {
            data = new DataContext();
            filler = new WypelnianieStalymiDoTestowWyd();
            dataRepository = new DataRepository(filler, data);
            dataRepository.inicjalizuj();
        }

          [TestMethod]
        public void Wypelnianie10()
        {
            int n = 10;
            while (n-- != 0)
            {
                dataRepository.inicjalizuj();
            }
        }
        [TestMethod]
        public void Wypelnianie100()
        {
            int n = 100;
            while (n-- != 0)
            {
                dataRepository.inicjalizuj();
            }
        }

        [TestMethod]
        public void Wypelnianie1000()
        {
            int n = 1000;
            while (n-- != 0)
            {
                dataRepository.inicjalizuj();
            }
        }

        [TestMethod]
        public void Wypelnianie100000()
        {
            int n = 100000;
            while (n-- != 0)
            {
                dataRepository.inicjalizuj();
            }
        }

        [TestMethod]
        public void Wypelnianie1000000()
        {
            int n = 1000000;
            while (n-- != 0)
            {
                dataRepository.inicjalizuj();
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
