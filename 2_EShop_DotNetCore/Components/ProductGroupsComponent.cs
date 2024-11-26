using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Shop_DotNetCore.Data;
using Shop_DotNetCore.Data.Repositories;
using Shop_DotNetCore.Models;

namespace Shop_DotNetCore.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private IGroupRepository _groupRepository;

        public ProductGroupsComponent( IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
            
            
        }
        //private MyEshopContext _context;

        //public ProductGroupsComponent(MyEshopContext context)
        //{
        //    _context = context;

        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var categories = _context.Categories
            //    .Select(c => new ShowGroupViewModel()
            //    {
            //        GroupId = c.Id,
            //        Name = c.Name,
            //        ProductCount = _context.CategoryToProducts.Count(g => g.CategoryId == c.Id)


            //    }).ToList();

            return View("/Views/Components/ProductGroupsComponent.cshtml", _groupRepository.GetGroupForShow());
        }
    }
}
