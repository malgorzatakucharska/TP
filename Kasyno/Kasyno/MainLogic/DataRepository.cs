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
    }
    }
