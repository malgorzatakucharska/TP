using Kasyno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno.MainLogic
{
    public class DataRepository
    {
        private DataContext data;
        private DataFiller filler;

        public DataRepository(DataFiller filler, DataContext data)
        {
            this.filler = filler;
            this.data = data;
            filler.Fill(data);
        }
        // medody Add
        public void AddKlient(Klient klient)
        {
            data.klienci.Add(klient);
        }
        public void AddGra(Gra gra)
        {
            data.gry.Add(gra.id, gra);
        }
        public void AddStanGry(StanGry stan)
        {
            data.stanygier.Add(stan);
        }
        public void AddUdzialWGrze(UdzialWGrze udzial)
        {
            data.udzialywgrze.Add(udzial);
        }
        //metody Get
        public Klient GetKlient(int i)
        {
            if (data.klienci.Count > i)
            {
                return data.klienci[i];
            }
            else
            {
                return null;
            }
        }
        public Gra GetGra(int i)
        {
            if (data.gry.ContainsKey(i))
            {
                return data.gry[i];
            }
            else
            {
                return null;
            }
        }
        public StanGry GetStanGry(int i)
        {
            if (data.stanygier.Count > i)
            {
                return data.stanygier[i];
            }
            else
            {
                return null;
            }
        }
        public UdzialWGrze GetUdzialWGrze(int i)
        {
            if (data.udzialywgrze.Count > i)
            {
                return data.udzialywgrze[i];
            }
            else
            {
                return null;
            }
        }
        //metody GetAll
        public IEnumerable<Klient> GetAllKlienci()
        {
            return data.klienci;
        }
        public IEnumerable<Gra> GetAllGry()
        {
            return data.gry.Values;
        }
        public IEnumerable<StanGry> GetAllStanyGier()
        {
            return data.stanygier;
        }
        public IEnumerable<UdzialWGrze> GetAllUdzialyWGrze()
        {
            return data.udzialywgrze;
        }
        //metody Update
        public void UpdateKlient(int i, Klient nowyklient)
        {
            Klient klient = data.klienci[i];

            klient.imie = nowyklient.imie;
            klient.nazwisko = nowyklient.nazwisko;
            klient.wiek = nowyklient.wiek;
            klient.adresEmail = nowyklient.adresEmail;
        }
        public void UpdateGra(int i, Gra nowaGra)
        {
            data.gry[i].nazwa = nowaGra.nazwa;
        }
        public void UpdateStanGry(int i, StanGry nowyStan)
        {
            StanGry stan = data.stanygier[i];

            stan.gra = nowyStan.gra;
            stan.dataUruchomienia = nowyStan.dataUruchomienia;
        }
        public void UpdateUdzialWGrze(int i, UdzialWGrze nowyUdzial)
        {
            UdzialWGrze udzial = data.udzialywgrze[i];

            udzial.stangry = nowyUdzial.stangry;
            udzial.klient = nowyUdzial.klient;
        }
        // metody Delete
        public void DeleteKlient(int i)
        {
            data.klienci.RemoveAt(i);
        }
        public void DeleteGra(int i)
        {
            data.gry.Remove(i);
        }
        public void DeleteStanGry(int i)
        {
            data.stanygier.RemoveAt(i);
        }
        public void DeleteUdzialWGrze(int i)
        {
            data.udzialywgrze.RemoveAt(i);
        }
    }
    }
