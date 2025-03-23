using Microsoft.AspNetCore.Identity;
using Rental_Vehicle.Models;
using Rental_Vehicle.Repository;

namespace Rental_Vehicle.Service
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IdentityResult> RegisterUser(User user, string password)
        {
            var addedUser = await _userRepository.RegisterUser(user, password);
            return addedUser;
        }

        //public async Task<User> GetUserById(int id)
        //{
        //    var user = await _userRepository.GetUserById(id);
        //    return user;
        //}



    }
}
