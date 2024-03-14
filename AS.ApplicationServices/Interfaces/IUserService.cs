using AS.ApplicationServices.RequestModels.User;
using AS.ApplicationServices.ResponseModels.User;

namespace AS.ApplicationServices.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateAsync(CreateUserRequestModel model);
        Task<GetUserResponseModel?> GetByIdAsync(int id);
        Task<IEnumerable<GetUserResponseModel>> GetAsync(string? name = null, int page = 0, int pageSize = 20);
        Task UpdateAsync(UpdateUserRequestModel model);
        Task PatchAsync(PatchUserRequestModel model);
        Task DeleteAsync(int id);
    }
}
