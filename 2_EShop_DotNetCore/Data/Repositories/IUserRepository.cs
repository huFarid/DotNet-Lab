using Microsoft.AspNetCore.Connections;
using Shop_DotNetCore.Models;

namespace Shop_DotNetCore.Data.Repositories
{
    public interface IUserRepository
    {

         bool IsExistUserByEmail(string Email);
         void AddUser(Users user);
    }


    public class UserRepository : IUserRepository
    {
        private MyEshopContext _context;

        public UserRepository( MyEshopContext context)
        {
            _context = context;
            
        }


        public bool IsExistUserByEmail(string Email)
        {
            return _context.Users.Any(u => u.Email == Email);
        }

        public void AddUser(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }
    }


}
