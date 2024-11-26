﻿using Shop_DotNetCore.Models;

namespace Shop_DotNetCore.Data.Repositories
{
    public interface IGroupRepository
    {
        public IEnumerable<Category> GetAllCategories();
        public IEnumerable<ShowGroupViewModel> GetGroupForShow();
    }

    public class GroupRepository : IGroupRepository
    {
        private MyEshopContext _context;
        public GroupRepository( MyEshopContext context)
        {
            _context = context;
            
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public IEnumerable<ShowGroupViewModel> GetGroupForShow()
        {


          return  _context.Categories
                .Select(c => new ShowGroupViewModel()
                {
                    GroupId = c.Id,
                    Name = c.Name,
                    ProductCount = _context.CategoryToProducts.Count(g => g.CategoryId == c.Id)


                }).ToList();


        }
    }
}
