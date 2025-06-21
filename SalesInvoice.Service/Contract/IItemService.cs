using SalesInvoice.ViewModels.Item;

namespace SalesInvoice.Service.Contract
{
    public interface IItemService
    {
        Task<bool> DeleteItem(Guid id);
        Task<List<ItemViewModel>> GetAllItems(Guid? categoryId = null);
        Task<ItemViewModel?> GetItemById(Guid id);
        Task<bool> InsertItem(ItemAddEditViewModel data);
        Task<bool> UpdateItem(ItemAddEditViewModel data);
    }
}
