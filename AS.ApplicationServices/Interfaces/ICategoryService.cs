using AS.ApplicationServices.RequestModels.Category;
using AS.ApplicationServices.ResponseModels.Category;

namespace AS.ApplicationServices.Interfaces
{
    public interface ICategoryService
    {
        Task<int> CreateAsync(CreateAdRequestModel model);
        Task<GetCategoryResponseModel?> GetByIdAsync(int id);
        Task<IEnumerable<GetCategoryResponseModel>> GetAllAsync();
        Task UpdateAsync(UpdateAdRequestModel model);
        Task DeleteAsync(int id);
    }
}
