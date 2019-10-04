using System;
using System.Collections.Generic;

namespace efdemo.Models
{
    public partial class Recipes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public string Ingredients { get; set; }
        public int? ReqTime { get; set; }
        public int? TypeFlags { get; set; }
        public int? Persons { get; set; }
        public string Url { get; set; }
    }
}
