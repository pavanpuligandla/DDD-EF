using System;

namespace DataAccess.Abstraction
{
    public interface IDatabaseFactory : IDisposable
    {
        ApplicationDbContext Get();
    }
}
