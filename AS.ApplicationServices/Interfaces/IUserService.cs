using AS.ApplicationServices.RequestModels.User;
using AS.ApplicationServices.ResponseModels.User;

namespace AS.ApplicationServices.Interfaces
{
    public interface IUserService
    {
        int CreateAsync(CreateUserRequestModel model);
        Task<GetUserResponseModel> GetByIdAsync(int id);
        Task<IEnumerable<GetUserResponseModel>> GetAllAsync();
        void UpdateAsync(UpdateUserRequestModel model);
        void DeleteAsync(int id);
    }
}
