using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Verdant.Zero.Erp.Api.DataModel.Transformations
{
    public class ContactsListDataTransformation
    {
        public int? contactId { get; set; }
        public string contactType { get; set; }
        public string customerType { get; set; }
        public string contactName { get; set; }
        public string salutation { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string displayName { get; set; }
        public string companyName { get; set; }
        public string email { get; set; }
        public string workPhone { get; set; }
        public string mobileNumber { get; set; }        

    }

    public class ContactDataTransformation
    {
        public int? contactId { get; set; }
        public string contactType { get; set; }
        public string customerType { get; set; }
        public string contactName { get; set; }
        public string salutation { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string displayName { get; set; }
        public string companyName { get; set; }
        public string email { get; set; }
        public string workPhone { get; set; }
        public string mobileNumber { get; set; }
        public string websiteAddress { get; set; }
        public AddressDataTrnsformation billingAddress { get; set; }
        public AddressDataTrnsformation shippingAddress { get; set; }
        public string notes { get; set; }
        public TaxAndPaymentDetailDataTransformation taxPaymentDetail { get; set; }

    }

    public class AddressDataTrnsformation
    {
        public int? addressId { get; set; }
        public string attention { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string cityName { get; set; }
        public string stateName { get; set; }
        public string zipCode { get; set; }
        public string countryName { get; set; }
        public string faxNumber { get; set; }
        public string addressPhone { get; set; }

    }

    public class TaxAndPaymentDetailDataTransformation
    {        
        public int? taxpaymentId { get; set; }
        public string currencyCode { get; set; }
        public string paymentTerm { get; set; }
    }
}
