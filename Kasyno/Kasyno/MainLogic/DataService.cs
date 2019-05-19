using System;
using System.Collections.Generic;
using System.Linq;
using Kasyno.Data;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno.MainLogic
{
    public class DataService
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
        public void AddUdzialWGrze(Klient klient, StanGry stan)
        {
            bool isUdzialWGrzeExist = repository.GetAllUdzialyWGrze().Any(e => e.stangry.Equals(stan) && e.klient.Equals(klient));

            if (!isUdzialWGrzeExist)
            {
                UdzialWGrze evt = new UdzialWGrze() { klient = klient, stangry = stan };
                repository.AddUdzialWGrze(evt);
            }
        }

        public void AddKlient(Klient klient)
        {
            IEnumerable<Klient> biezacyKlient = repository.GetAllKlienci();

            if (!biezacyKlient.Contains(klient))
            {
                repository.AddKlient(klient);
            }
        }

        public void AddGra(Gra gra)
        {
            bool isGraExist = repository.GetAllGry().Where(x => x.id == gra.id).Any();

            if (!isGraExist)
            {
                repository.AddGra(gra);
            }
        }

        public void AddCDState(Gra gra)
        {
            bool isGraExist = repository.GetAllGry().Where(x => x.id == gra.id).Any();
            DateTimeOffset biezacaData = DateTimeOffset.Now;

            if (isGraExist)
            {
                repository.AddStanGry(new StanGry() { gra = gra, dataUruchomienia = biezacaData });
            }
        }

        public void UpdateKlient(int i, Klient klient)
        {
            int iloscelementow = repository.GetAllKlienci().Count();

            if (iloscelementow > i)
            {
                repository.UpdateKlient(i, klient);
            }
        }

        public void UpdateGra(int id, Gra gra)
        {
            bool isGraExist = repository.GetAllGry().Where(x => x.id == id).Any();

            if (isGraExist)
            {
                repository.UpdateGra(id, gra);
            }
        }

        public void UpdateUdzialWGrze(int i, UdzialWGrze udzial)
        {
            int iloscelementow = repository.GetAllUdzialyWGrze().Count();

            if (iloscelementow > i)
            {
                repository.UpdateUdzialWGrze(i, udzial);
            }
        }

        public void UpdateStanGry(int i, StanGry stan)
        {
            int iloscelementow = repository.GetAllStanyGier().Count();

            if (iloscelementow > i)
            {
                repository.UpdateStanGry(i, stan);
            }
        }

        public void DeleteKlient(int i)
        {
            int iloscelementow = repository.GetAllKlienci().Count();

            if (iloscelementow > i)
            {
                repository.DeleteKlient(i);
            }
        }

        public void DeleteGra(int i)
        {
            bool isGraExist = repository.GetAllGry().Where(x => x.id == i).Any();

            if (isGraExist)
            {
                repository.DeleteGra(i);
            }
        }

        public void DeleteUdzialWGrze(int i)
        {
            int iloscelemntow = repository.GetAllUdzialyWGrze().Count();

            if (iloscelemntow > i)
            {
                repository.DeleteUdzialWGrze(i);
            }
        }

        public void DeleteStanGry(int i)
        {
            int iloscelementow = repository.GetAllStanyGier().Count();

            if (iloscelementow > i)
            {
                repository.DeleteStanGry(i);
            }
        }

        public List<Klient> GetKlientbynazwisko(string nazwisko)
        {
            return repository.GetAllKlienci().Where(c => c.nazwisko == nazwisko).ToList();
        }

        public Dictionary<int, Gra> GetGraById(int id)
        {
            return repository.GetAllGry().Where(d => d.id == id).ToDictionary(d => d.id);
        }
    }
}
