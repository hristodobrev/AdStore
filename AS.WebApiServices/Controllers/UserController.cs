using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.User;
using AS.ApplicationServices.ResponseModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AS.WebApiServices.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
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
        public async Task<IActionResult> Create(CreateUserRequestModel model)
        {
            await this._service.CreateAsync(model);

            return Created();
        }

        /// <summary>
        /// Returns a user searched by id
        /// </summary>
        /// <param name="id">Search user by id</param>
        /// <returns>User</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetUserResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var user = await this._service.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns>User</returns>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<GetUserResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var users = await this._service.GetAllAsync();

            return Ok(users);
        }

        /// <summary>
        /// Updates a user by given id. If the user is not found it does nothing
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(UpdateUserRequestModel model)
        {
            await this._service.UpdateAsync(model);

            return NoContent();
        }

        /// <summary>
        /// Deletes a user by given id. If the user is not found it does nothing
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
