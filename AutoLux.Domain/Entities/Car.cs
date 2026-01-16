using AutoLux.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLux.Domain.Entities
{
    public class Car:BaseEntity
    {
     
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsForSale { get; set; }
        public bool IsForRent { get; set; }
    }
}
