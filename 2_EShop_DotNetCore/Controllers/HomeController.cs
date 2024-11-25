using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_DotNetCore.Data;
using Shop_DotNetCore.Models;
using System.Diagnostics;

namespace Shop_DotNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyEshopContext _context;

        private static Card _card = new Card();

        public HomeController(ILogger<HomeController> logger, MyEshopContext context)
        {
            _logger = logger;
            _context = context;
        }

 
        public IActionResult Detail(int id)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.Id == id);
            if (product == null) {
                return NotFound(); }

            var categories = _context.Products
                .Where(i => i.Id == id)
                .SelectMany(p => p.CategoryToProducts)
                .Select(ca => ca.Category)
                .ToList();

            var vm = new DetailsViewModel()
            {
                Product = product,
                Categories = categories
            };
                
            return View(vm);
        }


        public IActionResult AddToCard(int ItemId)
        {
            var cartVM = new CartViewModel();
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemID == ItemId);

            if (product != null) 
            {
                var cardItem = new CartItem()
                {
                    Item = product.Item,
                    Quantity = 1
                };
                _card.addItem(cardItem);
            }


            return RedirectToAction("ShowCard");
        }

        public IActionResult RemoveItem(int ItemId)
        {

            _card.removeItem(ItemId);
             return RedirectToAction("ShowCard");
        }

        public IActionResult ShowCard()
        {
            var cartVM = new CartViewModel()
            {
                CartItems = _card.CardItems,
                OrderTotal = _card.CardItems.Sum(c=>c.getTotalPrice())

            }; 
            return View(cartVM); 
        }


        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [Route("/ContactUs")]

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
