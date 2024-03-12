using AS.ApplicationServices.RequestModels.Category;
using AS.ApplicationServices.ResponseModels.Category;

namespace AS.ApplicationServices.Interfaces
{
    public interface ICategoryService
    {
        Task<int> CreateAsync(CreateCategoryRequestModel model);
        Task<GetCategoryResponseModel?> GetByIdAsync(int id);
        Task<IEnumerable<GetCategoryResponseModel>> GetAllAsync();
        Task UpdateAsync(UpdateCategoryRequestModel model);
        Task DeleteAsync(int id);
    }
}
