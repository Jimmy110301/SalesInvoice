using AutoMapper;
using SalesInvoice.Models.Tables;
using SalesInvoice.ViewModels.Category;
using SalesInvoice.ViewModels.Core;
using SalesInvoice.ViewModels.Invoice;
using SalesInvoice.ViewModels.Item;
using static SalesInvoice.ViewModels.Core.Constants;

namespace SalesInvoice.Service.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryAddEditVIewModel, Category>();
            CreateMap<Category, CategoryViewModel>();

            CreateMap<ItemAddEditViewModel, Item>();
            CreateMap<Item, ItemViewModel>()
                .ForMember(y => y.CategoryName, opt => opt.MapFrom(y => y.Category.CategoryName))
                .ForMember(y => y.ItemCombineName, opt => opt.MapFrom(y => $"{y.ItemName} ({y.ItemCode})"))
                ;

            CreateMap<Invoice, InvoiceListViewModel>()
                .ForMember(y => y.InvoiceDateTime, opt => opt.MapFrom(y => y.InvoiceDateTime.ToString(Common.DateFormat)))
                .ForMember(y => y.PaidAmount, opt => opt.MapFrom(y => y.AmountPaid))
                .ForMember(y => y.InvoicePaymentMode, opt => opt.MapFrom(y => EnumHelper.GetPaymentMethod(y.InvoicePaymentMode)))
                .ForMember(y => y.DiscountAmount, opt => opt.MapFrom(y => y.InvoiceItems.Count > 0 ? y.InvoiceItems.Sum(w => w.ItemDiscount) : 0.00m))
                .ForMember(y => y.ActualAmount, opt => opt.MapFrom(y => y.InvoiceItems.Count > 0 ? y.InvoiceItems.Sum(w => w.ItemUnitPrice - w.ItemDiscount) : 0.00m))
                ;

            CreateMap<InvoiceAddEditViewModel, Invoice>()
                .ForMember(y => y.InvoiceItems, opt => opt.MapFrom(y => y.Items))
                ;

            CreateMap<InvoiceItemAddEditViewModel, InvoiceItem>()
                .ForMember(y => y.ItemAmount, opt => opt.MapFrom(y => ((y.ItemUnitPrice - y.ItemDiscount) * y.ItemQty)))
                ;

            CreateMap<Invoice, InvoiceViewModel>()
                .ForMember(y => y.Items, opt => opt.MapFrom(y => y.InvoiceItems))
                ;

            CreateMap<InvoiceItem, InvoiceItemListViewModel>()
                .ForMember(y => y.ItemName, opt => opt.MapFrom(y => y.Item.ItemName))
                .ForMember(y => y.ItemCode, opt => opt.MapFrom(y => y.Item.ItemCode))
                .ForMember(y => y.ItemCombineName, opt => opt.MapFrom(y => $"{y.Item.ItemName} ({y.Item.ItemCode})"))
                ;
        }
    }
}
