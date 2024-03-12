using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.Ad;
using AS.ApplicationServices.ResponseModels.Ad;
using AS.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AS.ApplicationServices.Implementations
{
    public class AdService : IAdService
    {
        private readonly AdStoreDbContext _dbContext;
        public AdService(AdStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<int> CreateAsync(CreateAdRequestModel model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetAdResponseModel>> GetAllAsync()
        {
            var ads = await this._dbContext.Ads.Include(a => a.Category).Include(a => a.User).ToListAsync();

            var response = new List<GetAdResponseModel>();
            if (ads != null)
            {
                foreach (var item in ads)
                {
                    response.Add(new GetAdResponseModel
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Description = item.Description,
                        IsActive = item.IsActive,
                        IsSold = item.IsSold,
                        Price = item.Price,
                        DateCreated = item.DateCreated,
                        CategoryName = item.Category != null ? item.Category.Name : "Unknown",
                        Town = item.User != null ? item.User.Town : "Unknown",
                        Username = item.User != null ? item.User.Username : "Unknown",
                    });
                }
            }

            return response;
        }

        public async Task<GetAdResponseModel?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UpdateAdRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
