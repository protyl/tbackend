using System.ComponentModel.DataAnnotations;
namespace api.Models
{
    public class Product
    {
        [Key]
        public int Pid { get; set; }
        public int merchid { get; set; }
        public string productName { get; set; } = string.Empty;
        public string ProductName { get { return productName; } set { productName = value; } }
        public string descripetion { get; set; } = string.Empty; public string Description { get { return descripetion; } set { descripetion = value; } }
        public int price { get; set; }
        public int stock { get; set; }


    }
}