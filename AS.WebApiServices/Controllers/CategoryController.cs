using AS.ApplicationServices.RequestModels.Category;
using AS.Data.Context;
using AS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AS.WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AdStoreDbContext _dbContext;
        public CategoryController(AdStoreDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryRequestModel model)
        {
            this._dbContext.Categories.Add(new Category
            {
                Name = model.Name,
                RatingGained = model.RatingGained,
                RequiredRating = model.RequiredRating,
                IsRequiringPremium = model.IsRequiringPremium,
                DateCreated = DateTime.Now
            });

            this._dbContext.SaveChanges();

            return Ok();
        }
    }
}
