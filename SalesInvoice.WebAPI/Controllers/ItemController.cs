using Microsoft.AspNetCore.Mvc;
using SalesInvoice.Service.Contract;
using SalesInvoice.ViewModels.Core;
using SalesInvoice.ViewModels.Item;

namespace SalesInvoice.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            List<ItemViewModel> items = await itemService.GetAllItems();
            return Ok(new ResponseViewModel<List<ItemViewModel>>
            {
                IsSuccess = true,
                Data = items
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetItemsByCategory([FromQuery] Guid? categoryId)
        {
            return Ok(new ResponseViewModel<List<ItemViewModel>>
            {
                IsSuccess = true,
                Data = await itemService.GetAllItems(categoryId)
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(Guid id)
        {
            ItemViewModel? item = await itemService.GetItemById(id);
            return Ok(new ResponseViewModel<ItemViewModel>
            {
                IsSuccess = true,
                Message = item == null ? "No record found" : "Success",
                Data = item
            });
        }

        [HttpPost]
        public async Task<IActionResult> InsertItem(ItemAddEditViewModel data)
        {
            bool isSuccess = await itemService.InsertItem(data);
            return Ok(new ResponseViewModel
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Item inserted successfully" : "Failed to insert item"
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(ItemAddEditViewModel data)
        {
            bool isSuccess = await itemService.UpdateItem(data);
            return Ok(new ResponseViewModel
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Item updated successfully" : "Failed to update item"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            bool isSuccess = await itemService.DeleteItem(id);
            return Ok(new ResponseViewModel
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Item deleted successfully" : "Failed to delete item"
            });
        }

        [HttpGet]
        public IActionResult GenerateItemCode()
        {
            return Ok(new ResponseViewModel<string>
            {
                IsSuccess = true,
                Message = "Item code generated successfully",
                Data = GetItemCode()
            });
        }

        private string GetItemCode()
        {
            var random = new Random();
            return random.Next(100000, 1000000).ToString();
        }
    }
}
