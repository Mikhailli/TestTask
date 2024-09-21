#nullable enable
using Data.Models;

namespace Data.Interfaces;

public interface IUnitOfWork : IDisposable
{
    int Commit();

    void BulkInsert<TEntity>(IList<TEntity> entities) where TEntity : Entity;
}
