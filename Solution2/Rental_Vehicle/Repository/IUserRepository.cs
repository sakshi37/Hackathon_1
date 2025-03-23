using Microsoft.AspNetCore.Identity;
using Rental_Vehicle.Models;

namespace Rental_Vehicle.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUser(User user, string password);

        //Task<User> GetUserById(int id);

    }
}

