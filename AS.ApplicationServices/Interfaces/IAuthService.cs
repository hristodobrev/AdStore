using AS.ApplicationServices.RequestModels.Auth;
using AS.ApplicationServices.ResponseModels.Auth;

namespace AS.ApplicationServices.Interfaces
{
    public interface IAuthService
    {
        Task<AuthServiceModel> Login(LoginRequestModel model);
        Task<AuthServiceModel> Register(RegisterRequestModel model);
    }
}
