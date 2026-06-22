using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Client.Models;
using Client.Services;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly ApiService _api = new();

    public ObservableCollection<ProductDto> Products { get; } = new();

    [ObservableProperty] private ProductDto? selectedProduct;
    [ObservableProperty] private string name = string.Empty;
    [ObservableProperty] private decimal price;
    [ObservableProperty] private int quantity;

    public MainWindowViewModel() => _ = LoadAsync();

    private async Task LoadAsync()
    {
        Products.Clear();
        foreach (var p in await _api.GetAllAsync())
            Products.Add(p);
    }

    [RelayCommand]
    private async Task AddAsync()
    {
        var dto = new ProductDto { Name = Name, Price = Price, Quantity = Quantity };
        var created = await _api.CreateAsync(dto);
        if (created != null) Products.Add(created);
    }

    [RelayCommand]
    private async Task UpdateAsync()
    {
        if (SelectedProduct is null) return;
        SelectedProduct.Name = Name;
        SelectedProduct.Price = Price;
        SelectedProduct.Quantity = Quantity;
        await _api.UpdateAsync(SelectedProduct);
        await LoadAsync();
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (SelectedProduct is null) return;
        await _api.DeleteAsync(SelectedProduct.Id);
        Products.Remove(SelectedProduct);
    }
}
