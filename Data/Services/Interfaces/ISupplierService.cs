#nullable enable
using Data.Models;

namespace Data.Services.Interfaces;

public interface ISupplierService : IService
{
    Task<Supplier> GetAsync(int id);

    Supplier Get(int id);

    Supplier[] GetAll();

    void UpdateSupplier(int id, string name);

    Supplier AddSupplier(string name);

    void DeleteSupplier(int id);
}
