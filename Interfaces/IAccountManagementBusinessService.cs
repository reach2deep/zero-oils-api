using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.DataModel.Entities;
using Verdant.Zero.Erp.Api.DataModel.Transformations;
using Verdant.Zero.Erp.Api.Model;

namespace Verdant.Zero.Erp.Api.Interfaces
{
    public interface IAccountManagementBusinessService
    {
        Task<ResponseModel<AccountDataTransformation>> Register(AccountDataTransformation accountDataTransformation);
        Task<ResponseModel<AccountDataTransformation>> Login(AccountDataTransformation accountDataTransformation);
        Task<ResponseModel<AccountDataTransformation>> UpdateUser(AccountDataTransformation accountDataTransformation);
        Task<ResponseModel<User>> UpdateUser(int userId);

    }
}
