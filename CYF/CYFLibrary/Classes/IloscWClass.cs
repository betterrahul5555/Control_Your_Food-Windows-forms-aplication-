using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYFLibrary
{
  public  class IloscWClass
    {
        public string Gramy { get; set; }
        public string Dekagramy { get; set; }
        public string Kilogramy { get; set; }
        public string gramy { get; set; }
 public List<string> ListaIlośćZuzycia = new List<string>() { "Sztukach", "Gramach", "Dekagramach", "Kilogramach", "Brak" };
  public  List<string> ListaIloscW = new List<string>() { "Sztukach", "Gramach", "Dekagramach", "Kilogramach" };
   public List<string> ListaIloscWSztuki = new List<string>() { "Sztukach", "Brak" };
  public  List<string> ListaIloscWKG = new List<string>() { "Gramach", "Dekagramach", "Kilogramach", "Brak" };
    }
   
}
