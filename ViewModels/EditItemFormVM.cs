using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastQuizMAUI.Models;
using FastQuizMAUI.Services;

namespace FastQuizMAUI.ViewModels
{
    [QueryProperty(nameof(ItemToEdit), "SelectedCard")]
    public partial class EditItemFormVM : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        public EditItemFormVM(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [ObservableProperty]
        private ItemsBoxModel _itemToEdit;

        [RelayCommand]
        private async Task SaveItemAsync()
        {
            await _databaseService.UpdateItemAsync(ItemToEdit);
            await Shell.Current.GoToAsync("..");
        }
    }
}