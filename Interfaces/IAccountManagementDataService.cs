 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.Data.Interfaces;
using Verdant.Zero.Erp.Api.DataModel.Entities;

namespace Verdant.Zero.Erp.Api.Interfaces
{
    public interface IAccountManagementDataService : IDataRepository, IDisposable
    {

        Task CreateUser(User user);
        Task CreateAccount(Account account);
        Task<User> GetUserByEmailAddress(string emailAddress);
        Task UpdateUser(User user);
        Task UpdateAccount(Account account);
        Task<User> GetUserByUserId(int userId);
        Task<Account> GetAccountInformation(int accountId);
    }
}
