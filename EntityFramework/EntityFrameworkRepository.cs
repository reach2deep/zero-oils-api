﻿using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.Data.Interfaces;

namespace Verdant.Zero.Erp.Api.Data.EntityFramework
{
    public class EntityFrameworkRepository : IDataRepository, IDisposable
    {
        private ZeroErpManagementDatabase _context;

        private IDbContextTransaction _transaction;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public EntityFrameworkRepository()
        {

        }
        /// <summary>
        /// Database Context
        /// </summary>
        public ZeroErpManagementDatabase dbConnection
        {
            get { return _context; }
        }
        /// <summary>
        /// Commit Transaction
        /// </summary>
        /// <param name="closeSession"></param>
        public void CommitTransaction()
        {
            _transaction.Commit();
        }
        /// <summary>
        /// Save Changes
        /// </summary>
        public async Task UpdateDatabase()
        {
            await dbConnection.SaveChangesAsync();
        }
        /// <summary>
        /// Rollback Transaction
        /// </summary>
        /// <param name="closeSession"></param>
        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }
        /// <summary>
        /// Open Connection
        /// </summary>
        public Object OpenConnection()
        {
            _context = new ZeroErpManagementDatabase();
            return _context;
        }

        public void OpenConnection(string connectionString)
        {
            _context = new ZeroErpManagementDatabase(connectionString);
        }

        public void OpenConnection(Object dbConnection)
        {
            _context = (ZeroErpManagementDatabase)dbConnection;
        }
        /// <summary>
        /// Begin Transaction
        /// </summary>
        public void BeginTransaction(int isolationLevel)
        {
            if (isolationLevel == (int)System.Data.IsolationLevel.Serializable)
            {
                _transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
            }
            else if (isolationLevel == (int)System.Data.IsolationLevel.ReadCommitted)
            {
                _transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            }
            else if (isolationLevel == (int)System.Data.IsolationLevel.ReadUncommitted)
            {
                _transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            }
        }
        /// <summary>
        /// Begin Transaction
        /// </summary>
        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }
        /// <summary>
        /// 
        /// </summary>
        public void CloseConnection()
        {
            _transaction = null;
            _context = null;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EntityFrameworkRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
