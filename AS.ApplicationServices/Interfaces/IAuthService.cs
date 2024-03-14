using AS.ApplicationServices.RequestModels.Auth;
using AS.ApplicationServices.ResponseModels.Auth;

namespace AS.ApplicationServices.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseModel> Login(LoginRequestModel model);
        Task<AuthResponseModel> Register(RegisterRequestModel model);
    }
}
