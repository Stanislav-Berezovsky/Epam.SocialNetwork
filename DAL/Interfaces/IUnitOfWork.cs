using System;
using System.Data.Entity;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext GetContext();
        void Commit();
        //Rollback
    }
}
