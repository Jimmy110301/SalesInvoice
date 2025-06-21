using AutoMapper;
using SalesInvoice.Models.Tables;
using SalesInvoice.Repository.Contract;
using SalesInvoice.Service.Contract;
using SalesInvoice.ViewModels.Item;

namespace SalesInvoice.Service.Implementation
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;
        private readonly IMapper mapper;

        public ItemService(IItemRepository itemRepository
            , IMapper mapper)
        {
            this.itemRepository = itemRepository;
            this.mapper = mapper;
        }


        public async Task<List<ItemViewModel>> GetAllItems(Guid? categoryId = null)
        {
            var entities = await itemRepository.GetAllAsync(y => (categoryId == null || y.CategoryId == categoryId) && y.IsActive);
            if (entities?.Any() == false) return new List<ItemViewModel>();

            return mapper.Map<List<Item>, List<ItemViewModel>>(entities.ToList());
        }

        public async Task<ItemViewModel?> GetItemById(Guid id)
        {
            var entity = await itemRepository.GetAsync(id);
            if (entity == null) return null;

            return mapper.Map<Item, ItemViewModel>(entity);
        }

        public async Task<bool> InsertItem(ItemAddEditViewModel data)
        {
            var entity = mapper.Map<ItemAddEditViewModel, Item>(data);
            entity.IsActive = true;

            return await itemRepository.InsertAsync(entity);
        }

        public async Task<bool> UpdateItem(ItemAddEditViewModel data)
        {
            var entity = await itemRepository.GetAsync(data.Id);
            if (entity == null) return false;

            return await itemRepository.UpdateAsync(mapper.Map(data, entity));
        }

        public async Task<bool> DeleteItem(Guid id)
        {
            var entity = await itemRepository.GetAsync(id);
            if (entity == null) return false;

            entity.IsActive = false;
            return await itemRepository.UpdateAsync(entity);
        }
    }
}
