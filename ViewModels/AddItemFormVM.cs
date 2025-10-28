using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastQuizMAUI.Helpers;
using FastQuizMAUI.Models;
using FastQuizMAUI.Services;

namespace FastQuizMAUI.ViewModels
{
    public partial class AddItemFormVM : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        public AddItemFormVM(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public EventHandler RequestUnfocus;
        public ObservableCollection<ItemsBoxModel> ItemsList { get; set; } = new();

        [ObservableProperty]
        private ItemsBoxModel _item = new();

        [ObservableProperty]
        private bool _isFrontTextFieldEmpty = false;

        [ObservableProperty]
        private bool _isBackTextFieldEmpty = false;

        [RelayCommand]
        private async Task AddItem()
        {
            if (string.IsNullOrWhiteSpace(Item.FrontText))
            {
                IsFrontTextFieldEmpty = true;
                return;
            }
            else
            {
                IsFrontTextFieldEmpty = false;
            }
            if (string.IsNullOrWhiteSpace(Item.BackText))
            {
                IsBackTextFieldEmpty = true;
                return;
            }
            else
            {
                IsBackTextFieldEmpty = false;
            }


            ItemsList.Add(Item);
            Item = new ItemsBoxModel();
            RequestUnfocus.Invoke(this, new EventArgs());
            KeyboardHelper.HideKeyboard();


        }

        [RelayCommand]
        private async Task AddItemstoDBAsync()
        {

            int result = await _databaseService.SaveItemsListAsync([.. ItemsList]);

        }

        [RelayCommand]
        private void DeleteItemFromList(ItemsBoxModel item)
        {
            if (ItemsList.Contains(item))
            {
                ItemsList.Remove(item);
            }
        }
    }
}
