using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Product
{
	public class ProductDTO
	{
        public int Pid { get; set; }
        public string productName { get; set; } = string.Empty;
    }

}