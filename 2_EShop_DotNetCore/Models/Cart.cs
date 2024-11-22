using System.Security.Cryptography.X509Certificates;

namespace Shop_DotNetCore.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public int OrderID { get; set; }

        public List<CartItem> CartItems { get; set; }

        public void addItem(CartItem Item)
        {
            if(CartItems.Exists(i => i.Item.ID == Item.Id))
            {
                CartItems.Find(i => i.Item.ID == Item.Id).Quantity += 1;
                
            }
            else
            {
                CartItems.Add(Item);
            }




            
            
        }


        public void removeItem(CartItem Item)
        {

            var item = CartItems.Find(i => i.Item.ID == Item.Id);

            if(item.Quantity <=1 )
            {
                CartItems.Remove(Item);

            }
            else if(item != null)
            {
                item.Quantity -= 1;
            }

            

          

        }

    }
}
