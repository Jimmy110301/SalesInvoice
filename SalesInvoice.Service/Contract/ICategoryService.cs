
using SalesInvoice.ViewModels.Category;

namespace SalesInvoice.Service.Contract
{
    public interface ICategoryService
    {
        Task<bool> DeleteCategory(Guid id);
        Task<List<CategoryViewModel>> GetAllCategory();
        Task<CategoryViewModel?> GetCategoryById(Guid id);
        Task<bool> InsertCategory(CategoryAddEditVIewModel data);
        Task<bool> UpdateCategory(CategoryAddEditVIewModel data);
    }
}
