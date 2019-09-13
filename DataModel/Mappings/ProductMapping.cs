using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.DataModel.Entities;
using Verdant.Zero.Erp.Api.DataModel.Transformations;

namespace Verdant.Zero.Erp.Api.DataModel.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            //PRODUCT => PRODUCT DTO
            CreateMap<Product, ProductDataTransformation>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.item_type, opt => opt.MapFrom(src => src.ItemType))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.sku, opt => opt.MapFrom(src => src.Sku))
                .ForMember(dest => dest.uom, opt => opt.MapFrom(src => src.Uom))
                .ForMember(dest => dest.is_returnable, opt => opt.MapFrom(src => src.IsReturnable))
                .ForMember(dest => dest.manufacturer, opt => opt.MapFrom(src => src.Manufacturer))
                .ForMember(dest => dest.brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.upc, opt => opt.MapFrom(src => src.Upc))
                .ForMember(dest => dest.mpn, opt => opt.MapFrom(src => src.Mpn))
                .ForMember(dest => dest.ean, opt => opt.MapFrom(src => src.Ean))
                .ForMember(dest => dest.isbn, opt => opt.MapFrom(src => src.Isbn))
                .ForMember(dest => dest.image_path, opt => opt.MapFrom(src => src.ImagePath));

            CreateMap<Dimension, ProductDataTransformation>()
               .ForMember(dest => dest.dimension_length, opt => opt.MapFrom(src => src.Length))
               .ForMember(dest => dest.dimension_width, opt => opt.MapFrom(src => src.Width))
               .ForMember(dest => dest.dimension_height, opt => opt.MapFrom(src => src.Height))
               .ForMember(dest => dest.dimension_weight, opt => opt.MapFrom(src => src.Weight));


            CreateMap<SalesInformation, ProductDataTransformation>()
            .ForMember(dest => dest.sales_information_account, opt => opt.MapFrom(src => src.Account))
            .ForMember(dest => dest.sales_information_selling_price, opt => opt.MapFrom(src => src.SellingPrice))
            .ForMember(dest => dest.sales_information_description, opt => opt.MapFrom(src => src.Description));

            CreateMap<PurchaseInformation, ProductDataTransformation>()
               .ForMember(dest => dest.purchase_information_account, opt => opt.MapFrom(src => src.Account))
               .ForMember(dest => dest.purchase_information_purchase_price, opt => opt.MapFrom(src => src.PurchasePrice))
               .ForMember(dest => dest.purchase_information_description, opt => opt.MapFrom(src => src.Description));

            CreateMap<InventoryAccount, ProductDataTransformation>()
               .ForMember(dest => dest.inventory_account_id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.inventory_account_name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.inventory_account_opening_stock, opt => opt.MapFrom(src => src.OpeningStock))
               .ForMember(dest => dest.inventory_account_opening_stock_value_per_unit, opt => opt.MapFrom(src => src.OpeningStockValuePerUnit));


            //PRODUCT DTO => PRODUCT
            CreateMap<ProductDataTransformation,Product>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
               .ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => src.item_type))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
               .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.sku))
               .ForMember(dest => dest.Uom, opt => opt.MapFrom(src => src.uom))
               .ForMember(dest => dest.IsReturnable, opt => opt.MapFrom(src => src.is_returnable))
               .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.manufacturer))
               .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.brand))
               .ForMember(dest => dest.Upc, opt => opt.MapFrom(src => src.upc))
               .ForMember(dest => dest.Mpn, opt => opt.MapFrom(src => src.mpn))
               .ForMember(dest => dest.Ean, opt => opt.MapFrom(src => src.ean))
               .ForMember(dest => dest.Isbn, opt => opt.MapFrom(src => src.isbn))
               .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.image_path));

            CreateMap<ProductDataTransformation, Dimension>()
               .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.dimension_length))
               .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.dimension_width))
               .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.dimension_height))
               .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.dimension_weight));

            CreateMap<ProductDataTransformation, SalesInformation>()
               .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.sales_information_account))
               .ForMember(dest => dest.SellingPrice, opt => opt.MapFrom(src => src.sales_information_selling_price))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.sales_information_description));

            CreateMap<ProductDataTransformation, PurchaseInformation>()
               .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.purchase_information_account))
               .ForMember(dest => dest.PurchasePrice, opt => opt.MapFrom(src => src.purchase_information_purchase_price))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.purchase_information_description));

            CreateMap<ProductDataTransformation, InventoryAccount>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.inventory_account_id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.inventory_account_name))
               .ForMember(dest => dest.OpeningStock, opt => opt.MapFrom(src => src.inventory_account_opening_stock))
               .ForMember(dest => dest.OpeningStockValuePerUnit, opt => opt.MapFrom(src => src.inventory_account_opening_stock_value_per_unit));

        }
    }
}
