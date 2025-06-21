namespace SalesInvoice.ViewModels.Core
{
    public class ResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }

    public class ResponseViewModel<T> : ResponseViewModel
    {
        public T? Data { get; set; }
    }
}
