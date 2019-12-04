using System;
using System.IO;
using System.Collections.Generic;

namespace Joulu1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string dayString;
            
            Console.WriteLine("Valitse päivä");
            dayString = Console.ReadLine();

            switch (dayString)
            {
                case "1":
                    Day1();
                    break;
                case "2":
                    Day2();
                    break;
                case "3":
                    Day3();
                    break;
                default:
                    Console.WriteLine("Anna kunnon päivä!");
                    break;
            }
        }

        static void Day3()          //kolmospäivän ongelma, risteävät johdot
        {
            string[] inputdatas = File.ReadAllLines(@"data\Joulu3.txt");     //luetaan data muistiin
            List<string[]> stringdiffsList = new List<string[]>();
            foreach(string inputdata in inputdatas)
            {
                string[] stringdiffs = inputdata.Split(',');
            }

        }

        static void Day2()                      //intcode-ohjelma
        {
            int noun = 0, verb = 0;
            int[] intops = initMemory();        //pitää tehdä tässä, että saadaan taulukolle koko
            int result = 0;
            bool stopflag = false;              //lippu, joka kertoo onko oikeat verbi ja substantiivi löydetty

            //kakkostehtävän implementaatio
            Console.WriteLine("Ajetaanko kakkostehtävä? Vastaa ”k” jos ajetaan.");
            if (Console.ReadKey().Key == ConsoleKey.K)
            {
                for (noun = 0; noun < 100; noun++)
                {
                    for (verb = 0; verb < 100; verb++)
                    {
                        intops = initMemory();
                        intops[1] = noun;                   //noun ja verb muistipaikkoihin 1 ja 2
                        intops[2] = verb;
                        //seuraavaksi siirrä koneen toimintalogiikka omaan aliohjelmaansa
                        result = runComputer(intops);
                        if (result == 19690720) stopflag = true;
                        if (stopflag) break;
                    }
                    if (stopflag) break;
                }
                int answer = 100 * noun + verb;
                Console.WriteLine("Löytyi noun " + noun + " ja verb " + verb + ", vastaus siis " + answer);
                return;
            }
            else
            {
                result = runComputer(intops);
                Console.WriteLine(intops[0]);
            }
        }

            static void Day1()
        {
            string[] lines = File.ReadAllLines(@"data\Joulu1.txt");
            int totalfuel = 0;

            foreach (string line in lines)
            {
                int mass = Int32.Parse(line);
                int addfuel = mass;
                int modfuel = 0;
                do
                {
                    addfuel = addfuel / 3;
                    addfuel -= 2;
                    if (addfuel < 0) addfuel = 0;
                    modfuel += addfuel;
                } while (addfuel > 0);
                totalfuel += modfuel;
            }
            Console.WriteLine(totalfuel);
        }
    }
}
