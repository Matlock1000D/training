using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using webkikkailu.Models;

namespace webkikkailu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilipaliController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<Customers> ListAll()
        {
            NorthwindContext northwindContext = new NorthwindContext();
            List<Customers> all = northwindContext.Customers.ToList();
            return all;
        }

        [HttpGet]
        [Route("{id}")]
        public Customers ListOne(string id)
        {
            NorthwindContext northwindContext = new NorthwindContext();
            Customers customer = (from c in northwindContext.Customers
                                 where c.CustomerId == id
                                 select c).FirstOrDefault();

            //Customers asiakas2 = northwindContext.Customers.Find(id);

            return customer;
        }

        [HttpPost]
        [Route("")]
        public bool AddNew(Customers newCustomer)
        {
            NorthwindContext northwindContext = new NorthwindContext();
            northwindContext.Customers.Add(newCustomer);

            northwindContext.SaveChanges();
            return true;
        }

        [HttpDelete]
        [Route("")]
        public string RemoveCustomers()
        {
            return "Leikitään, että poistin kaikki asiakkaat!";
        }
    }
}