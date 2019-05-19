using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno.Data
{
    public class UdzialWGrze
    {
        public int Id { get; set; }
        public StanGry stangry {get; set;}
        public Klient klient { get; set; }
    }
}
