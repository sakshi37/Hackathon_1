using Microsoft.AspNetCore.Identity;
using Rental_Vehicle.Models;

namespace Rental_Vehicle.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUser(User user, string password)
        {
            user.UserName = user.Email;
            //user.NormalizedEmail = user.Email.ToUpper();

            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        //public async Task<User> GetUserById(int id)
        //{
        //    var getUser = await _userManager..FirstOrDefaultAsync(a => a.UserId == id);
        //    return getUser;
        //}


    }
}
