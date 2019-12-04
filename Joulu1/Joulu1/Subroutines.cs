using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Joulu1
{
    partial class Program
    {
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
