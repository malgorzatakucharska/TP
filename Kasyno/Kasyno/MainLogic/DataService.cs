using System;
using System.Collections.Generic;
using System.Linq;
using Kasyno.Data;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno.MainLogic
{
    class DataService
    {
        private DataRepository repository;

        public DataService(DataRepository repository)
        {
            this.repository = repository;
        }
        public string showAllKlients(IEnumerable<Klient> klienci)
        {
            string data = "";
            foreach (Klient klient in klienci)
            {
                data += klient.imie + " " + klient.nazwisko + " " + klient.wiek + " " + klient.adresEmail + "\n";
            }
            return data;
        }

        public string showAllGry(IEnumerable<Gra> gry)
        {
            string data = "";
            foreach (Gra gra in gry)
            {
                data += gra.id + " " + gra.nazwa + " " + "\n";
            }

            return data;
        }

        public string showAllUdzialyWGrze(IEnumerable<UdzialWGrze> udzialywgrze)
        {
            string data = "";
            foreach (UdzialWGrze udzial in udzialywgrze)
            {
                data += udzial.klient.imie + " " + udzial.klient.nazwisko + " " + udzial.stangry.gra.id + " " + udzial.stangry.dataUruchomienia + "\n";
            }
            return data;
        }

        public string showAllStanyGier(IEnumerable<StanGry> stanygier)
        {
            string data = "";
            foreach (StanGry stan in stanygier)
            {
                data += stan.gra.id + " " + stan.dataUruchomienia + "\n";
            }
            return data;
        }

        public string showAllInformacje(IEnumerable<UdzialWGrze> udzialywgrze)
        {
            string data = "";
            foreach(UdzialWGrze udzial in udzialywgrze)
            {
                data += udzial.klient.imie + " " + udzial.klient.nazwisko + " " + udzial.klient.wiek + " " + udzial.klient.adresEmail + " " +
                    udzial.stangry.dataUruchomienia + " " + udzial.stangry.gra.id + " " + "\n" +
                    "#########################################################" + "\n";
            }
            return data;
        }
    }
}
