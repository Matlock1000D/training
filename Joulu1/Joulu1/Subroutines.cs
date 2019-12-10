using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Joulu1
{
    partial class Program
    {
        static int stepGetter(int[,] wiremap, int minx, int miny, int goalx, int goaly, List<string[]> stringdiffsList)     //laskee piuhojen stepit niin, että orgio on -minx, -miny:ssä, tarkastelupiste goalx,goaly:ssä 
        {
            //VARO, EI MITÄÄN VIRHEENTARKISTUSTA!

            int steps = 0;  //montako askelta on otettu?

            foreach (string[] stringdiffs in stringdiffsList)    //katsotaan, miten iso taulukko tarvitaan
            {
                int x = -minx, y = -miny;
                for (int i = 0; i < stringdiffs.Length; i++)       //käydään kaikki siirtokomennot läpi
                {
                    switch (stringdiffs[i].Substring(0, 1))
                    {
                        case "R":
                            for (int j = 0; j < Int32.Parse(stringdiffs[i].Substring(1)); j++)
                            {
                                x++;
                                steps++;
                                if (x == goalx && y == goaly) break;
                            }
                            break;
                        case "L":
                            for (int j = 0; j < Int32.Parse(stringdiffs[i].Substring(1)); j++)
                            {
                                x--;
                                steps++;
                                if (x == goalx && y == goaly) break;
                            }
                            break;
                        case "U":
                            for (int j = 0; j < Int32.Parse(stringdiffs[i].Substring(1)); j++)
                            {
                                y++;
                                steps++;
                                if (x == goalx && y == goaly) break;
                            }
                            break;
                        case "D":
                            for (int j = 0; j < Int32.Parse(stringdiffs[i].Substring(1)); j++)
                            {
                                y--;
                                steps++;
                                if (x == goalx && y == goaly) break;
                            }
                            break;
                        default:
                            break;
                    }
                    if (x == goalx && y == goaly) break;
                }

            }

                return steps;
        }
        static int runComputer(int[] intops)
        {
            int commandpointer = 0;

            while (intops[commandpointer] != 99)
            {
                switch (intops[commandpointer])
                {
                    case 1:
                        intops[intops[commandpointer + 3]] = intops[intops[commandpointer + 1]] + intops[intops[commandpointer + 2]];
                        break;
                    case 2:
                        intops[intops[commandpointer + 3]] = intops[intops[commandpointer + 1]] * intops[intops[commandpointer + 2]];
                        break;
                    default:
                        Console.WriteLine("Määrittelemättömiä käskyjä syötteessä!");
                        return -1;
                        break;
                }

                commandpointer += 4;
            }

            return intops[0];
        }

        static int[] initMemory()
        {
            string inputdata = File.ReadAllText(@"data\Joulu2.txt");
            string[] intopStrings = inputdata.Split(',');
            List<int> intopsList = new List<int>();
            

            foreach (string intopString in intopStrings)
            {
                intopsList.Add(Int32.Parse(intopString));
            }
            return intopsList.ToArray();
        }
    }
}
