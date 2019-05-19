using Kasyno.MainLogic;
using Kasyno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace UnitTest
{
    class WypelnianieStalymi:DataFiller
    {
        public override void Fill(DataContext context)
        {
            List<Klient> klienci = context.klienci;
            Dictionary<int, Gra> gry = context.gry;
            ObservableCollection<UdzialWGrze> udzialywgrze = context.udzialywgrze;
            List<StanGry> stanygier = context.stanygier;


            Klient k1 = new Klient()
            {
                imie = "Jan",
                nazwisko = "Kowaski",
                wiek =35,
                adresEmail = "kowaskij@gmail.com"
            };
            Klient k2 = new Klient()
            {
                imie = "Zofia",
                nazwisko = "Nowak",
                wiek = 42,
                adresEmail = "zofianowak@gmail.com"
            };
            Klient k3 = new Klient()
            {
                imie = "Juliusz",
                nazwisko = "Dobrowolski",
                wiek = 50,
                adresEmail = "jdobrowolski@gmail.com"
            };


            Gra gra1 = new Gra()
            {
                id = 0023,
                nazwa = "Ruletka"
            };
            Gra gra2 = new Gra()
            {
                id = 0028,
                nazwa = "Baccarad",
            };
            Gra gra3 = new Gra()
            {
                id = 0037,
                nazwa = "Craps",
            };


            StanGry stangry1 = new StanGry()
            {
                gra = gra1,
                dataUruchomienia = new DateTimeOffset(new DateTime(2010, 01, 10))
            };
            StanGry stangry2 = new StanGry()
            {
                gra = gra2,
                dataUruchomienia = new DateTimeOffset(new DateTime(2005, 04, 18))
            };
            StanGry stangry3 = new StanGry()
            {
                gra = gra3,
                dataUruchomienia = new DateTimeOffset(new DateTime(2019, 05, 11))
            };


            UdzialWGrze udzial1 = new UdzialWGrze()
            {
                stangry = stangry1,
                klient = k1
            };
            UdzialWGrze udzial2 = new UdzialWGrze()
            {
                stangry = stangry2,
                klient = k2
            };
            UdzialWGrze udzial3 = new UdzialWGrze()
            {
                stangry = stangry3,
                klient = k3
            };

            klienci.Add(k1);
            klienci.Add(k2);
            klienci.Add(k3);
            gry.Add(gra1.id, gra1);
            gry.Add(gra2.id, gra2);
            gry.Add(gra3.id, gra3);
            stanygier.Add(stangry1);
            stanygier.Add(stangry2);
            stanygier.Add(stangry3);
            udzialywgrze.Add(udzial1);
            udzialywgrze.Add(udzial2);
            udzialywgrze.Add(udzial3);
        }
    }
}
