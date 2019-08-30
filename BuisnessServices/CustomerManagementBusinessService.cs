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

namespace Verdant.Zero.Erp.Api.Data.Buisness
{
    public class CustomerManagementBusinessService : ICustomerManagementBusinessService
    {
        private readonly ICustomerManagementDataService _customerManagementDataService;
        private readonly ConnectionStrings _connectionStrings;

        public IConfiguration configuration { get; }

        public CustomerManagementBusinessService(ICustomerManagementDataService customerManagementDataService, ConnectionStrings connectionStrings)
        {
            _customerManagementDataService = customerManagementDataService;
            _connectionStrings = connectionStrings;
        }


        public async Task<ResponseModel<CustomerDataTransformation>> CreateCustomer(CustomerDataTransformation customerDataTransformation)
        {

            ResponseModel<CustomerDataTransformation> returnResponse = new ResponseModel<CustomerDataTransformation>();

            Customer customer = new Customer();

            try
            {
                _customerManagementDataService.OpenConnection(_connectionStrings.PrimaryDatabaseConnectionString);
                _customerManagementDataService.BeginTransaction((int)IsolationLevel.Serializable);

                CustomerBusinessRules<CustomerDataTransformation> customerBusinessRules = new CustomerBusinessRules<CustomerDataTransformation>(customerDataTransformation, _customerManagementDataService);
                ValidationResult validationResult = await customerBusinessRules.Validate();
                if (validationResult.ValidationStatus == false)
                {
                    _customerManagementDataService.RollbackTransaction();

                    returnResponse.ReturnMessage = validationResult.ValidationMessages;
                    returnResponse.ReturnStatus = validationResult.ValidationStatus;

                    return returnResponse;
                }

                customer.AccountId = customerDataTransformation.AccountId;
                customer.Name = customerDataTransformation.CustomerName;
                customer.AddressLine1 = customerDataTransformation.AddressLine1;
                customer.AddressLine2 = customerDataTransformation.AddressLine2;
                customer.City = customerDataTransformation.City;
                customer.Region = customerDataTransformation.Region;
                customer.PostalCode = customerDataTransformation.PostalCode;

                await _customerManagementDataService.CreateCustomer(customer);

                await _customerManagementDataService.UpdateDatabase();

                _customerManagementDataService.CommitTransaction();

                returnResponse.ReturnStatus = true;

            }
            catch (Exception ex)
            {
                _customerManagementDataService.RollbackTransaction();
                returnResponse.ReturnStatus = false;
                returnResponse.ReturnMessage.Add(ex.Message);
            }
            finally
            {
                _customerManagementDataService.CloseConnection();
            }

            customerDataTransformation.CustomerId = customer.CustomerId;

            returnResponse.Entity = customerDataTransformation;

            return returnResponse;

        }
        public async Task<ResponseModel<List<CustomerDataTransformation>>> GetCustomer(int accountId, string customerName, int currentPageNumber, int pageSize, string sortExpression, string sortDirection)
        {
            ResponseModel<List<CustomerDataTransformation>> returnResponse = new ResponseModel<List<CustomerDataTransformation>>();

            List<CustomerDataTransformation> salesOrders = new List<CustomerDataTransformation>();

            try
            {
                _customerManagementDataService.OpenConnection(_connectionStrings.PrimaryDatabaseConnectionString);

                DataGridPagingInformation dataGridPagingInformation = new DataGridPagingInformation();
                dataGridPagingInformation.CurrentPageNumber = currentPageNumber;
                dataGridPagingInformation.PageSize = pageSize;
                dataGridPagingInformation.SortDirection = sortDirection;
                dataGridPagingInformation.SortExpression = sortExpression;

                List<Customer> customersList = await _customerManagementDataService.GetCustomers(accountId, customerName, dataGridPagingInformation);
                foreach (Customer customer in customersList)
                {
                    CustomerDataTransformation customerDataTransformation = new CustomerDataTransformation();
                    customerDataTransformation.CustomerId = customer.CustomerId;
                    customerDataTransformation.AddressLine1 = customer.AddressLine1;
                    customerDataTransformation.AddressLine2 = customer.AddressLine2;
                    customerDataTransformation.City = customer.City;
                    customerDataTransformation.Region = customer.Region;
                    customerDataTransformation.PostalCode = customer.PostalCode;
                    customerDataTransformation.CustomerName = customer.Name;                    
                    customerDataTransformation.AccountId = customer.AccountId;
                    
                    salesOrders.Add(customerDataTransformation);
                }

                returnResponse.Entity = salesOrders;
                returnResponse.TotalRows = dataGridPagingInformation.TotalRows;
                returnResponse.TotalPages = dataGridPagingInformation.TotalPages;

                returnResponse.ReturnStatus = true;

            }
            catch (Exception ex)
            {
                _customerManagementDataService.RollbackTransaction();
                returnResponse.ReturnStatus = false;
                returnResponse.ReturnMessage.Add(ex.Message);
            }
            finally
            {
                _customerManagementDataService.CloseConnection();
            }

            return returnResponse;

        }

        public Task<ResponseModel<List<CustomerDataTransformation>>> CustomerInquiry(int accountId, string customerName, int currentPageNumber, int pageSize, string sortExpression, string sortDirection)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<CustomerDataTransformation>> UpdateCustomer(CustomerDataTransformation customerDataTransformation)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<CustomerDataTransformation>> GetCustomerInformation(int accountId, int customerId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
