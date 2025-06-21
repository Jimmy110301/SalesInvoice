using Microsoft.AspNetCore.Mvc;
using SalesInvoice.Service.Contract;
using SalesInvoice.ViewModels.Category;
using SalesInvoice.ViewModels.Core;

namespace SalesInvoice.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            List<CategoryViewModel> categories = await categoryService.GetAllCategory();
            return Ok(new ResponseViewModel<List<CategoryViewModel>>
            {
                IsSuccess = true,
                Data = categories
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            CategoryViewModel? category = await categoryService.GetCategoryById(id);
            return Ok(new ResponseViewModel<CategoryViewModel>
            {
                IsSuccess = true,
                Message = category == null ? "No record found" : "Success",
                Data = category
            });
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory(CategoryAddEditVIewModel data)
        {
            bool isSuccess = await categoryService.InsertCategory(data);
            return Ok(new ResponseViewModel
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Category inserted successfully" : "Failed to insert category"
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryAddEditVIewModel data)
        {
            bool isSuccess = await categoryService.UpdateCategory(data);
            return Ok(new ResponseViewModel
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Category updated successfully" : "Failed to update category"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            bool isSuccess = await categoryService.DeleteCategory(id);
            return Ok(new ResponseViewModel
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Category deleted successfully" : "Failed to delete category"
            });
        }
    }
}
