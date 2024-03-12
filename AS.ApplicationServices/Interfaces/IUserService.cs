using AS.ApplicationServices.RequestModels.User;
using AS.ApplicationServices.ResponseModels.User;

namespace AS.ApplicationServices.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateAsync(CreateUserRequestModel model);
        Task<GetUserResponseModel?> GetByIdAsync(int id);
        Task<IEnumerable<GetUserResponseModel>> GetAllAsync();
        Task UpdateAsync(UpdateUserRequestModel model);
        Task DeleteAsync(int id);
    }
}
