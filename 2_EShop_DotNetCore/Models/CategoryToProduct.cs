using System.ComponentModel.DataAnnotations;

namespace Shop_DotNetCore.Models
{
    public class CategoryToProduct
    {

        [Key]

        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        // navigation property

        public Category Category { get; set; }
        public Product Product { get; set; }

    }
}
