#nullable enable
using Data.Models;

namespace Data.Interfaces;

public interface ISupplierRepository : IGenericRepository<Supplier>
{
    Supplier? CreateAndAdd(string name);

    void Update(Supplier supplier, string name);
}
