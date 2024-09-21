#nullable enable
using System.Text;
using Wpf.Infrastructure;
using Wpf.Models;
using Wpf.Services.Interfaces;
using Wpf.ViewModels.SuppliersEditor;

namespace Wpf.ViewModels.MedicinesEditor;

public class EditMedicineViewModel : EditorPanelViewModelBase<Medicine>
{
    private readonly IMedicineService _medicineService;
    private MedicineItemViewModel _editedMedicineItemViewModel = null!;

    public MedicineItemViewModel EditedMedicineItemViewModel
    {
        get => _editedMedicineItemViewModel;
        set
        {
            _editedMedicineItemViewModel = value;
            RaisePropertyChanged(nameof(EditedMedicineItemViewModel));
        }
    }

    public EditMedicineViewModel(IMedicineService medicineService)
    {
        _medicineService = medicineService;
    }

    public void Init(MedicineItemViewModel supplierItemViewModel)
    {
        EditedMedicineItemViewModel = supplierItemViewModel;
    }

    protected override async void Save(object? obj)
    {
        if (ValidateItem() is false)
        {
            return;
        }

        try
        {
            await _medicineService.UpdateMedicineAsync(new Medicine
            {
                Id = EditedMedicineItemViewModel.Id,
                Name = EditedMedicineItemViewModel.Name,
                Description = EditedMedicineItemViewModel.Description,
                Price = EditedMedicineItemViewModel.Price,
                Supplier = EditedMedicineItemViewModel.Supplier
            });
            var updatedSupplier = await _medicineService.GetAsync(EditedMedicineItemViewModel.Id);

            ClosePanel(EditorPanelResult.Success, updatedSupplier);
            ErrorMessage = null;
            HasErrors = false;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.Message);
        }
    }

    private bool ValidateItem()
    {
        var validationResult = EditedMedicineItemViewModel.Validate();
        if (validationResult is not null)
        {
            var errorMessageBuilder = new StringBuilder();
            foreach (var result in validationResult)
            {
                errorMessageBuilder.AppendLine(result.ErrorMessage);
            }

            ShowErrorMessage(errorMessageBuilder.ToString().TrimEnd('\n'));
            return false;
        }

        return true;
    }
}
