using Microsoft.AspNetCore.Mvc;
using SalesInvoice.Service.Contract;
using SalesInvoice.ViewModels.Core;
using SalesInvoice.ViewModels.Invoice;

namespace SalesInvoice.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            List<InvoiceListViewModel> invoices = await invoiceService.GetAllInvoices();
            return Ok(new ResponseViewModel<List<InvoiceListViewModel>>
            {
                IsSuccess = true,
                Data = invoices
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(Guid id)
        {
            InvoiceViewModel? invoice = await invoiceService.GetInvoiceById(id);
            return Ok(new ResponseViewModel<InvoiceViewModel>
            {
                IsSuccess = true,
                Data = invoice
            });
        }

        [HttpGet]
        public IActionResult GenerateInvoiceNo()
        {
            return Ok(new ResponseViewModel<string>
            {
                IsSuccess = true,
                Message = "Success",
                Data = EnumHelper.GenerateRandomText()
            });
        }

        [HttpPost]
        public async Task<IActionResult> InsertInvoice(InvoiceAddEditViewModel data)
        {
            bool isSuccess = await invoiceService.InsertInvoice(data);
            return Ok(new ResponseViewModel
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Invoice inserted successfully." : "Failed to insert invoice."
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInvoice(InvoiceAddEditViewModel data)
        {
            bool isSuccess = await invoiceService.UpdateInvoice(data);
            return Ok(new ResponseViewModel
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Invoice updated successfully." : "Failed to update invoice."
            });
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteInvoice(Guid id)
        {
            bool isSuccess = await invoiceService.DeleteInvoice(id);
            return Ok(new ResponseViewModel
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Invoice deleted successfully." : "Failed to delete invoice."
            });
        }
    }
}
