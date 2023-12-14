using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYFLibrary
{
   public class ZuzycieJakieClass
    {
        public ZuzycieJakieClass(string nazwa_, int wartosc_)
        {
            nazwa = nazwa_;
            wartosc=wartosc_;
        }
        public string nazwa { get; set; }
        public int wartosc { get; set; }
    }
}
