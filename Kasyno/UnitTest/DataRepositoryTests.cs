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
            int staryrozmiar = data.udzialywgrze.Count;

            Gra gra = new Gra()
            {
                id = 0004,
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

            //sprawdza czy element jest zawaarty
            Assert.IsTrue(data.udzialywgrze.Contains(udzial));
        }

        [TestMethod]
        public void AddStanGryTest()
        {
            int staryrozmiar = data.stanygier.Count;

            Gra gra = new Gra()
            {
                id = 0004,
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

            //sprawdza czy element zosstal dodany
            Assert.IsTrue(data.stanygier.Contains(stanGry));
        }

        //test dla metod Get

        [TestMethod]
        public void GetKlientTest()
        {
            int randomIndex = new Random().Next(0, data.klienci.Count - 1);
            int outOfRangeIndex = data.klienci.Count;

            //sprawdza czy metoda zwraca odpowiedni obiekt dla indeksu
            Assert.AreEqual(data.klienci[randomIndex], dataRepository.GetKlient(randomIndex));

            //sprawdza czy metoda zwraca null
            Assert.AreEqual(null, dataRepository.GetKlient(outOfRangeIndex));
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
            //sprawdza czy metoda zwraca null
            Assert.AreEqual(null, dataRepository.GetGra(-1));
        }

        [TestMethod]
        public void GetUdzialWGrzeTest()
        {
            int randomIndex = new Random().Next(0, data.udzialywgrze.Count - 1);
            int outOfRangeIndex = data.udzialywgrze.Count;

            //sprawdza czy metoda zwraca odpowiedni obiekt dla indeksu
            Assert.AreEqual(data.udzialywgrze[randomIndex], dataRepository.GetUdzialWGrze(randomIndex));

            //sprawdza czy metoda zwraca null
            Assert.AreEqual(null, dataRepository.GetUdzialWGrze(outOfRangeIndex));
        }

        [TestMethod]
        public void GetStanGryTest()
        {
            int randomIndex = new Random().Next(0, data.stanygier.Count - 1);
            int outOfRangeIndex = data.stanygier.Count;

            //sprawdza czy metoda zwraca odpowiedni obiekt dla indeksu
            Assert.AreEqual(data.stanygier[randomIndex], dataRepository.GetStanGry(randomIndex));

            //sprawdza czy metoda zwraca null
            Assert.AreEqual(null, dataRepository.GetStanGry(outOfRangeIndex));
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
        public void UpdateKlientTest()
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

            //sprawdza czy liczba nie zostala zmieniona
            Assert.AreEqual(licznikKlientow, data.klienci.Count);

            //sprawdza wlasciwosci
            Assert.AreEqual(zmianaKlienta.imie, data.klienci[i].imie);
            Assert.AreEqual(zmianaKlienta.nazwisko, data.klienci[i].nazwisko);
            Assert.AreEqual(zmianaKlienta.wiek, data.klienci[i].wiek);
            Assert.AreEqual(zmianaKlienta.adresEmail, data.klienci[i].adresEmail);
        }
        [TestMethod]
        public void UpdateGraTest()
        {
            Gra gra = new Gra()
            {
                id = 0021,
                nazwa = "JednorekiBandyta"
            };

            int oldDictSize = data.gry.Count;

            dataRepository.UpdateGra(gra.id, gra);

            ///sprawdza czy liczba nie zostala zmieniona
            Assert.AreEqual(oldDictSize, data.gry.Count);

            //sprawdza wlasciwosci
            //Assert.AreEqual(gra.id, data.gry[gra.id].id);
            Assert.AreEqual(gra.nazwa, data.gry[gra.id].nazwa);

        }
        [TestMethod]
        public void UpdateStanGryTest()
        {

            int staryrozmiar = data.stanygier.Count;
            int i = new Random().Next(0, staryrozmiar - 1);

            Gra gra = new Gra()
            {
                id = 0021,
                nazwa = "JednorekiBandyta"
            };

            StanGry cdState = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2019, 15, 04))
            };

            dataRepository.UpdateStanGry(i, cdState);
            int newListSize = data.stanygier.Count;

            //sprawdza czy liczba nie zostala zmieniona
            Assert.AreEqual(staryrozmiar, newListSize);

            //sprawdza wlasciwosci
            Assert.AreEqual(cdState.gra, data.stanygier[i].gra);
            Assert.AreEqual(cdState.dataUruchomienia, data.stanygier[i].dataUruchomienia);
        }

        [TestMethod]
        public void UpdateUdzialWGrzeTest()
        {

            int staryrozmiar = data.udzialywgrze.Count;
            int i = new Random().Next(0, staryrozmiar - 1);

            Gra gra = new Gra()
            {
                id = 0021,
                nazwa = "JednorekiBandyta"
            };

            StanGry cdState = new StanGry()
            {
                gra = gra,
                dataUruchomienia = new DateTimeOffset(new DateTime(2019, 15, 04))
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

            //sprawdza czy liczba nie zostala zmieniona
            Assert.AreEqual(staryrozmiar, newCollectionSize);

            //sprawdza wlasciwosci
            Assert.AreEqual(udzial.stangry, data.udzialywgrze[i].stangry);
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

            //sprawdza czy obiekt został usunięty
            Assert.IsFalse(data.klienci.Contains(removedCustomer));
        }
        [TestMethod]
        public void DeleteGraTest()
        {
            int statyrozmiar = data.gry.Count;
            int i = 0021;

            Gra usuwanaGra = data.gry[i];

            dataRepository.DeleteGra(i);

            //sprawdza zmienijszenie rozmiaru
            Assert.AreNotEqual(statyrozmiar, data.gry.Count);

            //sprawdza czy kolekcja nie zawiera elementu
            Assert.IsFalse(data.gry.ContainsValue(usuwanaGra));
            Assert.IsFalse(data.gry.ContainsKey(usuwanaGra.id));
        }
        [TestMethod]
        public void DeleteStanGryTest()
        {

            int oldCollectionSize = data.stanygier.Count;
            int i = new Random().Next(0, oldCollectionSize - 1);

            StanGry removedCDState = data.stanygier[i];

            dataRepository.DeleteStanGry(i);

            //sprawdza, czy rozmiar sie zmiejszył
            Assert.AreNotEqual(oldCollectionSize, data.stanygier.Count);

            //sprawdza czy obiekt został usunięty
            Assert.IsFalse(data.stanygier.Contains(removedCDState));
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

            //sprawdza czy obiekt został usunięty
            Assert.IsFalse(data.udzialywgrze.Contains(removedEvent));
        }
    }
}
