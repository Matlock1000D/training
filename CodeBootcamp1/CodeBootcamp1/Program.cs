using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CodeBootcamp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fibo = new int[3];
            fibo[0] = 0;
            fibo[1] = 1;
            fibo[2] = 1;
            while(true)
            {
                Console.WriteLine($"{fibo[2]}");
                Console.ReadLine();
                fibo[2] = fibo[0] + fibo[1];
                fibo[0] = fibo[1];
                fibo[1] = fibo[2];
            }           
        }
    }
}
