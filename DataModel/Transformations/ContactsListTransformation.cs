using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Verdant.Zero.Erp.Api.DataModel.Transformations
{
    public class ContactsListDataTransformation
    {
        public int? contact_id { get; set; }
        public string contact_type { get; set; }
        public string customer_type { get; set; }
        public string contact_name { get; set; }
        public string salutation { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string display_name { get; set; }
        public string company_name { get; set; }
        public string email { get; set; }
        public string work_phone { get; set; }
        public string mobile_number { get; set; }        

    }

    public class ContactDataTransformation
    {
        public int? contact_id { get; set; }
        public string contact_type { get; set; }
        public string customer_type { get; set; }
        public string contact_name { get; set; }
        public string salutation { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string display_name { get; set; }
        public string company_name { get; set; }
        public string email { get; set; }
        public string work_phone { get; set; }
        public string mobile_number { get; set; }
        public string website_address { get; set; }
        public AddressDataTrnsformation billing_address { get; set; }
        public AddressDataTrnsformation shipping_address { get; set; }
        public string notes { get; set; }
        public TaxAndPaymentDetailDataTransformation tax_payment_detail { get; set; }

    }

    public class AddressDataTrnsformation
    {
        public int? address_id { get; set; }
        public string attention { get; set; }
        public string street_1 { get; set; }
        public string street_2 { get; set; }
        public string city_name { get; set; }
        public string state_name { get; set; }
        public string zip_code { get; set; }
        public string country_name { get; set; }
        public string fax_number { get; set; }
        public string address_phone { get; set; }

    }

    public class TaxAndPaymentDetailDataTransformation
    {        
        public int? taxpayment_id { get; set; }
        public string currency_code { get; set; }
        public string payment_term { get; set; }
    }
}
