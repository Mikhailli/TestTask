#nullable enable
using Wpf.Models;
using Wpf.Models.ApiRequestModels;

namespace Wpf.Services.Interfaces;

public interface IMedicineService
{
    Task<Medicine> GetAsync(int id);

    Task<Medicine[]> GetAllAsync();

    Task UpdateMedicineAsync(Medicine medicine);

    Task<Medicine> AddMedicineAsync(MedicineParameters parameters);

    Task DeleteMedicine(int id);
}
