using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kasyno.Data;
using Kasyno.MainLogic;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class DataRepositoryTests
    {
        DataContext data;
        DataFiller filler;
        DataRepository dataRepository;

        [TestInitialize]
        public void InitializeTests()
        {
            data = new DataContext();
            filler = new WypelnianieStalymi();
            dataRepository = new DataRepository(filler, data);
            //dataRepository.inicjalizuj();
        }

        //test dla metody add

        [TestMethod]
        public void AddKlientTest()
        {
            int rozmiarstary = data.klienci.Count;

            Klient customer = new Klient()
            {
                imie = "Jan",
                nazwisko = "Nowak",
                wiek = 40,
                adresEmail = "jannowak@gmail.com"
            };

            dataRepository.AddKlient(customer);
            int rozmiarnowy = data.klienci.Count;

            // sprawdza rozmiar starej i nowej listy
            Assert.AreNotEqual(rozmiarstary, rozmiarnowy);

        }
        [TestMethod]
        public void AddGraTest()
        {
            int rozmiarstary = data.gry.Count;

            Gra gra = new Gra()
            {
                Id = 0021,
                nazwa = "Ruletka",
            };

            dataRepository.AddGra(gra);
            int rozmiarnowy = data.gry.Count;

            // sprawdza rozmiar starego i nowego slownika
            Assert.AreNotEqual(rozmiarstary, rozmiarnowy);

        }

        [TestMethod]
        public void AddUdzialWGrzeTest()
        {
            int staryrozmiar = data.udzialywgrze.Count;

            Gra gra = new Gra()
            {
                Id = 0004,
                nazwa = "Poker"
            };

            StanGry stangry = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2013, 11, 03))
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
                stangry = stangry,
                klient = klient
            };

            dataRepository.AddUdzialWGrze(udzial);
            int newListSize = data.udzialywgrze.Count;

            //sprawdza stary i nowy rozmiar
            Assert.AreNotEqual(staryrozmiar, newListSize);
        }

        [TestMethod]
        public void AddStanGryTest()
        {
            int staryrozmiar = data.stanygier.Count;

            Gra gra = new Gra()
            {
                Id = 0004,
                nazwa = "Poker",
            };

            StanGry stanGry = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2013, 11, 03))
            };

            dataRepository.AddStanGry(stanGry);
            int newListSize = data.stanygier.Count;

            //sprawdza czy rozmiar sie zmienil
            Assert.AreNotEqual(staryrozmiar, newListSize);

        }

        //test dla metod Get

        [TestMethod]
        public void GetKlientTest()
        {
            int randomIndex = new Random().Next(0, data.klienci.Count - 1);
            int outOfRangeIndex = data.klienci.Count;

            //sprawdza czy metoda zwraca odpowiedni obiekt dla indeksu
            Assert.AreEqual(data.klienci[randomIndex], dataRepository.GetKlient(randomIndex));

        }

        [TestMethod]
        public void GetGraTest()
        {
            Dictionary<int, Gra>.KeyCollection keysList = data.gry.Keys;

            foreach (int key in keysList)
            {
                //sprawdza czy metoda zwraca odpowiedni obiekt dla indeksu
                Assert.AreEqual(data.gry[key], dataRepository.GetGra(key));
            }
        }

        [TestMethod]
        public void GetUdzialWGrzeTest()
        {
            int randomIndex = new Random().Next(0, data.udzialywgrze.Count - 1);
            int outOfRangeIndex = data.udzialywgrze.Count;

            //sprawdza czy metoda zwraca odpowiedni obiekt dla indeksu
            Assert.AreEqual(data.udzialywgrze[randomIndex], dataRepository.GetUdzialWGrze(randomIndex));

        }

        [TestMethod]
        public void GetStanGryTest()
        {
            int randomIndex = new Random().Next(0, data.stanygier.Count - 1);
            int outOfRangeIndex = data.stanygier.Count;

            //sprawdza czy metoda zwraca odpowiedni obiekt dla indeksu
            Assert.AreEqual(data.stanygier[randomIndex], dataRepository.GetStanGry(randomIndex));
        }

        //testy dla metod GetAll

        [TestMethod]
        public void GetAllKlienciTest()
        {
            //sprawdza czy zawartość kolekcji jest dopasowana
            Assert.AreEqual(data.klienci, dataRepository.GetAllKlienci());
        }

        [TestMethod]
        public void GetAllGryTest()
        {
            IEnumerable<Gra> listOFGry = dataRepository.GetAllGry();

            //sprawdza czy zawartość kolekcji jest dopasowana
            foreach (Gra gra in listOFGry)
            {
                Assert.IsTrue(data.gry.Values.Contains(gra));
            }
        }

        [TestMethod]
        public void GetAllUdzialWGrzeTest()
        {
            //sprawdza czy zawartość kolekcji jest dopasowana
            Assert.AreEqual(data.udzialywgrze, dataRepository.GetAllUdzialyWGrze());
        }

        [TestMethod]
        public void GetAllStanyGierTest()
        {
            //sprawdza czy zawartość kolekcji jest dopasowana
            Assert.AreEqual(data.stanygier, dataRepository.GetAllStanyGier());
        }


        //testy dla metod Update
        [TestMethod]
        public void UpdateKlientTestFirstName()
        {

            Klient zmianaKlienta = new Klient()
            {
                imie = "Janusz",
                nazwisko = "Nowacki",
                wiek = 41,
                adresEmail = "janusznowacki@gmail.pl"
            };

            int licznikKlientow = data.klienci.Count;
            int i = new Random().Next(0, licznikKlientow - 1);

            dataRepository.UpdateKlient(i, zmianaKlienta);


            //sprawdza wlasciwosci
            Assert.AreEqual(zmianaKlienta.imie, data.klienci[i].imie);

        }
        [TestMethod]
        public void UpdateKlientTestLastname()
        {

            Klient zmianaKlienta = new Klient()
            {
                imie = "Janusz",
                nazwisko = "Nowacki",
                wiek = 41,
                adresEmail = "janusznowacki@gmail.pl"
            };

            int licznikKlientow = data.klienci.Count;
            int i = new Random().Next(0, licznikKlientow - 1);

            dataRepository.UpdateKlient(i, zmianaKlienta);


            //sprawdza wlasciwosci
            Assert.AreEqual(zmianaKlienta.nazwisko, data.klienci[i].nazwisko);
        }
        [TestMethod]
        public void UpdateKlientTestOld()
        {

            Klient zmianaKlienta = new Klient()
            {
                imie = "Janusz",
                nazwisko = "Nowacki",
                wiek = 41,
                adresEmail = "janusznowacki@gmail.pl"
            };

            int licznikKlientow = data.klienci.Count;
            int i = new Random().Next(0, licznikKlientow - 1);

            dataRepository.UpdateKlient(i, zmianaKlienta);


            //sprawdza wlasciwosci
            Assert.AreEqual(zmianaKlienta.wiek, data.klienci[i].wiek);
        }
        [TestMethod]
        public void UpdateKlientTestEmail()
        {

            Klient zmianaKlienta = new Klient()
            {
                imie = "Janusz",
                nazwisko = "Nowacki",
                wiek = 41,
                adresEmail = "janusznowacki@gmail.pl"
            };

            int licznikKlientow = data.klienci.Count;
            int i = new Random().Next(0, licznikKlientow - 1);

            dataRepository.UpdateKlient(i, zmianaKlienta);


            //sprawdza wlasciwosci
            Assert.AreEqual(zmianaKlienta.adresEmail, data.klienci[i].adresEmail);
        }
        [TestMethod]
        public void UpdateGraTestId()
        {
            Gra gra = new Gra()
            {
                Id = 0023,
                nazwa = "JednorekiBandyta"
            };

            int oldDictSize = data.gry.Count;

            dataRepository.UpdateGra(gra.Id, gra);


            //sprawdza wlasciwosci
            Assert.AreEqual(gra.Id, data.gry[gra.Id].Id);

        }
        [TestMethod]
        public void UpdateGraTestName()
        {
            Gra gra = new Gra()
            {
                Id = 0023,
                nazwa = "JednorekiBandyta"
            };

            int oldDictSize = data.gry.Count;

            dataRepository.UpdateGra(gra.Id, gra);


            //sprawdza wlasciwosci
            Assert.AreEqual(gra.nazwa, data.gry[gra.Id].nazwa);

        }

        [TestMethod]
        public void UpdateStanGryTestGra()
        {

            int staryrozmiar = data.stanygier.Count;
            int i = new Random().Next(0, staryrozmiar - 1);

            Gra gra = new Gra()
            {
                Id = 0028,
                nazwa = "JednorekiBandyta"
            };

            StanGry cdState = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2019, 05, 04))
            };

            dataRepository.UpdateStanGry(i, cdState);
            int newListSize = data.stanygier.Count;


            //sprawdza wlasciwosci
            Assert.AreEqual(cdState.gra, data.stanygier[i].gra);
        }

        [TestMethod]
        public void UpdateStanGryTestDate()
        {

            int staryrozmiar = data.stanygier.Count;
            int i = new Random().Next(0, staryrozmiar - 1);

            Gra gra = new Gra()
            {
                Id = 0028,
                nazwa = "JednorekiBandyta"
            };

            StanGry cdState = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2019, 05, 04))
            };

            dataRepository.UpdateStanGry(i, cdState);
            int newListSize = data.stanygier.Count;


            //sprawdza wlasciwosci
            Assert.AreEqual(cdState.dataUruchomienia, data.stanygier[i].dataUruchomienia);
        }

        [TestMethod]
        public void UpdateUdzialWGrzeTestState()
        {

            int staryrozmiar = data.udzialywgrze.Count;
            int i = new Random().Next(0, staryrozmiar - 1);

            Gra gra = new Gra()
            {
                Id = 0028,
                nazwa = "JednorekiBandyta"
            };

            StanGry cdState = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2019, 05, 04))
            };

            Klient klient = new Klient()
            {
                imie = "Janusz",
                nazwisko = "Nowacki",
                wiek = 41,
                adresEmail = "janusznowacki@gmail.pl"
            };

            UdzialWGrze udzial = new UdzialWGrze()
            {
                stangry = cdState,
                klient = klient
            };

            dataRepository.UpdateUdzialWGrze(i, udzial);
            int newCollectionSize = data.udzialywgrze.Count;


            //sprawdza wlasciwosci
            Assert.AreEqual(udzial.stangry, data.udzialywgrze[i].stangry);
        }

        [TestMethod]
        public void UpdateUdzialWGrzeTestCustomer()
        {

            int staryrozmiar = data.udzialywgrze.Count;
            int i = new Random().Next(0, staryrozmiar - 1);

            Gra gra = new Gra()
            {
                Id = 0028,
                nazwa = "JednorekiBandyta"
            };

            StanGry cdState = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2019, 05, 04))
            };

            Klient klient = new Klient()
            {
                imie = "Janusz",
                nazwisko = "Nowacki",
                wiek = 41,
                adresEmail = "janusznowacki@gmail.pl"
            };

            UdzialWGrze udzial = new UdzialWGrze()
            {
                stangry = cdState,
                klient = klient
            };

            dataRepository.UpdateUdzialWGrze(i, udzial);
            int newCollectionSize = data.udzialywgrze.Count;


            //sprawdza wlasciwosci
            Assert.AreEqual(udzial.klient, data.udzialywgrze[i].klient);
        }

        //testy dla metod Delete
        [TestMethod]
        public void DeleteKlientTest()
        {

            int staryrozmiar = data.klienci.Count;
            int i = new Random().Next(0, staryrozmiar - 1);

            Klient removedCustomer = data.klienci[i];

            dataRepository.DeleteKlient(i);

            //sprawdza, czy rozmiar sie zmiejszył
            Assert.AreNotEqual(staryrozmiar, data.klienci.Count);

        }
        [TestMethod]
        public void DeleteGraTest()
        {
            int statyrozmiar = data.gry.Count;
            int i = 0023;

            Gra usuwanaGra = data.gry[i];

            dataRepository.DeleteGra(i);

            //sprawdza zmienijszenie rozmiaru
            Assert.AreNotEqual(statyrozmiar, data.gry.Count);

        }

        [TestMethod]
        public void DeleteStanGryTest()
        {
            int staryrozmiar = data.stanygier.Count;
            int i = new Random().Next(0, staryrozmiar - 1);

            StanGry usuwanystanGry = data.stanygier[i];

            dataRepository.DeleteStanGry(i);

            //sprawdza, czy rozmiar sie zmiejszył
            Assert.AreNotEqual(staryrozmiar, data.stanygier.Count);

        }
        [TestMethod]
        public void DeleteUdzialWGrzeTest()
        {

            int oldCollectionSize = data.udzialywgrze.Count;
            int i = new Random().Next(0, oldCollectionSize - 1);

            UdzialWGrze removedEvent = data.udzialywgrze[i];

            dataRepository.DeleteUdzialWGrze(i);

            //sprawdza, czy rozmiar sie zmiejszył
            Assert.AreNotEqual(oldCollectionSize, data.udzialywgrze.Count);

        }

        // testy wydajnosciowe
      /*  [TestMethod]
        public void Wypelnianie10()
        {
            int n = 10;
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
        }*/
    }
}
