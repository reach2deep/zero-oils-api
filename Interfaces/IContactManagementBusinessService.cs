using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.DataModel.Transformations;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Transformation;

namespace Verdant.Zero.Erp.Api.Interfaces
{
    public interface IContactManagementBusinessService : IDisposable
    {
        Task<ResponseModel<List<ContactDataTransformation>>> ContactInquiry(int accountId, string contactName, int currentPageNumber, int pageSize, string sortExpression, string sortDirection);
        Task<ResponseModel<ContactDataTransformation>> CreateContact(ContactDataTransformation contactDataTransformation);
        Task<ResponseModel<ContactDataTransformation>> UpdateContact(ContactDataTransformation contactDataTransformation);
        Task<ResponseModel<ContactDataTransformation>> GetContactInformation(int accountId, int contactId);
        Task<ResponseModel<List<ContactDataTransformation>>> GetContact(int accountId, string searchText, int currentPageNumber, int pageSize, string sortExpression, string sortDirection);

    }
}
