using Microsoft.AspNetCore.Mvc;
using Rental_Vehicle.Models;
using Rental_Vehicle.Service;

namespace Rental_Vehicle.Controllers
{
    public class UserController : Controller
    {
        public IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(User user, string password)
        {
            var result = await _userService.RegisterUser(user, password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("RegisterUser", user);

        }

        //public async Task<IActionResult> GetUserById(int id)
        //{
        //    var user = await _userService.GetUserById(id);
        //    return View(user);

        //}


    }
}
