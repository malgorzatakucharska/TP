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
        public void AddUdziałWGrze(UdzialWGrze udzial)
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
    }
    }
