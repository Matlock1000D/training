using System;
using efdemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace efdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] luvut = {2,4,66,7,3,88,3,2,6,78,3,2,2,2};

            List<int> huippuluvut = (from l in luvut
            where l> 5
            orderby l
            select l).ToList();

            foreach (int huippuluku in huippuluvut) Console.WriteLine(huippuluku);

/* 

            int lkm = 0;
            NorthwindContext northwindContext = new NorthwindContext();
            lkm = northwindContext.Customers.Count();

            Console.WriteLine(lkm);

            List<Customers> customers = northwindContext.Customers.ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ContactName);
            }

            // haetaan suomalaiset asiakkaat
            Console.WriteLine("==* Hakkaa päälle! *==");
            customers.Clear();
            customers =  northwindContext.Customers.Where(c => c.Country == "Sweden").ToList();

             Console.WriteLine(customers.Count());

             foreach (var customer in customers)
            {
                Console.WriteLine(customer.ContactName);
            }

            return;
*/
        }
    }
}
