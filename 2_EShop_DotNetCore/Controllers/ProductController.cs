using Microsoft.AspNetCore.Mvc;
using Shop_DotNetCore.Data;

namespace Shop_DotNetCore.Controllers
{
    public class ProductController : Controller
    {
        public MyEshopContext _context;


        public ProductController(MyEshopContext context)
        {
            _context = context;
        
        }

        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId( int id, string name)
        {
            ViewData["GroupName"] = name;
            var products = _context.CategoryToProducts
                .Where(c => c.CategoryId == id)
                .Select(c => c.Product)
                .ToList();
            return View(products);
        }
    }
}
