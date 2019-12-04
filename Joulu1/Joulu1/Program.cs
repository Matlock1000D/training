using System;
using System.IO;

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
                default:
                    Console.WriteLine("Anna kunnon päivä");
                    break;
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
