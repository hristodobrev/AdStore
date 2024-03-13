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
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(model.Password, 13),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Town = model.Town,
                IsPremium = model.IsPremium
            };

            await this._dbContext.Users.AddAsync(user);

            await this._dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<IEnumerable<GetUserResponseModel>> GetAsync(string? name = null, int page = 0, int pageSize = 20)
        {
            IQueryable<User> query = this._dbContext.Users;
            if (name != null)
                query = query.Where(u =>
                    u.FirstName != null && u.FirstName.ToLower().Contains(name.ToLower()) ||
                    u.LastName != null && u.LastName.ToLower().Contains(name.ToLower())
                );

            var users = await query.Skip(page * pageSize).Take(pageSize).ToListAsync();

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
                user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(model.Password, 13);
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

        public async Task<User?> Login(string username, string password)
        {
            var user = await this._dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);

            if (user != null && BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password))
            {
                return user;
            }

            return null;
        }
    }
}
