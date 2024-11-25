using Microsoft.AspNetCore.Mvc;
using Shop_DotNetCore.Data;

namespace Shop_DotNetCore.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private MyEshopContext _context;

        public ProductGroupsComponent(MyEshopContext context)
        {
            _context = context;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("/Views/Components/ProductGroupsComponent.cshtml", _context.Categories);
        }

    }
}
