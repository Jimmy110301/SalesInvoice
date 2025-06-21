using AutoMapper;
using SalesInvoice.Models.Tables;
using SalesInvoice.Repository.Contract;
using SalesInvoice.Service.Contract;
using SalesInvoice.ViewModels.Invoice;

namespace SalesInvoice.Service.Implementation
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository
            , IMapper mapper)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
        }

        public async Task<List<InvoiceListViewModel>> GetAllInvoices()
        {
            var entities = await invoiceRepository.GetAllAsync(y => y.IsActive);
            if (entities?.Any() == false) return new List<InvoiceListViewModel>();

            return mapper.Map<List<Invoice>, List<InvoiceListViewModel>>(entities.OrderByDescending(y => y.InvoiceDateTime).ToList());
        }

        public async Task<InvoiceViewModel?> GetInvoiceById(Guid id)
        {
            var entity = await invoiceRepository.GetAsync(id);
            if (entity == null) return null;

            return mapper.Map<Invoice, InvoiceViewModel>(entity);
        }

        public async Task<bool> InsertInvoice(InvoiceAddEditViewModel data)
        {
            var entity = mapper.Map<InvoiceAddEditViewModel, Invoice>(data);
            return await invoiceRepository.InsertAsync(entity);
        }

        public async Task<bool> UpdateInvoice(InvoiceAddEditViewModel data)
        {
            var entity = await invoiceRepository.GetAsync(data.Id);
            if (entity == null) return false;

            return await invoiceRepository.UpdateAsync(mapper.Map(data, entity));
        }

        public async Task<bool> DeleteInvoice(Guid id)
        {
            var entity = await invoiceRepository.GetAsync(id);
            if (entity == null) return false;

            entity.IsActive = false;
            return await invoiceRepository.UpdateAsync(entity);
        }
    }
}
