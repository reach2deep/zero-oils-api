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
                 .ForMember(dest => dest.ContactId, opt => opt.MapFrom(src => src.contactId))
                .ForMember(dest => dest.ContactType, opt => opt.MapFrom(src => src.contactType))
                .ForMember(dest => dest.CustomerType, opt => opt.MapFrom(src => src.customerType))
                .ForMember(dest => dest.Salutation, opt => opt.MapFrom(src => src.salutation))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.firstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.lastName))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.displayName))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.companyName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.WorkPhone, opt => opt.MapFrom(src => src.workPhone))
                .ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.mobileNumber))
                .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.websiteAddress))                
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.notes));
               

            CreateMap<AddressDataTrnsformation, Address>()
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.addressId))
                .ForMember(dest => dest.Attention, opt => opt.MapFrom(src => src.attention))
                .ForMember(dest => dest.Street1, opt => opt.MapFrom(src => src.street1))
                .ForMember(dest => dest.Street2, opt => opt.MapFrom(src => src.street2))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.cityName))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.stateName))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.zipCode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.countryName))
                .ForMember(dest => dest.Fax, opt => opt.MapFrom(src => src.faxNumber))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.addressPhone));

            CreateMap<TaxAndPaymentDetailDataTransformation,TaxAndPaymentDetails>()
             .ForMember(dest => dest.TaxAndPaymentId, opt => opt.MapFrom(src => src.taxpaymentId))
             .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.currencyCode))
             .ForMember(dest => dest.PaymentTersm, opt => opt.MapFrom(src => src.paymentTerm));

            CreateMap<Contact, ContactDataTransformation>()
               .ForMember(dest => dest.contactId, opt => opt.MapFrom(src => src.ContactId))
               .ForMember(dest => dest.contactType, opt => opt.MapFrom(src => src.ContactType))
               .ForMember(dest => dest.customerType, opt => opt.MapFrom(src => src.CustomerType))
               .ForMember(dest => dest.contactName, opt => opt.MapFrom(src => src.FirstName + src.LastName))
               .ForMember(dest => dest.salutation, opt => opt.MapFrom(src => src.Salutation))
               .ForMember(dest => dest.firstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.lastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.displayName, opt => opt.MapFrom(src => src.DisplayName))
               .ForMember(dest => dest.companyName, opt => opt.MapFrom(src => src.CompanyName))
               .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.workPhone, opt => opt.MapFrom(src => src.WorkPhone))
               .ForMember(dest => dest.mobileNumber, opt => opt.MapFrom(src => src.Mobile))
               .ForMember(dest => dest.websiteAddress, opt => opt.MapFrom(src => src.Website))
               .ForMember(dest => dest.notes, opt => opt.MapFrom(src => src.Notes));
              


            CreateMap<Address, AddressDataTrnsformation>()
                .ForMember(dest => dest.addressId, opt => opt.MapFrom(src => src.AddressId))
                .ForMember(dest => dest.attention, opt => opt.MapFrom(src => src.Attention))
                .ForMember(dest => dest.street1, opt => opt.MapFrom(src => src.Street1))
                .ForMember(dest => dest.street2, opt => opt.MapFrom(src => src.Street2))
                .ForMember(dest => dest.cityName, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.stateName, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.zipCode, opt => opt.MapFrom(src => src.ZipCode))
                .ForMember(dest => dest.countryName, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.faxNumber, opt => opt.MapFrom(src => src.Fax))
                .ForMember(dest => dest.addressPhone, opt => opt.MapFrom(src => src.Phone));

            CreateMap<TaxAndPaymentDetails, TaxAndPaymentDetailDataTransformation>()
              .ForMember(dest => dest.taxpaymentId, opt => opt.MapFrom(src => src.TaxAndPaymentId))
              .ForMember(dest => dest.currencyCode, opt => opt.MapFrom(src => src.CurrencyCode))
              .ForMember(dest => dest.paymentTerm, opt => opt.MapFrom(src => src.PaymentTersm));

        }
    }
}
