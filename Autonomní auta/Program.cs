using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonomní_auta
{
    class Program
    {
        public Trasa zmena = Trasa.Cesta;
        static void Main(string[] args)
        {
            
        }
    }

    

    public class AutonomniAuto
    {
        

        public int CestovniRychlost { get; set; }
        public int DelkaTrasy { get; set; }

        public AutonomniAuto(int cestrovnirychlost, int delkatrasy)
        {
            CestovniRychlost = cestrovnirychlost;
            DelkaTrasy = delkatrasy;
        }
    }

    public class MeteorologickaStanice
    {

    }

    public class RidiciStredisko
    {

    }

    public enum Trasa
    {
        Cesta = 1,
        Most,
        Tunel
    }
}
