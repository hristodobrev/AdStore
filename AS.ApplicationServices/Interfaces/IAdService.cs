using AS.ApplicationServices.RequestModels.Ad;
using AS.ApplicationServices.ResponseModels.Ad;

namespace AS.ApplicationServices.Interfaces
{
    public interface IAdService
    {
        Task<int> CreateAsync(CreateAdRequestModel model);
        Task<GetAdResponseModel?> GetByIdAsync(int id);
        Task<IEnumerable<GetAdResponseModel>> GetAllAsync();
        Task UpdateAsync(UpdateAdRequestModel model);
        Task DeleteAsync(int id);
    }
}
