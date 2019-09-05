using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.Data.Interfaces;
using Verdant.Zero.Erp.Api.DataModel.Entities;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Transformation;

namespace Verdant.Zero.Erp.Api.Interfaces
{
    public interface IContactManagementDataService : IDataRepository,IDisposable
    {
        Task CreateContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task<List<Contact>> ContactInquiry(int accountId, string contactName, DataGridPagingInformation paging);
        Task<Contact> GetContactInformationByContactName(string contactName, int accountId);
        Task<List<Contact>> GetContacts(int accountId, string contactName, DataGridPagingInformation paging);

    }
}
