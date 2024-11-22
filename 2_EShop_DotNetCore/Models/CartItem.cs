using System.Security.Principal;

namespace Shop_DotNetCore.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal getTotalPrice()
        {
            

            decimal totalPrice = Quantity * Item.Price;

            return totalPrice;

        }
        

    }
}
