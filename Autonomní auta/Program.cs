﻿using System;
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
            string Trasa = "CCCCMCCCCCTCCCCC";
            AutonomniAuto A = new AutonomniAuto(50, 100);
            List<AutonomniAuto> lA = new List<AutonomniAuto>();
            lA.Add(A);
            double Doba = A.DobaCesty(A.CestovniRychlost, A.DelkaTrasy);

            Postup += @"Dojeto do cíle";
            Console.ReadLine();

        }
    }
    public class AutonomniAuto
    {

        public double CestovniRychlost { get; set; }
        public double DelkaTrasy { get; set; }

        public AutonomniAuto(double cestovnirychlost, double delkatrasy)
        {
            CestovniRychlost = cestovnirychlost;
            DelkaTrasy = delkatrasy;

        }

    }
    public class RidiciStredisko
    {
        public delegate void ZmenaPocasi();
        public delegate void ZmenaTrasy();
    }
    public class MeteorologickaStanice
    {
        public int Zmena()
        {
            Random nc = new Random();

            return nc.Next(weather);
        }
    }

    public enum Trasa
    {
        Cesta = 1,
        Most,
        Tunel
    }

    public enum weather
    {
        Clear = 1,
        Rain,
        Winter,
        Storm
    }
   
}
