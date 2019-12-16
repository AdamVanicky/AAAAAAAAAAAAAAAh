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
            
            RidiciStredisko rs = new RidiciStredisko();
            rs.PridejAuto(new AutonomniAuto(120, "CCCCMCCCMCTCCCTCCCCCCCC"));
            rs.PridejAuto(new AutonomniAuto(95, "CCCCMCCCMCTCCCTCCCC"));
            rs.PridejAuto(new AutonomniAuto(110, "CMMMMCCCMCTCCCTCCCCC"));
            rs.PridejAuto(new AutonomniAuto(100, "CCCCMCCMCTCTCCCCCCCC"));
            rs.PridejAuto(new AutonomniAuto(70, "CCCCMCCCMCTCCCTCCCCCCCCCCCCCCMMMCTTTTTCCCCC"));
            rs.Pocasi(rs);
            rs.Svetla = false;

            int i = 0;
            foreach(AutonomniAuto AA in rs.Al)
            {
                Console.WriteLine($"Auto č. {i + 1}");
                foreach (char z in rs.Al[i].JehoCesta)
                {
                    
                    switch (z)
                    {
                        case 'C':
                            rs.Svetla = false;
                            rs.AktualniRychlost = rs.Al[i].CestovniRychlost;
                            rs.Trasa(rs);
                            rs.Trasy(z);
                            Console.WriteLine($"C   {rs.AktualniRychlost}km/h ~ {rs.AktualniPocasi} ~ {rs.Svetla}");
                            break;
                        case 'M':
                            rs.AktualniRychlost = rs.Al[i].CestovniRychlost;
                            rs.Trasa(rs);
                            rs.Trasy(z);
                            Console.WriteLine($"M   {rs.AktualniRychlost}km/h ~ {rs.AktualniPocasi} ~ {rs.Svetla}");
                            break;
                        case 'T':
                            rs.AktualniRychlost = rs.Al[i].CestovniRychlost;
                            rs.Trasa(rs);
                            rs.Trasy(z);
                            Console.WriteLine($"T   {rs.AktualniRychlost}km/h ~ {rs.Svetla}");
                            break;
                    }
                }
                i++;
                System.Threading.Thread.Sleep(2000);
            }
            Console.WriteLine("Konec");
            Console.ReadLine();

        }
    }
  
    public class RidiciStredisko
    {
        public float AktualniRychlost;
        public weather AktualniPocasi;
        public bool Svetla = false;
        public List<AutonomniAuto> Al = new List<AutonomniAuto>();
        public void PridejAuto(AutonomniAuto A) { Al.Add(A); }
        
        public delegate weather ZmenaPocasi();
        public event ZmenaPocasi zmenapocasi;

        public delegate void ZmenaStavu(char z);
        public event ZmenaStavu zmenastavu;

        public void Pocasi(RidiciStredisko rs) { rs.zmenapocasi += MeteorologickaStanice.Zmena; }
        public void Trasa(RidiciStredisko rs) { rs.zmenastavu += rs.ZmenaTrasy; }

        public void Trasy(char z)
        {
            zmenastavu(z);
        }
        public void ZmenaTrasy(char z)
        {
            
            if (z == 'M')
            {
                Svetla = false;

                AktualniPocasi = zmenapocasi();
                switch (AktualniPocasi)
                {
                    case weather.Clear:
                        AktualniRychlost = 40;
                        break;
                    case weather.Rain:
                        AktualniRychlost = 38;
                        break;
                    case weather.Storm:
                        AktualniRychlost = 32;
                        break;
                    case weather.Winter:
                        AktualniRychlost = 25;
                        break;
                }
            }
            else if (z == 'T')
            {
                Svetla = true;
                AktualniRychlost = 35;
            }
            else
            {
                AktualniPocasi = zmenapocasi();
                switch (AktualniPocasi)
                {
                    case weather.Rain:
                        AktualniRychlost = 100;
                        break;
                    case weather.Storm:
                        AktualniRychlost = 70;
                        break;
                    case weather.Winter:
                        AktualniRychlost = 50;
                        break;
                }
            }
        }

        
    }
    public class AutonomniAuto
    {
        public float CestovniRychlost;
        public string JehoCesta;
        public AutonomniAuto(float cestovnirychlost, string jehocesta)
        {
            CestovniRychlost = cestovnirychlost;
            JehoCesta = jehocesta;
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
