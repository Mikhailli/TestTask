#nullable enable
using Data.Models;

namespace Data.Interfaces;

public interface IMedicineRepository : IGenericRepository<Medicine>
{
    Medicine? CreateAndAdd(string name, string description, double price, Supplier supplier);

    void Update(Medicine medicine, string name, string description, double price, Supplier supplier);
}
