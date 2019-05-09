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
            foreach (Gra gra in listOfGra)
            {
                Assert.IsTrue(data.gry.Values.Contains(AddStanGryTest));
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


    }
}
