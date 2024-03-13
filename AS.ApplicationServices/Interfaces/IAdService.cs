using AS.ApplicationServices.RequestModels.Ad;
using AS.ApplicationServices.ResponseModels.Ad;

namespace AS.ApplicationServices.Interfaces
{
    public interface IAdService
    {
        Task<int> CreateAsync(CreateAdRequestModel model, int userId);
        Task<GetAdResponseModel?> GetByIdAsync(int id);
        Task<IEnumerable<GetAdResponseModel>> GetAsync(string? keyword = null, int page = 0, int pageSize = 20);
        Task UpdateAsync(UpdateAdRequestModel model);
        Task DeleteAsync(int id);
    }
}
