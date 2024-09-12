using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.DTO
{
    public class StockUpdateRequestDto
    {
        [Required]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        public decimal Purchase { get; set; }
        [Required]
        public decimal LastDiv { get; set; }
        [Required]
        public string Industry { get; set; } = string.Empty;
        [Required]
        public long MarcketCap { get; set; }
    }
}