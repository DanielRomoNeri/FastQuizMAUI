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
    public partial class MainPageVM : ObservableObject
    {
        private readonly DatabaseService _databaseService;
        public MainPageVM(DatabaseService databaseService)
        {
            _databaseService = databaseService;
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
    }
}
