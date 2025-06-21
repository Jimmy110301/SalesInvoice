using SalesInvoice.Models.Tables;
using SalesInvoice.Repository.Contract;
using SalesInvoice.Service.Contract;
using SalesInvoice.Service.Core;
using SalesInvoice.ViewModels.Category;

namespace SalesInvoice.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IDataMapper dataMapper;

        public CategoryService(ICategoryRepository categoryRepository
            , IDataMapper dataMapper)
        {
            this.categoryRepository = categoryRepository;
            this.dataMapper = dataMapper;
        }

        public async Task<List<CategoryViewModel>> GetAllCategory()
        {
            var entities = await categoryRepository.GetAllAsync(y => y.IsActive);
            if (entities?.Any() == false)
                return new List<CategoryViewModel>();
            return dataMapper.MapTo<List<Category>, List<CategoryViewModel>>(entities.ToList());
        }

        public async Task<CategoryViewModel?> GetCategoryById(Guid id)
        {
            var entity = await categoryRepository.GetAsync(id);
            if (entity == null) return null;

            return dataMapper.MapTo<Category, CategoryViewModel>(entity);
        }

        public async Task<bool> InsertCategory(CategoryAddEditVIewModel data)
        {
            var entity = dataMapper.MapTo<CategoryAddEditVIewModel, Category>(data);
            entity.IsActive = true;
            return await categoryRepository.InsertAsync(entity);
        }

        public async Task<bool> UpdateCategory(CategoryAddEditVIewModel data)
        {
            var entity = await categoryRepository.GetAsync(data.Id);
            if (entity == null) return false;

            return await categoryRepository.UpdateAsync(dataMapper.MapTo(data, entity));
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            var entity = await categoryRepository.GetAsync(id);
            if (entity == null) return false;

            entity.IsActive = false;
            return await categoryRepository.UpdateAsync(entity);
        }
    }
}
