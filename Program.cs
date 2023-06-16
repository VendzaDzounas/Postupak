using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Banka
    {
        public List<UcetStandart> StandartniUcty = new List<UcetStandart>();
        public List<UcetPremium> PremioveUcty = new List<UcetPremium>();
        private string jmenobanky;
        private int pocetuctu;

        public Banka(string JmenoBanky)
        {
            jmenobanky = JmenoBanky;
            pocetuctu = StandartniUcty.Count + PremioveUcty.Count;
        }
        public string GetJmenoBanky()
        {
            return jmenobanky;
        }
        public void SetJmenoBanky(string JmenoBanky)
        {
            jmenobanky = JmenoBanky;
        }
        public int GetPocetUctu()
        {
            return pocetuctu;
        }
        public void SetPocetUctu(int PocetUctu)
        {
            pocetuctu = PocetUctu;
        }
        public void VypisUctuStandart()
        {
            for(int i = 0; i <  StandartniUcty.Count; i++)
            {
                Console.WriteLine("Vlastník účtu: " + StandartniUcty[i].GetJmenoVlastnika() + " | Zůstatek: " + StandartniUcty[i].GetZustatek());
            }
        }
        public void VypisUctuPremium()
        {
            for (int i = 0; i < PremioveUcty.Count; i++)
            {
                Console.WriteLine("Vlastník účtu: " + PremioveUcty[i].GetJmenoVlastnika() + " | Zůstatek: " + PremioveUcty[i].GetZustatek() + " | Prémiové body: " + PremioveUcty[i].GetPremioveBody());
            }
        }
    }
    abstract class Ucet
    {
        protected string jmenovlastnika;
        protected double zustatek;

        public Ucet(string JmenoVlastnika, double Zustatek)
        {
            jmenovlastnika = JmenoVlastnika;
            zustatek = Zustatek;
        }
        public void Vklad(double Vklad)
        {
            zustatek += Vklad;
        }
        public void Vyber(double Vyber)
        {
            zustatek -= Vyber;
        }
        public string GetJmenoVlastnika()
        {
            return jmenovlastnika;
        }
        public void SetJmenoVlastnika(string JmenoVlastnika)
        {
            jmenovlastnika = JmenoVlastnika;
        }
        public double GetZustatek()
        {
            return zustatek;
        }
        public void SetZustatek(double Zustatek)
        {
            zustatek = Zustatek;
        }
    }
    class UcetStandart : Ucet
    {
        public UcetStandart(string JmenoVlastnika, double Zustatek) : base (JmenoVlastnika, Zustatek)
        {
            jmenovlastnika = JmenoVlastnika;
            zustatek = Zustatek;
        }
    }
    class UcetPremium : UcetStandart
    {
        private int premiovebody;

        public UcetPremium(string JmenoVlastnika, double Zustatek, int PremioveBody) : base(JmenoVlastnika, Zustatek)
        {
            jmenovlastnika = JmenoVlastnika;
            zustatek = Zustatek;
            premiovebody = PremioveBody;
        }
        public int GetPremioveBody()
        {
            return premiovebody;
        }
        public void SetPremioveBody(int PremioveBody)
        {
            premiovebody = PremioveBody;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Banka banka1 = new Banka("NE");

            UcetStandart ucet1 = new UcetStandart("Venca", 5000000);
            UcetStandart ucet2 = new UcetStandart("Jonáš", 1000000);
            UcetStandart ucet3 = new UcetStandart("Josef", 500000);

            UcetPremium ucet4 = new UcetPremium("Tereza", 1000000, 750);
            UcetPremium ucet5 = new UcetPremium("Antonín", 2000000, 500);
            UcetPremium ucet6 = new UcetPremium("Jana", 25000000, 200);

            banka1.StandartniUcty.Add(ucet1);
            banka1.StandartniUcty.Add(ucet2);
            banka1.StandartniUcty.Add(ucet3);

            banka1.PremioveUcty.Add(ucet4);
            banka1.PremioveUcty.Add(ucet5);
            banka1.PremioveUcty.Add(ucet6);

            banka1.VypisUctuStandart();
            Console.WriteLine();
            banka1.VypisUctuPremium();

            ucet1.Vklad(10000000);
            Console.WriteLine();

            banka1.VypisUctuStandart();
        }
    }
}