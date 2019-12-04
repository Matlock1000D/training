using System;
using System.IO;
using System.Collections.Generic;

namespace Joulu1
{
    class Program
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
                default:
                    Console.WriteLine("Anna kunnon päivä!");
                    break;
            }
        }

        static void Day2()
        {
            string inputdata = File.ReadAllText(@"data\Joulu2.txt");
            string[] intopStrings = inputdata.Split(',');
            List<int> intopsList = new List<int>();
            int commandpointer = 0;

            foreach(string intopString in intopStrings)
            {
                intopsList.Add(Int32.Parse(intopString));
            }
            int[] intops = intopsList.ToArray();

            while(intops[commandpointer] != 99)
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
                        return;
                        break;
                }

                commandpointer += 4;
            }
            Console.WriteLine(intops[0]);
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
