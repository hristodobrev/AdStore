using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.Auth;
using AS.ApplicationServices.ResponseModels.Auth;
using AS.Data.Context;
using AS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AS.ApplicationServices.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly AdStoreDbContext _dbContext;
        public AuthService(AdStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<AuthResponseModel> Login(LoginRequestModel model)
        {
            var user = await this._dbContext.Users.SingleOrDefaultAsync(u => u.Username == model.Username);

            if (user != null && BCrypt.Net.BCrypt.EnhancedVerify(model.Password, user.Password))
            {
                return new AuthResponseModel
                {
                    Id = user.Id,
                    IsAdmin = user.IsAdmin,
                    IsPremium = user.IsPremium,
                    Rating = user.Rating
                };
            }

            throw new InvalidOperationException("Invalid username or password.");
        }

        public async Task<AuthResponseModel> Register(RegisterRequestModel model)
        {
            bool existingUser = await this._dbContext.Users.AnyAsync(u => u.Username == model.Username);

            if (existingUser)
                throw new InvalidOperationException("User with that username already exist.");

            var user = new User
            {
                Username = model.Username,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(model.Password, 13),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Town = model.Town,
            };

            await this._dbContext.Users.AddAsync(user);

            await this._dbContext.SaveChangesAsync();

            return new AuthResponseModel
            {
                Id = user.Id,
                IsAdmin = user.IsAdmin,
                IsPremium = user.IsPremium,
                Rating = user.Rating
            };
        }
    }
}
