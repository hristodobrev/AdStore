using AS.ApplicationServices.RequestModels.User;
using AS.ApplicationServices.ResponseModels.User;
using AS.Data.Entities;

namespace AS.ApplicationServices.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateAsync(CreateUserRequestModel model);
        Task<GetUserResponseModel?> GetByIdAsync(int id);
        Task<IEnumerable<GetUserResponseModel>> GetAsync(string? name = null, int page = 0, int pageSize = 20);
        Task UpdateAsync(UpdateUserRequestModel model);
        Task DeleteAsync(int id);
        Task<User?> Login(string username, string password);
    }
}
