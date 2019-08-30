using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verdant.Zero.Erp.Api.Data.Interfaces
{
    /// <summary>
    /// IDataRepository
    /// </summary>
    public interface IDataRepository
    {

        void CommitTransaction();
        Task UpdateDatabase();
        void BeginTransaction(int isolationLevel);
        void BeginTransaction();
        void RollbackTransaction();
        Object OpenConnection();
        void CloseConnection();
        void OpenConnection(Object dbConnection);
        void OpenConnection(string connectionString);

    }
}
