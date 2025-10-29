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
    [QueryProperty(nameof(BoxToDisplay), "SelectedBox")]
    public partial class InsideBoxVM : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        public InsideBoxVM(DatabaseService databaseService)
        {
            _databaseService = databaseService;

        }
        public EventHandler RequestOpenForm;
        [ObservableProperty]
        private ItemsBoxModel[] _itemsInBox;
        [ObservableProperty]
        BoxModel _boxToDisplay;

        public async Task InitAsync()
        {
            await LoadItemsInBoxAsync();
        }

        private async Task LoadItemsInBoxAsync()
        {
            ItemsInBox = await _databaseService.GetItemsAsync(BoxToDisplay.Id);
        }

        [RelayCommand]
        private void OpenAddItemForm()
        {
            RequestOpenForm?.Invoke(this, EventArgs.Empty);
        }
    }

}
