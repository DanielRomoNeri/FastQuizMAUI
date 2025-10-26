using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastQuizMAUI.Models;
using FastQuizMAUI.Services;

namespace FastQuizMAUI.ViewModels
{
    public partial class CreateBoxFormVM : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        public CreateBoxFormVM(DatabaseService databaseService)
        {
            _databaseService = databaseService;

        }
        public event EventHandler requestClose;

        [ObservableProperty]
        private string _boxName;
        
        [ObservableProperty]
        private string _boxDescription;

        public ObservableCollection<BoxCategoryModel> Categories { get; set; } = new();

        [ObservableProperty]
        private BoxCategoryModel _selectedCategory;

        [ObservableProperty]
        private bool _isNameIncorrect = false;

        [ObservableProperty]
        private bool _isCategoryNotSelected = false;

        [ObservableProperty]
        private bool _isNameRepeated = false;

        [ObservableProperty]
        private string _errorMessage;

        public async Task GetCategories()
        {
            var categoriesList = await _databaseService.GetBoxCategoriesAsync();
            foreach (var category in categoriesList)
            {
                Categories.Add(category);
            }
        }

        [RelayCommand]
        public async Task CreateBoxAsync()
        {
            if (string.IsNullOrWhiteSpace(BoxName))
            {
                IsNameIncorrect = true;
                ErrorMessage = "Box name field is required";
                return;
            }
            IsNameIncorrect = false;

            if (SelectedCategory == null)
            {
                IsCategoryNotSelected = true;
                ErrorMessage = "Category field is required";
                return;
            }
            IsCategoryNotSelected = false;

            var newBox = new BoxModel
            {
                BoxName = BoxName,
                BoxDescription = BoxDescription,
                BoxCategoryId = SelectedCategory.Id

            };
            try
            {
                await _databaseService.SaveBoxAsync(newBox);
                IsNameIncorrect = false;
                requestClose?.Invoke(this, EventArgs.Empty);
            }catch(SQLite.SQLiteException ex)
            {
                if(ex.Result == SQLite.SQLite3.Result.Constraint && ex.Message.Contains("UNIQUE"))
                {
                    ErrorMessage = "Box name already exists";
                    IsNameRepeated = true;

                }
                else
                {
                    ErrorMessage = "An error occurred while creating the box";
                    IsCategoryNotSelected = true;
                }
            }

        }

    }
}
