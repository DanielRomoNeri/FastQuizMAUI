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
    public partial class MainPageVM : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        public MainPageVM(DatabaseService databaseService)
        {
            _databaseService = databaseService;

        }
        public async Task InitAsync()
        {
            await _databaseService.InitAsync();
            await LoadBoxesAsync();
        }
        [ObservableProperty]
        private BoxModel[] _boxes;

        [RelayCommand]
        public async Task LoadBoxesAsync()
        {
            Boxes = await _databaseService.GetBoxesAsync();
        }

        [RelayCommand]
        public async Task AddBoxAsync(BoxModel box)
        {
            await _databaseService.SaveBoxAsync(box);
            await LoadBoxesAsync();
        }

        [RelayCommand]
        public async Task OpenBoxAsync(BoxModel box)
        {
            var navigationParameters = new Dictionary<string, object>
            {
                { "SelectedBox", box } 
            };
            await Shell.Current.GoToAsync(nameof(InsideBoxPage), true, navigationParameters);
        }
    }
}
