using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno.MainLogic
{
   public abstract class DataFiller
    {
        public abstract void Fill(DataContext context);
    }
}
