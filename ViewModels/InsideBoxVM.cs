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
    [QueryProperty(nameof(BoxToDisplay), "SelectedBox")]
    public partial class InsideBoxVM : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        public InsideBoxVM(DatabaseService databaseService)
        {
            _databaseService = databaseService;

        }

        public EventHandler RequestOpenForm;
        
        private List<int> selectedItemsIdList = new();

        [ObservableProperty]
        private bool _showTrashIcon;

        [ObservableProperty]
        private bool _isSelectedMode = false;

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

        [RelayCommand]
        private async Task OpenItemDetailPageAsync(ItemsBoxModel item)
        {
            if(IsSelectedMode)
            {
                // In selection mode, do not navigate to detail page
                return;
            }
            var navigationParameter = new Dictionary<string, object>
            {
                { "SelectedCard", item }
            };
            await Shell.Current.GoToAsync(nameof(ItemDetailPage), navigationParameter);
        }
        [RelayCommand]
        private void ToggleSelectionMode()
        {
            IsSelectedMode = !IsSelectedMode;
            if (!IsSelectedMode)
            {
                // Clear selection when exiting selection mode
                foreach (var item in ItemsInBox)
                {
                    item.isSelected = false;
                }
                selectedItemsIdList.Clear();
                ShowTrashIcon = false;
            }
        }
        [RelayCommand]
        private void ToggleItemSelection(ItemsBoxModel item)
        {
            if (item.isSelected)
            {
                item.isSelected = false;
                selectedItemsIdList.Remove(item.Id);

            }
            else
            {
                item.isSelected = true;
                selectedItemsIdList.Add(item.Id);

            }

            if (selectedItemsIdList.Count == 0)
            {
                ShowTrashIcon = false;
            }
            else
            {
                ShowTrashIcon = true;
            }
        }
        [RelayCommand]
        private async Task DeleteSelectedItemsAsync()
        {
            if (selectedItemsIdList.Count == 0)
            {
                return;

            }
            if (await Shell.Current.DisplayAlert("Delete", $"Do you really want to delete {selectedItemsIdList.Count} items?", "Yes", "No"))
            {
                await _databaseService.DeleteItemsAsync(selectedItemsIdList);
                await LoadItemsInBoxAsync();
                // Clear selection and exit selection mode
                selectedItemsIdList.Clear();
                IsSelectedMode = false;
                ShowTrashIcon = false;
            }
            
        }
        [RelayCommand]
        private async Task StartQuizGameAsync()
        {
            var itemsToQuiz = ItemsInBox.Where(item => item.IsEnabled).ToArray();
            var navigationParameter = new Dictionary<string, object>
            {
                { "ItemstoQuiz", itemsToQuiz }
            };
            await Shell.Current.GoToAsync(nameof(QuizGamePage), navigationParameter);
        }
    }

}
