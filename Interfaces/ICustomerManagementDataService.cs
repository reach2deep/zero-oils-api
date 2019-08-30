using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.Data.Interfaces;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Transformation;

namespace Verdant.Zero.Erp.Api.Interfaces
{
    public interface ICustomerManagementDataService : IDataRepository,IDisposable
    {
        Task CreateCustomer(Customer customer);
        Task<List<Customer>> CustomerInquiry(int accountId, string customerName, DataGridPagingInformation paging);
        Task<Customer> GetCustomerInformationByCustomerName(string customerName, int accountId);
        Task<List<Customer>> GetCustomers(int accountId, string customerName, DataGridPagingInformation paging);

    }
}
