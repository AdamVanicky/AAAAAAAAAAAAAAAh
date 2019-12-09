using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonomní_auta
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string Cesta = "CCCCMCCCMCTCCCTC"; //16 znaků
            RidiciStredisko rs = new RidiciStredisko();
            AutonomniAuto AA = new AutonomniAuto(60);  rs.PridejAuto(AA); rs.Pocasi(rs);


            float AktualniRychlost = AA.CestovniRychlost;
            foreach (char z in Cesta)
            {
                switch(z)
                {
                    case 'C':
                        Console.WriteLine("C");
                        AktualniRychlost = AA.CestovniRychlost;
                        break;
                    case 'M':
                        Console.WriteLine("M");

                        break;
                    case 'T':
                        Console.WriteLine("T");
                        break;
                }
            }
            Console.WriteLine();
            Console.ReadLine();

        }
    }
  
    public class RidiciStredisko
    {
        
        public List<AutonomniAuto> Al = new List<AutonomniAuto>();
        public void PridejAuto(AutonomniAuto A) { Al.Add(A); }
        
        public delegate weather ZmenaPocasi();
        public event ZmenaPocasi zmenapocasi;

        public delegate void ZmenaStavu(char z, int aktualnirychlost, weather aktualnipocasi);
        public event ZmenaStavu zmenastavu;

        public void Pocasi(RidiciStredisko rs) { rs.zmenapocasi += MeteorologickaStanice.Zmena; }
        public void Trasa(RidiciStredisko rs) { rs.zmenastavu += rs.ZmenaTrasy; }

        public void ZmenaTrasy(char z, int aktualnirychlost, weather aktualnipocasi)
        {
            if (z == 'M')
            {
                aktualnirychlost -= 20;
                aktualnipocasi = zmenapocasi();
            }
            else if (z == 'T')
            {

            }
        }
    }
    public class AutonomniAuto
    {
        public float CestovniRychlost;
        public AutonomniAuto(float cestovnirychlost)
        {
            CestovniRychlost = cestovnirychlost;
        }
        
    }
    public class MeteorologickaStanice
    {
        
        public static weather Zmena()
        {
            Random nc = new Random();
            weather AP = (weather)nc.Next(Enum.GetNames(typeof(weather)).Length);
            return AP;
        }
    }

    #region Enumy
    public enum Trasa
    {
        Cesta = 1,
        Most,
        Tunel
    }

    public enum weather
    {
        Clear = 0,
        Rain,
        Winter,
        Storm
    }
    #endregion
}
