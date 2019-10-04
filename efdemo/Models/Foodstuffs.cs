using System;
using System.Collections.Generic;

namespace efdemo.Models
{
    public partial class Foodstuffs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Longevity { get; set; }
        public double? UnitPrice { get; set; }
        public string DefUnit { get; set; }
    }
}
