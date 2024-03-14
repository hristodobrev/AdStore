using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.Ad;
using AS.ApplicationServices.ResponseModels.Ad;
using AS.Data.Context;
using AS.Data.Entities;
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
        public async Task<int> CreateAsync(CreateAdRequestModel model, int userId)
        {
            var ad = new Ad
            {
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                IsActive = model.IsActive,
                IsSold = model.IsSold,
                CategoryId = model.CategoryId,
                UserId = userId
            };

            await this._dbContext.Ads.AddAsync(ad);

            await this._dbContext.SaveChangesAsync();

            return ad.Id;
        }

        public async Task<IEnumerable<GetAdResponseModel>> GetAsync(string? keyword = null, decimal minPrice = 0, decimal maxPrice = 0, int page = 0, int pageSize = 20)
        {
            IQueryable<Ad> query = this._dbContext.Ads;

            if (keyword != null)
                query = query.Where(a =>
                    a.Title.ToLower().Contains(keyword.ToLower()) ||
                    a.Description != null && a.Description.ToLower().Contains(keyword.ToLower())
                );

            if (minPrice > 0)
                query = query.Where(a => a.Price >= minPrice);

            if (maxPrice > 0)
                query = query.Where(a => a.Price <= maxPrice);

            var ads = await query.Include(a => a.Category)
                .Include(a => a.User)
                .ToListAsync();

            var response = new List<GetAdResponseModel>();
            if (ads != null)
            {
                foreach (var ad in ads)
                {
                    response.Add(new GetAdResponseModel
                    {
                        Id = ad.Id,
                        Title = ad.Title,
                        Description = ad.Description,
                        Price = ad.Price,
                        IsActive = ad.IsActive,
                        IsSold = ad.IsSold,
                        DateCreated = ad.DateCreated,
                        CategoryName = ad.Category != null ? ad.Category.Name : "Unknown",
                        Town = ad.User != null ? ad.User.Town : "Unknown",
                        Username = ad.User != null ? ad.User.Username : "Unknown",
                    });
                }
            }

            return response;
        }

        public async Task<GetAdResponseModel?> GetByIdAsync(int id)
        {
            var ad = await this._dbContext.Ads
                .Include(a => a.Category)
                .Include(a => a.User)
                .SingleOrDefaultAsync(a => a.Id == id);

            GetAdResponseModel? response = null;
            if (ad != null)
            {
                response = new GetAdResponseModel
                {
                    Id = ad.Id,
                    Title = ad.Title,
                    Description = ad.Description,
                    Price = ad.Price,
                    IsActive = ad.IsActive,
                    IsSold = ad.IsSold,
                    DateCreated = ad.DateCreated,
                    CategoryName = ad.Category != null ? ad.Category.Name : "Unknown",
                    Town = ad.User != null ? ad.User.Town : "Unknown",
                    Username = ad.User != null ? ad.User.Username : "Unknown",
                };
            }

            return response;
        }

        public async Task UpdateAsync(UpdateAdRequestModel model)
        {
            var ad = await this._dbContext.Ads.SingleOrDefaultAsync(a => a.Id == model.Id);

            if (ad != null)
            {
                ad.Title = model.Title;
                ad.Description = model.Description;
                ad.Price = model.Price;
                ad.IsActive = model.IsActive;
                ad.IsSold = model.IsSold;
                ad.CategoryId = model.CategoryId;

                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task PatchAsync(PatchAdRequestModel model)
        {
            var ad = await this._dbContext.Ads.SingleOrDefaultAsync(a => a.Id == model.Id);

            if (ad != null)
            {
                if (model.IsActive.HasValue)
                    ad.IsActive = model.IsActive.Value;

                if (model.IsSold.HasValue)
                    ad.IsSold = model.IsSold.Value;

                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var ad = await this._dbContext.Ads.SingleOrDefaultAsync(a => a.Id == id);

            if (ad != null)
            {
                this._dbContext.Ads.Remove(ad);

                await this._dbContext.SaveChangesAsync();
            }
        }
    }
}
