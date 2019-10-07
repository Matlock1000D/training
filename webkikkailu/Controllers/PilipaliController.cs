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
        [Route("moi")]
        public double SanoMoi()
        {
            return 1.1;
        }

        [Route("uliuli")]
        public int Ulise()
        {
            return 1;
        }
    }
}