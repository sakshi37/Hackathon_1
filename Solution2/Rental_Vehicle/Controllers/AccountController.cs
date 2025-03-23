using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rental_Vehicle.Context;
using Rental_Vehicle.Models;
using Rental_Vehicle.ViewModels;

namespace Rental_Vehicle.Controllers
{
    public class AccountController : Controller
    {
        public UserDbContext _context;
        public UserManager<User> _userManager;
        public SignInManager<User> _signInManger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, UserDbContext userdbcontext)
        {
            _context = userdbcontext;
            _userManager = userManager;
            _signInManger = signInManager;
        }
        public IActionResult Login()
        {
            var response = new LoginVC();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVC login)
        {
            if (!ModelState.IsValid) return View(login);
            var user = await _userManager.FindByEmailAsync(login.Email.ToUpper());
            Console.WriteLine("Loging", login.Email.ToString(), login.Password.ToString());

            if (user != null)
            {
                Console.WriteLine(user.Email, user.Password);
                var passCheck = await _userManager.CheckPasswordAsync(user, login.Password);
                if (passCheck)
                {
                    var result = await _signInManger.PasswordSignInAsync(user, login.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");

                    }
                }
                TempData["Error"] = "Wrong credentials Please try again";
                return View(login);
            }
            TempData["Error"] = "User not found";
            return View(login);



        }
    }
}
