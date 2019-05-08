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
    }
    }
