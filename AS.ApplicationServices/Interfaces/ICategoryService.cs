using AS.ApplicationServices.RequestModels.Category;
using AS.ApplicationServices.ResponseModels.Category;

namespace AS.ApplicationServices.Interfaces
{
    public interface ICategoryService
    {
        Task<int> CreateAsync(CreateCategoryRequestModel model);
        Task<GetCategoryResponseModel?> GetByIdAsync(int id);
        Task<IEnumerable<GetCategoryResponseModel>> GetAsync(string? name = null, int page = 0, int pageSize = 20);
        Task UpdateAsync(UpdateCategoryRequestModel model);
        Task DeleteAsync(int id);
    }
}
