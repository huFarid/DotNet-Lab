using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NuGet.Protocol;
using Shop_DotNetCore.Data;
using Shop_DotNetCore.Data.Repositories;
using Shop_DotNetCore.Models;

namespace Shop_DotNetCore.Controllers
{
    public class AccountController : Controller
    {

        private IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Register ()
        {
             
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if(!ModelState.IsValid)
            {
                return View(register);
            }

            if(_userRepository.IsExistUserByEmail( register.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "The email adress already exists.");
                return View(register);
            }
            else
            {
                Users user = new Users()
                {
                    Email = register.Email,
                    Password = register.Password,
                    IsAdmin = false,
                    RegisterDate = DateTime.Now
                };

                _userRepository.AddUser(user);

                return View("SuccessfulRegistration", register);
            }

        }

    }
}
