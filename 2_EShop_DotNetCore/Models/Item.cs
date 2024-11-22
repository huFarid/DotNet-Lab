using Microsoft.AspNetCore.Authentication;

namespace Shop_DotNetCore.Models
{
    public class Item
    {

        public int ID { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
       public int QuantityInStock { get; set; }

        public Product Product { get; set; }





    }
}
