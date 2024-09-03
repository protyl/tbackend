using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.Models;
using api.DTOs.Product;
namespace api.Mappers
{
    
        public static class ProductMapper
        {
            public static ProductDTO ToProductDTO(this Product SomeProduct)
            {
                return new ProductDTO
                {
                    productName = SomeProduct.productName,
                    Pid = SomeProduct.Pid
                };
            }

            public static Product ToProductFromCreateDTO(this CreateProductRequestDTO ProductDTO)
            {
                return new Product
                {
                    productName = ProductDTO.productName,
                    price = ProductDTO.price,
                    stock = ProductDTO.stock,
                    descripetion = ProductDTO.descripetion
                };
            }
        }

    
}
