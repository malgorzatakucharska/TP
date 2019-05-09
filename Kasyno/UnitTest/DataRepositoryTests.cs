using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kasyno.Data;
using Kasyno.MainLogic;

namespace UnitTest
{
    [TestClass]
    class DataRepositoryTests
    {
        DataContext data;
        DataFiller filler;
        DataRepository dataRepository;

        [TestInitialize]
        public void InitializeTests()
        {
            data = new DataContext();
            dataRepository = new DataRepository(filler, data);
        }

        //test dla metody add

        [TestMethod]
        public void AddKlientTest()
        {
            int rozmiarstary = data.klienci.Count;

            Klient customer = new Klient()
            {
                imie = "Jak",
                nazwisko = "Nowak",
                wiek = 40,
                adresEmail = "jannowak@gmail.com"
            };

            dataRepository.AddKlient(customer);
            int rozmiarnowy = data.klienci.Count;

            // sprawdza rozmiar starej i nowej listy
            Assert.AreNotEqual(rozmiarstary, rozmiarnowy);

            //sprawdzenie czy lista zawiera dodany element
            Assert.IsTrue(data.klienci.Contains(customer));
        }
        [TestMethod]
        public void AddGraTest()
        {
            int rozmiarstary = data.gry.Count;

            Gra gra = new Gra()
            {
                id = 0021,
                nazwa = "Ruletka",
            };

            dataRepository.AddGra(gra);
            int rozmiarnowy = data.gry.Count;

            // sprawdza rozmiar starego i nowego slownika
            Assert.AreNotEqual(rozmiarstary, rozmiarnowy);

            //sprawdzenie czy slownik zawiera dodany element
            Assert.IsTrue(data.gry.ContainsKey(0021));
            Assert.IsTrue(data.gry.ContainsValue(gra));
        }

        [TestMethod]
        public void AddUdzialWGrzeTest()
        {
            int rozmiarstary = data.udzialywgrze.Count;

            Gra gra = new Gra()
            {
                id = 0021,
                nazwa = "Ruletka",
            };

            StanGry stan = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2019, 15, 04))
            };

            Klient klient = new Klient()
            {
                imie = "Jak",
                nazwisko = "Nowak",
                wiek = 40,
                adresEmail = "jannowak@gmail.com"
            };

            UdzialWGrze udzial = new UdzialWGrze()
            {
                stangry = stan,
                klient = klient
            };

            dataRepository.AddUdziałWGrze(udzial);
            int rozmiarnowy = data.udzialywgrze.Count;

            // sprawdza rozmiar starej i nowej kolekcji
            Assert.AreNotEqual(rozmiarstary, rozmiarnowy);

            //sprawdzenie czy kolekcja zawiera dodany element
            Assert.IsTrue(data.udzialywgrze.Contains(udzial));
        }

        [TestMethod]
        public void AddStanGryTest()
        {
            int rozmiarstarejlisty = data.gry.Count;

            Gra gra = new Gra()
            {
                id = 0021,
                nazwa = "Ruletka",
            };

            StanGry stan = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2019, 15, 04))
            };

            dataRepository.AddStanGry(stan);
            int rozmiarnowejlisty = data.stanygier.Count;

            // sprawdza rozmiar starej i nowej kolekcji
            Assert.AreNotEqual(rozmiarstarejlisty, rozmiarnowejlisty);

            //sprawdzenie czy kolekcja zawiera dodany element
            Assert.IsTrue(data.stanygier.Contains(stan));
        }
    }
}
