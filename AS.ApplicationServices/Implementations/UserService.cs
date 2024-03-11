using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.User;
using AS.ApplicationServices.ResponseModels.User;
using AS.Data.Context;
using AS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AS.ApplicationServices.Implementations
{
    public class UserService : IUserService
    {
        private readonly AdStoreDbContext _dbContext;
        public UserService(AdStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> CreateAsync(CreateUserRequestModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Town = model.Town,
                IsPremium = model.IsPremium
            };

            this._dbContext.Users.Add(user);

            await this._dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<IEnumerable<GetUserResponseModel>> GetAllAsync()
        {
            var users = await this._dbContext.Users.ToListAsync();

            var response = new List<GetUserResponseModel>();
            foreach (var user in users)
            {
                response.Add(new GetUserResponseModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                    Town = user.Town,
                    IsPremium = user.IsPremium,
                    Rating = user.Rating,
                    DateCreated = user.DateCreated
                });
            }

            return response;
        }

        public async Task<GetUserResponseModel?> GetByIdAsync(int id)
        {
            var user = await this._dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            GetUserResponseModel? response = null;

            if (user != null)
            {
                response = new GetUserResponseModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                    Town = user.Town,
                    IsPremium = user.IsPremium,
                    Rating = user.Rating,
                    DateCreated = user.DateCreated
                };
            }

            return response;
        }

        public async Task UpdateAsync(UpdateUserRequestModel model)
        {
            var user = await this._dbContext.Users.SingleOrDefaultAsync(u => u.Id == model.Id);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Password = model.Password;
                user.Age = model.Age;
                user.Town = model.Town;
                user.IsPremium = model.IsPremium;

                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var user = await this._dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user != null)
            {
                this._dbContext.Users.Remove(user);

                await this._dbContext.SaveChangesAsync();
            }
        }
    }
}
