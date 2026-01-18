using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLux.Application.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Marka yazılmalıdır!")]
        public string Brand { get; set; }
        public string Model { get; set; }
        [Range(0, 1000000, ErrorMessage = "Qiymət düzgün deyil!")]
        public decimal Price { get; set; }
        [Range(1900, 2026, ErrorMessage = "İl düzgün deyil")]
        public int Year { get; set; }
        public string Category { get; set; } 
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public bool IsForSale { get; set; }
        public bool IsForRent { get; set; }
    }
}
