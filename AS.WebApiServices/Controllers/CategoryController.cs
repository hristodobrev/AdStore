using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.Category;
using AS.ApplicationServices.ResponseModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace AS.WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateAdRequestModel model)
        {
            await this._service.CreateAsync(model);

            return Created();
        }

        /// <summary>
        /// Returns a category searched by id
        /// </summary>
        /// <param name="id">Search category by id</param>
        /// <returns>Category</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetCategoryResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var category = await this._service.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        /// <summary>
        /// Returns all categories
        /// </summary>
        /// <returns>Category</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<GetCategoryResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var categories = await this._service.GetAllAsync();

            return Ok(categories);
        }

        /// <summary>
        /// Updates a category by given id. If the category is not found it does nothing
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(UpdateAdRequestModel model)
        {
            await this._service.UpdateAsync(model);

            return NoContent();
        }

        /// <summary>
        /// Deletes a category by given id. If the category is not found it does nothing
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await this._service.DeleteAsync(id);

            return NoContent();
        }
    }
}
