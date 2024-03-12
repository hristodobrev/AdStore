using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.Category;
using AS.ApplicationServices.ResponseModels.Category;
using AS.Data.Context;
using AS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AS.ApplicationServices.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly AdStoreDbContext _dbContext;
        public CategoryService(AdStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(CreateCategoryRequestModel model)
        {
            var category = new Category
            {
                Name = model.Name,
                RatingGained = model.RatingGained,
                RequiredRating = model.RequiredRating,
                IsRequiringPremium = model.IsRequiringPremium
            };

            this._dbContext.Categories.Add(category);

            await this._dbContext.SaveChangesAsync();

            return category.Id;
        }

        public async Task<IEnumerable<GetCategoryResponseModel>> GetAllAsync()
        {
            var categories = await this._dbContext.Categories.ToListAsync();

            var response = new List<GetCategoryResponseModel>();
            foreach (var category in categories)
            {
                response.Add(new GetCategoryResponseModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    RatingGained = category.RatingGained,
                    RequiredRating = category.RequiredRating,
                    IsRequiringPremium = category.IsRequiringPremium,
                    DateCreated = category.DateCreated
                });
            }

            return response;
        }

        public async Task<GetCategoryResponseModel?> GetByIdAsync(int id)
        {
            var category = await this._dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);

            GetCategoryResponseModel response = null;
            if (category != null)
            {
                response = new GetCategoryResponseModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    RatingGained = category.RatingGained,
                    RequiredRating = category.RequiredRating,
                    IsRequiringPremium = category.IsRequiringPremium,
                    DateCreated = category.DateCreated
                };
            }

            return response;
        }

        public async Task UpdateAsync(UpdateCategoryRequestModel model)
        {
            var category = await this._dbContext.Categories.SingleOrDefaultAsync(c => c.Id == model.Id);

            if (category != null)
            {
                category.Name = model.Name;
                category.RatingGained = model.RatingGained;
                category.RequiredRating = model.RequiredRating;
                category.IsRequiringPremium = model.IsRequiringPremium;

                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var category = await this._dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                this._dbContext.Categories.Remove(category);

                await this._dbContext.SaveChangesAsync();
            }
        }
    }
}
