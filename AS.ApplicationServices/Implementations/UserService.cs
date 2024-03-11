using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.User;
using AS.ApplicationServices.ResponseModels.User;

namespace AS.ApplicationServices.Implementations
{
    public class UserService : IUserService
    {
        public int CreateAsync(CreateUserRequestModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetUserResponseModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetUserResponseModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(UpdateUserRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
