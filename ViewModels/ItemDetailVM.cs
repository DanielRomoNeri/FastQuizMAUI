using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastQuizMAUI.Models;
using FastQuizMAUI.Pages;
using FastQuizMAUI.Services;

namespace FastQuizMAUI.ViewModels 
{
    [QueryProperty(nameof(ItemToDisplay), "SelectedCard")]
    public partial class ItemDetailVM : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        public ItemDetailVM(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public bool IsDataOutDated = false;

        [ObservableProperty]
        private ItemsBoxModel _itemToDisplay;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(ItemToDisplay))]
        private bool _isEnabled;
        
        public void SetStatus()
        {
            IsEnabled = ItemToDisplay.IsEnabled;
        }

        public async Task ReloadItem()
        {
            ItemToDisplay = await _databaseService.GetItemAsync(ItemToDisplay.Id);
            IsDataOutDated = false;
        }

        [RelayCommand]
        private async Task DeleteItemAsync()
        {
            if (await Shell.Current.DisplayAlert("Delete", "Do you really want to delete this?", "Yes", "No"))
            {
                await _databaseService.DeleteItemAsync(ItemToDisplay);
                await Shell.Current.GoToAsync("..");

            }
            
        }
        [RelayCommand]
        private async Task OpenEditFormAsync()
        {
            IsDataOutDated = true;
            var parameters = new Dictionary<string, object>
            {
                { "SelectedCard", ItemToDisplay }
            };
            await Shell.Current.GoToAsync(nameof(EditItemForm), parameters);
        }

        [RelayCommand]
        private async Task ToggleStatus()
        {
            ItemToDisplay.IsEnabled = !IsEnabled;
            IsEnabled = !IsEnabled;
            

            await _databaseService.UpdateItemAsync(ItemToDisplay);
        }

    }
}
