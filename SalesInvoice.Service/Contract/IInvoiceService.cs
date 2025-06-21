using SalesInvoice.ViewModels.Invoice;

namespace SalesInvoice.Service.Contract
{
    public interface IInvoiceService
    {
        Task<bool> DeleteInvoice(Guid id);
        Task<List<InvoiceListViewModel>> GetAllInvoices();
        Task<InvoiceViewModel?> GetInvoiceById(Guid id);
        Task<bool> InsertInvoice(InvoiceAddEditViewModel data);
        Task<bool> UpdateInvoice(InvoiceAddEditViewModel data);
    }
}
