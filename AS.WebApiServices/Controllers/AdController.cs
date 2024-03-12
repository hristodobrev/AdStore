using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.Ad;
using AS.ApplicationServices.ResponseModels.Ad;
using Microsoft.AspNetCore.Mvc;

namespace AS.WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly IAdService _service;
        public AdController(IAdService service)
        {
            this._service = service;
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
            await this._service.CreateAsync(model);

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
            var ad = await this._service.GetByIdAsync(id);
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
        public async Task<IActionResult> Get()
        {
            var ads = await this._service.GetAllAsync();

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
            await this._service.UpdateAsync(model);

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
            await this._service.DeleteAsync(id);

            return NoContent();
        }
    }
}
