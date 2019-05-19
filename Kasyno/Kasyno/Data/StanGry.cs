using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno.Data
{
    public class StanGry
    {
        public int Id { get; set; }
        public Gra gra { get; set; }
        public DateTimeOffset dataUruchomienia { get; set; }
    }
}
