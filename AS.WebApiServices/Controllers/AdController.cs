using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.Ad;
using AS.ApplicationServices.ResponseModels.Ad;
using AS.ApplicationServices.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AS.WebApiServices.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly IAdService _adService;
        private readonly ICategoryService _categoryService;
        public AdController(IAdService adService, ICategoryService categoryService)
        {
            this._adService = adService;
            this._categoryService = categoryService;
        }

        /// <summary>
        /// Creates an Ad
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(CreateAdRequestModel model)
        {
            var category = await this._categoryService.GetByIdAsync(model.CategoryId);
            if (category == null)
                return BadRequest("This Category does not exist");

            if (category.RequiredRating > User.GetRating())
                return BadRequest("This user does not have the required rating to publish ad to this category.");

            if (category.IsRequiringPremium && !User.GetIsPremium())
                return BadRequest("This user must be premium to publish ad to this category.");

            await this._adService.CreateAsync(model, User.GetUserId());

            return Created();
        }

        /// <summary>
        /// Returns an ad searched by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetAdResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var ad = await this._adService.GetByIdAsync(id);
            if (ad == null)
            {
                return NotFound();
            }

            return Ok(ad);
        }

        /// <summary>
        /// Returns all ads
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAdResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string? keyword = null, decimal minPrice = 0, decimal maxPrice = 0, int page = 0, int pageSize = 20)
        {
            var ads = await this._adService.GetAsync(keyword, minPrice, maxPrice, page, pageSize);

            return Ok(ads);
        }

        /// <summary>
        /// Updates an ad by given id. If the ad is not found it does nothing
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(UpdateAdRequestModel model)
        {
            await this._adService.UpdateAsync(model);

            return NoContent();
        }

        /// <summary>
        /// Updates an ad as sold or not
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Patch(PatchAdRequestModel model)
        {
            await this._adService.PatchAsync(model);

            return NoContent();
        }

        /// <summary>
        /// Deletes an ad by given id. If the ad is not found it does nothing
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await this._adService.DeleteAsync(id);

            return NoContent();
        }
    }
}