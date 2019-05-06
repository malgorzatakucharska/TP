using Kasyno.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno.MainLogic
{
    public partial class DataContext
    {
        public List<Klient> klienci;
        public Dictionary<int, Gra> gry;
        public ObservableCollection<UdzialWGrze> udzialywgrze;
        public List<StanGry> stanygier;

        public DataContext()
        {
            klienci = new List<Klient>();
            gry = new Dictionary<int, Gra>();
            udzialywgrze = new ObservableCollection<UdzialWGrze>();
            stanygier = new List<StanGry>();
        }
    }
}
