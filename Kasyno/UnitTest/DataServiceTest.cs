using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kasyno.Data;
using Kasyno.MainLogic;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class DataServiceTest
    {
        DataService service;
        DataRepository dataRepository;
        DataContext data;
        DataFiller filler;

        [TestInitialize]
        public void InitializeTests()
        {
            data = new DataContext();
            filler = new WypelnianieStalymi();
            dataRepository = new DataRepository(filler, data);

            service = new DataService(dataRepository);
        }

        [TestMethod]
        public void AddKlientPositiveTest()
        {
            int staryrozmiar = data.klienci.Count;

            Klient klienci = new Klient()
            {
                imie = "Jan",
                nazwisko = "Nowak",
                wiek = 40,
                adresEmail = "jannowak@gmail.com"
            };

            service.AddKlient(klienci);
            int nowyrozmiar = data.klienci.Count;

            //check if size of new and old list is different
            Assert.AreNotEqual(staryrozmiar, nowyrozmiar);

        }
        [TestMethod]
        public void AddKlientPositiveTest2()
        {
            int staryrozmiar = data.klienci.Count;

            Klient klienci = new Klient()
            {
                imie = "Jan",
                nazwisko = "Nowak",
                wiek = 40,
                adresEmail = "jannowak@gmail.com"
            };

            service.AddKlient(klienci);
            int nowyrozmiar = data.klienci.Count;


            //check if list contains object
            Assert.IsTrue(data.klienci.Contains(klienci));
        }


        [TestMethod]
        public void AddGraPositiveTest()
        {
            int staryrozmiar = data.gry.Count;

            Gra gra = new Gra()
            {
                Id = 0021,
                nazwa = "Ruletka"
            };

            service.AddGra(gra);
            int newDictSize = data.gry.Count;

            //sprawdza czy rozmiar stary i nowy sa rozne
            Assert.AreNotEqual(staryrozmiar, newDictSize);

        }
        [TestMethod]
        public void AddGraPositiveTest2()
        {
            int staryrozmiar = data.gry.Count;

            Gra gra = new Gra()
            {
                Id = 0021,
                nazwa = "Ruletka"
            };

            service.AddGra(gra);
            int newDictSize = data.gry.Count;

            //sprawdza czy lista zawiera obiekt
            Assert.IsTrue(data.gry.ContainsValue(gra));
        }


        [TestMethod]
        public void AddUdzialWgrzePositiveTest()
        {
            int staryrozmiar = data.udzialywgrze.Count;

            StanGry stan = dataRepository.GetAllStanyGier().ElementAt(0);
            Klient klient = dataRepository.GetAllKlienci().ElementAt(1);

            service.AddUdzialWGrze(klient, stan);
            int nowyrozmiar = data.udzialywgrze.Count;

            //sprawdza czy rozmiar stary i nowy sa rozne
            Assert.AreNotEqual(staryrozmiar, nowyrozmiar);

        }

        [TestMethod]
        public void AddUdzialWGrzeNegativeTest()
        {
            int staryrozmiar = data.udzialywgrze.Count;

            StanGry stan = dataRepository.GetAllStanyGier().ElementAt(0);
            Klient klient = dataRepository.GetAllKlienci().ElementAt(0);

            service.AddUdzialWGrze(klient, stan);
            int newListSize = data.udzialywgrze.Count;

            //sprawdza czy rozmiar stary i nowy sa rozne
            Assert.AreEqual(staryrozmiar, newListSize);
        }


        [TestMethod]
        public void AddStanGryNegativeTest()
        {
            int staryrozmiar = data.stanygier.Count;

            Gra gra = new Gra()
            {
                Id = 0041,
                nazwa = "Ruletka"
            };

            service.AddCDState(gra);
            int nowyrozmiar = data.stanygier.Count;

            //sprawdza czy rozmiar stary i nowy sa rozne
            Assert.AreEqual(staryrozmiar, nowyrozmiar);

        }

        [TestMethod]
        public void UpdateKlientPositiveTestFirstName()
        {

            Klient zaktualizowanyklient = new Klient()
            {
                imie = "Maria",
                nazwisko = "Nowik",
                wiek = 38,
                adresEmail = "marianowik@gmail.com"
            };

            int licznikKlientow = data.klienci.Count;
            int randomIndex = new Random().Next(0, licznikKlientow - 1);

            service.UpdateKlient(randomIndex, zaktualizowanyklient);

            //check if properties are the same
            Assert.AreEqual(zaktualizowanyklient.imie, data.klienci[randomIndex].imie);
        }
        [TestMethod]
        public void UpdateKlientPositiveTestLastName()
        {

            Klient zaktualizowanyklient = new Klient()
            {
                imie = "Maria",
                nazwisko = "Nowik",
                wiek = 38,
                adresEmail = "marianowik@gmail.com"
            };

            int licznikKlientow = data.klienci.Count;
            int randomIndex = new Random().Next(0, licznikKlientow - 1);

            service.UpdateKlient(randomIndex, zaktualizowanyklient);

            //check if properties are the same
            Assert.AreEqual(zaktualizowanyklient.nazwisko, data.klienci[randomIndex].nazwisko);
        }
        [TestMethod]
        public void UpdateKlientPositiveTestAge()
        {

            Klient zaktualizowanyklient = new Klient()
            {
                imie = "Maria",
                nazwisko = "Nowik",
                wiek = 38,
                adresEmail = "marianowik@gmail.com"
            };

            int licznikKlientow = data.klienci.Count;
            int randomIndex = new Random().Next(0, licznikKlientow - 1);

            service.UpdateKlient(randomIndex, zaktualizowanyklient);

            //check if properties are the same
            Assert.AreEqual(zaktualizowanyklient.wiek, data.klienci[randomIndex].wiek);
        }
        [TestMethod]
        public void UpdateKlientPositiveTestEmail()
        {

            Klient zaktualizowanyklient = new Klient()
            {
                imie = "Maria",
                nazwisko = "Nowik",
                wiek = 38,
                adresEmail = "marianowik@gmail.com"
            };

            int licznikKlientow = data.klienci.Count;
            int randomIndex = new Random().Next(0, licznikKlientow - 1);

            service.UpdateKlient(randomIndex, zaktualizowanyklient);

            //check if properties are the same
            Assert.AreEqual(zaktualizowanyklient.adresEmail, data.klienci[randomIndex].adresEmail);
        }

        [TestMethod]
        public void UpdateUdzialWGrzePositiveTestState()
        {

            int staryrozmiar = data.udzialywgrze.Count;
            int randomIndex = new Random().Next(0, staryrozmiar - 1);

            Gra gra = new Gra()
            {
                Id = 0021,
                nazwa = "Ruletka"
            };

            StanGry stan = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2019, 05, 03))
            };

            Klient klient = new Klient()
            {
                imie = "Jan",
                nazwisko = "Nowak",
                wiek = 40,
                adresEmail = "jannowak@gmail.com"
            };

            UdzialWGrze udzial = new UdzialWGrze()
            {
                stangry = stan,
                klient = klient
            };

            service.UpdateUdzialWGrze(randomIndex, udzial);
            int newCollectionSize = data.udzialywgrze.Count;

            //check if properties are the same
            Assert.AreEqual(udzial.stangry, data.udzialywgrze[randomIndex].stangry);
        }
        [TestMethod]
        public void UpdateUdzialWGrzePositiveTestCustomer()
        {

            int staryrozmiar = data.udzialywgrze.Count;
            int randomIndex = new Random().Next(0, staryrozmiar - 1);

            Gra gra = new Gra()
            {
                Id = 0021,
                nazwa = "Ruletka"
            };

            StanGry stan = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2019, 05, 03))
            };

            Klient klient = new Klient()
            {
                imie = "Jan",
                nazwisko = "Nowak",
                wiek = 40,
                adresEmail = "jannowak@gmail.com"
            };

            UdzialWGrze udzial = new UdzialWGrze()
            {
                stangry = stan,
                klient = klient
            };

            service.UpdateUdzialWGrze(randomIndex, udzial);
            int newCollectionSize = data.udzialywgrze.Count;

            //check if properties are the same
            Assert.AreEqual(udzial.klient, data.udzialywgrze[randomIndex].klient);
        }

        [TestMethod]
        public void UpdateStanGryPositiveTestPlay()
        {

            int staryrozmiar = data.stanygier.Count;
            int randomIndex = new Random().Next(0, staryrozmiar - 1);

            Gra gra = new Gra()
            {
                Id = 0021,
                nazwa = "Ruletka"
            };

            StanGry stan = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2019, 05, 03))
            };

            service.UpdateStanGry(randomIndex, stan);


            //compare properties
            Assert.AreEqual(stan.gra, data.stanygier[randomIndex].gra);

        }
        [TestMethod]
        public void UpdateStanGryPositiveTestDate()
        {

            int staryrozmiar = data.stanygier.Count;
            int randomIndex = new Random().Next(0, staryrozmiar - 1);

            Gra gra = new Gra()
            {
                Id = 0021,
                nazwa = "Ruletka"
            };

            StanGry stan = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2019, 05, 03))
            };

            service.UpdateStanGry(randomIndex, stan);

            //compare properties
            Assert.AreEqual(stan.dataUruchomienia, data.stanygier[randomIndex].dataUruchomienia);
        }

 
        [TestMethod]
        public void DeleteKlientPositiveTest()
        {

            int staryrozmiar = data.klienci.Count;
            int randomIndex = new Random().Next(0, staryrozmiar - 1);

            Klient usuwanyklient = data.klienci[randomIndex];

            service.DeleteKlient(randomIndex);

            //check if list size is decreased
            Assert.AreNotEqual(staryrozmiar, data.klienci.Count);
        }

        [TestMethod]
        public void DeleteKlientNegativeTest()
        {

            int staryrozmiar = data.klienci.Count;

            //check if list size is not changed
            Assert.AreEqual(staryrozmiar, data.klienci.Count);
        }

        [TestMethod]
        public void DeleteGraPositiveTest()
        {

            int staryrozmiar = data.gry.Count;
            int i = 0023;

            Gra usuwanaGra = data.gry[i];

            service.DeleteGra(i);

            //check if list size is decreased
            Assert.AreNotEqual(staryrozmiar, data.gry.Count);
        }

        [TestMethod]
        public void DeleteGraNegativeTest()
        {

            int staryrozmiar = data.gry.Count;
            int i = -1;

            //try to delete object with incorrect key
            service.DeleteGra(i);

            //check if list size is decreased
            Assert.AreEqual(staryrozmiar, data.gry.Count);
        }

        [TestMethod]
        public void DeleteUdzialWGrzePositiveTest()
        {

            int staryrozmiar = data.udzialywgrze.Count;
            int randomIndex = new Random().Next(0, staryrozmiar - 1);

            UdzialWGrze usuwanyudzial = data.udzialywgrze[randomIndex];

            service.DeleteUdzialWGrze(randomIndex);

            //check if list size is decreased
            Assert.AreNotEqual(staryrozmiar, data.udzialywgrze.Count);
        }

        [TestMethod]
        public void DeleteUdzialWGrzeNegativeTest()
        {

            int staryrozmiar = data.udzialywgrze.Count;

            //try to delete customer (index is out of range)
            service.DeleteUdzialWGrze(staryrozmiar);
        }

        [TestMethod]
        public void DeleteStanGryPositiveTest()
        {

            int staryrozmiar = data.stanygier.Count;
            int randomIndex = new Random().Next(0, staryrozmiar - 1);

            StanGry usuwanystan = data.stanygier[randomIndex];

            service.DeleteStanGry(randomIndex);

            //check if list size is decreased
            Assert.AreNotEqual(staryrozmiar, data.stanygier.Count);
        }

        [TestMethod]
        public void DeleteStanGryNegativeTest()
        {

            int staryrozmiar = data.stanygier.Count;

            //try to delete customer (index is out of range)
            service.DeleteStanGry(staryrozmiar);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
