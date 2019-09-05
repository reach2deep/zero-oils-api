using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Transformation;
using Verdant.Zero.Erp.Api.Data.BusinessRules;
using Verdant.Zero.Erp.Api.DataModel.Transformations;
using Verdant.Zero.Erp.Api.DataModel.Entities;
using AutoMapper;

namespace Verdant.Zero.Erp.Api.Data.Buisness
{
    public class ContactManagementBusinessService : IContactManagementBusinessService
    {
        private readonly IContactManagementDataService _contactManagementDataService;
        private readonly ConnectionStrings _connectionStrings;
        private readonly IMapper _mapper;
        public IConfiguration configuration { get; }

        public ContactManagementBusinessService(IContactManagementDataService contactManagementDataService, 
            ConnectionStrings connectionStrings, IMapper mapper)
        {
            _contactManagementDataService = contactManagementDataService;
            _connectionStrings = connectionStrings;
            _mapper = mapper;
        }


        public async Task<ResponseModel<ContactDataTransformation>> CreateContact(ContactDataTransformation contactDataTransformation)
        {

            ResponseModel<ContactDataTransformation> returnResponse = new ResponseModel<ContactDataTransformation>();

            Contact contact = new Contact();

            try
            {
                _contactManagementDataService.OpenConnection(_connectionStrings.PrimaryDatabaseConnectionString);
                _contactManagementDataService.BeginTransaction((int)IsolationLevel.Serializable);

                ContactBusinessRules<ContactDataTransformation> contactBusinessRules = new ContactBusinessRules<ContactDataTransformation>(contactDataTransformation, _contactManagementDataService);
                ValidationResult validationResult = await contactBusinessRules.Validate();
                if (validationResult.ValidationStatus == false)
                {
                    _contactManagementDataService.RollbackTransaction();

                    returnResponse.ReturnMessage = validationResult.ValidationMessages;
                    returnResponse.ReturnStatus = validationResult.ValidationStatus;

                    return returnResponse;
                }

                contact = _mapper.Map<Contact>(contactDataTransformation);
                contact.BillingAddress = _mapper.Map<Address>(contactDataTransformation.billing_address);
                contact.ShippingAddress = _mapper.Map<Address>(contactDataTransformation.shipping_address);
                contact.TaxAndPaymentDetail = _mapper.Map<TaxAndPaymentDetails>(contactDataTransformation.tax_payment_detail);
                               
                await _contactManagementDataService.CreateContact(contact);

                await _contactManagementDataService.UpdateDatabase();

                _contactManagementDataService.CommitTransaction();

                returnResponse.ReturnStatus = true;

            }
            catch (Exception ex)
            {
                _contactManagementDataService.RollbackTransaction();
                returnResponse.ReturnStatus = false;
                returnResponse.ReturnMessage.Add(ex.Message);
            }
            finally
            {
                _contactManagementDataService.CloseConnection();
            }

            //contactDataTransformation.ContactId = contact.ContactId;

            returnResponse.Entity = contactDataTransformation;

            return returnResponse;

        }
        public async Task<ResponseModel<List<ContactDataTransformation>>> GetContact(int accountId, string searchText, int currentPageNumber, int pageSize, string sortExpression, string sortDirection)
        {
            ResponseModel<List<ContactDataTransformation>> returnResponse = new ResponseModel<List<ContactDataTransformation>>();

            List<ContactDataTransformation> salesOrders = new List<ContactDataTransformation>();

            try
            {
                _contactManagementDataService.OpenConnection(_connectionStrings.PrimaryDatabaseConnectionString);

                DataGridPagingInformation dataGridPagingInformation = new DataGridPagingInformation();
                dataGridPagingInformation.CurrentPageNumber = currentPageNumber;
                dataGridPagingInformation.PageSize = pageSize;
                dataGridPagingInformation.SortDirection = sortDirection;
                dataGridPagingInformation.SortExpression = sortExpression;

                List<Contact> contactsList = await _contactManagementDataService.GetContacts(accountId, searchText, dataGridPagingInformation);
                foreach (Contact contact in contactsList)
                {
                    ContactDataTransformation contactDataTransformation = new ContactDataTransformation();
                    //contactDataTransformation.ContactId = contact.ContactId;
                    //contactDataTransformation.AddressLine1 = contact.AddressLine1;
                    //contactDataTransformation.AddressLine2 = contact.AddressLine2;
                    //contactDataTransformation.City = contact.City;
                    //contactDataTransformation.Region = contact.Region;
                    //contactDataTransformation.PostalCode = contact.PostalCode;
                    //contactDataTransformation.ContactName = contact.Name;                    
                    //contactDataTransformation.AccountId = contact.AccountId;
                    contactDataTransformation = _mapper.Map<ContactDataTransformation>(contact);
                    salesOrders.Add(contactDataTransformation);
                }

                returnResponse.Entity = salesOrders;
                returnResponse.TotalRows = dataGridPagingInformation.TotalRows;
                returnResponse.TotalPages = dataGridPagingInformation.TotalPages;

                returnResponse.ReturnStatus = true;

            }
            catch (Exception ex)
            {
                _contactManagementDataService.RollbackTransaction();
                returnResponse.ReturnStatus = false;
                returnResponse.ReturnMessage.Add(ex.Message);
            }
            finally
            {
                _contactManagementDataService.CloseConnection();
            }

            return returnResponse;

        }

        public Task<ResponseModel<List<ContactDataTransformation>>> ContactInquiry(int accountId, string contactName, int currentPageNumber, int pageSize, string sortExpression, string sortDirection)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<ContactDataTransformation>> UpdateContact(ContactDataTransformation contactDataTransformation)
        {
            ResponseModel<ContactDataTransformation> returnResponse = new ResponseModel<ContactDataTransformation>();

            Contact contact = new Contact();

            try
            {
                _contactManagementDataService.OpenConnection(_connectionStrings.PrimaryDatabaseConnectionString);
                _contactManagementDataService.BeginTransaction((int)IsolationLevel.Serializable);

                ContactBusinessRules<ContactDataTransformation> contactBusinessRules = new ContactBusinessRules<ContactDataTransformation>(contactDataTransformation, _contactManagementDataService);
                ValidationResult validationResult = await contactBusinessRules.Validate();
                if (validationResult.ValidationStatus == false)
                {
                    _contactManagementDataService.RollbackTransaction();

                    returnResponse.ReturnMessage = validationResult.ValidationMessages;
                    returnResponse.ReturnStatus = validationResult.ValidationStatus;

                    return returnResponse;
                }

                contact = _mapper.Map<Contact>(contactDataTransformation);
                contact.BillingAddress = _mapper.Map<Address>(contactDataTransformation.billing_address);
                contact.ShippingAddress = _mapper.Map<Address>(contactDataTransformation.shipping_address);
                contact.TaxAndPaymentDetail = _mapper.Map<TaxAndPaymentDetails>(contactDataTransformation.tax_payment_detail);

                await _contactManagementDataService.UpdateContact(contact);

                await _contactManagementDataService.UpdateDatabase();

                _contactManagementDataService.CommitTransaction();

                returnResponse.ReturnStatus = true;

            }
            catch (Exception ex)
            {
                _contactManagementDataService.RollbackTransaction();
                returnResponse.ReturnStatus = false;
                returnResponse.ReturnMessage.Add(ex.Message);
            }
            finally
            {
                _contactManagementDataService.CloseConnection();
            }

            returnResponse.Entity = contactDataTransformation;

            return returnResponse;

        }

        public Task<ResponseModel<ContactDataTransformation>> GetContactInformation(int accountId, int contactId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
