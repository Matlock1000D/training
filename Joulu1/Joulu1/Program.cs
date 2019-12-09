using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Joulu1
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayselect = 0;
            string inputstring;

            Console.WriteLine("Minkä päivän koodi ajetaan?");
            inputstring = Console.ReadLine();
            dayselect = Int32.Parse(inputstring);

            switch (dayselect)
            {
                case 1:
                    Day1();
                    break;
                case 2:
                    Day2();
                    break;
                default:
                    Console.WriteLine("Anna oikea päivä");
                    break;
            }

        }

        static void Day2()          //Päivän tehtävät, kokonaislukutietokone
        {
            int commandpointer = 0;                                         //pointteri siihen kohtaan komentotaulukkoa mistä koodi ajetaan

            using (var sr = new StreamReader(@"data\Joulu2.txt"))          //avataan syötetiedosto
            {
                string lines = File.ReadAllText(@"data\Joulu2.txt");        //luetaan teksti
                string[] integerStrings = lines.Split(',');
                List<int> intops = new List<int>();

                foreach (string integerString in integerStrings)            //teksti listaksi kokonaislukuja
                {
                    intops.Add(Int32.Parse(integerString));
                }

                int[] intopsArray = intops.ToArray();                       //ja komentokoodi taulukoksi käsittelyn helpottamiseksi

                while (intopsArray[commandpointer] != 99)
                {
                    switch (intopsArray[commandpointer])
                    {
                        case 1:             //lasketaan commandpointer +1 ja commandopointer +2 -paikassa olevat luvut yhteen, sijoitetaan paikkaan commandpointer +3
                            intopsArray[intopsArray[commandpointer + 3]] = intopsArray[intopsArray[commandpointer + 1]] + intopsArray[intopsArray[commandpointer + 2]];
                            commandpointer += 4;
                            break;
                        case 2:               //kerrotaan commandpointer +1 ja commandopointer +2 -paikassa olevat luvut keskenään, sijoitetaan paikkaan commandpointer +3
                            intopsArray[intopsArray[commandpointer + 3]] = intopsArray[intopsArray[commandpointer + 1]] * intopsArray[intopsArray[commandpointer + 2]];
                            commandpointer += 4;
                            break;
                        default:
                            Console.WriteLine("Tukemattomia komentoja käytetty!");
                            break;
                    }
                }

                Console.WriteLine("Muistipaikassa 0 on luku " + intopsArray[0]);

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
