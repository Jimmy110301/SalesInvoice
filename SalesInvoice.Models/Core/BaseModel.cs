namespace SalesInvoice.Models.Core
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
    }

    public abstract class BaseStatusModel : BaseModel
    {
        public bool IsActive { get; set; }
    }
}
