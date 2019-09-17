using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvaaLuku
{
    static class Constants
    {
        public const int MINNUM = 1;
        public const int MAXNUM = 20;
        public const int GUESSES = 5;
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int oikea = rnd.Next(Constants.MINNUM, Constants.MAXNUM+1);
            int arvaukset = Constants.GUESSES;
            string viesti;
            int arvaus = 0;

            do
            {
                Console.WriteLine("Arvaapa luku!");
                viesti = Console.ReadLine();
                try
                {
                    arvaus = Int32.Parse(viesti);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Anna nyt edes luku!");
                    continue;
                      
                }
                if (arvaus == oikea)
                {
                    Console.WriteLine("Oikein!");
                    return;
                }
                else if (arvaus < oikea) Console.WriteLine("Arvaus on liian pieni.");
                else Console.WriteLine("Arvaus on liian suuri.");

                if (arvaukset > 2) Console.WriteLine("Vielä " + (arvaukset - 1) + " arvausta jäljellä.");
                else Console.WriteLine("Viimeinen yritys!");

                arvaukset--;
            } while (arvaukset > 0);
            Console.WriteLine("Arvaukset loppuivat, oikea vastaus oli " + oikea);
        }
    }
}
