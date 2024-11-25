using System.Security.Cryptography.X509Certificates;

namespace Shop_DotNetCore.Models
{
    public class Card
    {
        public Card()
        {
            CardItems = new List<CartItem>();
        }
        public int OrderID { get; set; }

        public List<CartItem> CardItems { get; set; }

        public void addItem(CartItem item)
        {
            if(CardItems.Exists(i => i.Item.ID == item.Item.ID))
            {
                CardItems.Find(i => i.Item.ID == item.Item.ID).Quantity += 1; 
            }
            else
            {
                CardItems.Add(item);
            }

        }

        public void removeItem(int ItemId)
        {
            var item = CardItems.SingleOrDefault(i => i.Item.ID == ItemId);

            if(item?.Quantity <=1 )
            {
                CardItems.Remove(item);
            }
            else if(item != null)
            {
                item.Quantity -= 1;
            }
        }
    }
}
