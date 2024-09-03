using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Product
{
    public class UpdateProductRequestDTO
    {
        public string productName { get; set; } = string.Empty;
        public string descripetion { get; set; } = string.Empty;
        public int price { get; set; }

        public int stock { get; set; }
    }
}