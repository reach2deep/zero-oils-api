using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.DataModel.Entities;
using Verdant.Zero.Erp.Api.DataModel.Transformations;

namespace Verdant.Zero.Erp.Api.DataModel.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ContactDataTransformation, Contact>()
                 .ForMember(dest => dest.ContactId, opt => opt.MapFrom(src => src.contact_id))
                .ForMember(dest => dest.ContactType, opt => opt.MapFrom(src => src.contact_type))
                .ForMember(dest => dest.CustomerType, opt => opt.MapFrom(src => src.customer_type))
                .ForMember(dest => dest.Salutation, opt => opt.MapFrom(src => src.salutation))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.first_name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.last_name))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.display_name))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.company_name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.WorkPhone, opt => opt.MapFrom(src => src.work_phone))
                .ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.mobile_number))
                .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.website_address))                
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.notes));
               

            CreateMap<AddressDataTrnsformation, Address>()
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.address_id))
                .ForMember(dest => dest.Attention, opt => opt.MapFrom(src => src.attention))
                .ForMember(dest => dest.Street1, opt => opt.MapFrom(src => src.street_1))
                .ForMember(dest => dest.Street2, opt => opt.MapFrom(src => src.street_2))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.city_name))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.state_name))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.zip_code))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.country_name))
                .ForMember(dest => dest.Fax, opt => opt.MapFrom(src => src.fax_number))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.address_phone));

            CreateMap<TaxAndPaymentDetailDataTransformation,TaxAndPaymentDetails>()
             .ForMember(dest => dest.TaxAndPaymentId, opt => opt.MapFrom(src => src.taxpayment_id))
             .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.currency_code))
             .ForMember(dest => dest.PaymentTersm, opt => opt.MapFrom(src => src.payment_term));

            CreateMap<Contact, ContactDataTransformation>()
               .ForMember(dest => dest.contact_id, opt => opt.MapFrom(src => src.ContactId))
               .ForMember(dest => dest.contact_type, opt => opt.MapFrom(src => src.ContactType))
               .ForMember(dest => dest.customer_type, opt => opt.MapFrom(src => src.CustomerType))
               .ForMember(dest => dest.contact_name, opt => opt.MapFrom(src => src.FirstName + src.LastName))
               .ForMember(dest => dest.salutation, opt => opt.MapFrom(src => src.Salutation))
               .ForMember(dest => dest.first_name, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.last_name, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.display_name, opt => opt.MapFrom(src => src.DisplayName))
               .ForMember(dest => dest.company_name, opt => opt.MapFrom(src => src.CompanyName))
               .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.work_phone, opt => opt.MapFrom(src => src.WorkPhone))
               .ForMember(dest => dest.mobile_number, opt => opt.MapFrom(src => src.Mobile))
               .ForMember(dest => dest.website_address, opt => opt.MapFrom(src => src.Website))
               .ForMember(dest => dest.notes, opt => opt.MapFrom(src => src.Notes));
              


            CreateMap<Address, AddressDataTrnsformation>()
                .ForMember(dest => dest.address_id, opt => opt.MapFrom(src => src.AddressId))
                .ForMember(dest => dest.attention, opt => opt.MapFrom(src => src.Attention))
                .ForMember(dest => dest.street_1, opt => opt.MapFrom(src => src.Street1))
                .ForMember(dest => dest.street_2, opt => opt.MapFrom(src => src.Street2))
                .ForMember(dest => dest.city_name, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.state_name, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.zip_code, opt => opt.MapFrom(src => src.ZipCode))
                .ForMember(dest => dest.country_name, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.fax_number, opt => opt.MapFrom(src => src.Fax))
                .ForMember(dest => dest.address_phone, opt => opt.MapFrom(src => src.Phone));

            CreateMap<TaxAndPaymentDetails, TaxAndPaymentDetailDataTransformation>()
              .ForMember(dest => dest.taxpayment_id, opt => opt.MapFrom(src => src.TaxAndPaymentId))
              .ForMember(dest => dest.currency_code, opt => opt.MapFrom(src => src.CurrencyCode))
              .ForMember(dest => dest.payment_term, opt => opt.MapFrom(src => src.PaymentTersm));

        }
    }
}
