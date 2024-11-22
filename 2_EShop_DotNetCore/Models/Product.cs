namespace Shop_DotNetCore.Models
{
    public class Product
    {

        //public Product()
        //{
        //    Categories = new List<Category>();
        //}

        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Category> Categories { get; set; }

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }

        public int ItemID { get; set; }

        public Item Item { get; set; }

        
        






    }
}
