using System;

namespace DataAccess.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
