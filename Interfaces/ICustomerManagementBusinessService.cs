using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Transformation;

namespace Verdant.Zero.Erp.Api.Interfaces
{
    public interface ICustomerManagementBusinessService : IDisposable
    {
        Task<ResponseModel<List<CustomerDataTransformation>>> CustomerInquiry(int accountId, string customerName, int currentPageNumber, int pageSize, string sortExpression, string sortDirection);
        Task<ResponseModel<CustomerDataTransformation>> CreateCustomer(CustomerDataTransformation customerDataTransformation);
        Task<ResponseModel<CustomerDataTransformation>> UpdateCustomer(CustomerDataTransformation customerDataTransformation);
        Task<ResponseModel<CustomerDataTransformation>> GetCustomerInformation(int accountId, int customerId);
        Task<ResponseModel<List<CustomerDataTransformation>>> GetCustomer(int accountId, string customerName, int currentPageNumber, int pageSize, string sortExpression, string sortDirection);

    }
}
