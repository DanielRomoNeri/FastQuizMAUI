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

        [ObservableProperty]
        private bool _isNameIncorrect = false;

        [RelayCommand]
        public async Task CreateBoxAsync()
        {
            if (string.IsNullOrWhiteSpace(BoxName))
            {
                IsNameIncorrect = true;
                return;
            }
            var newBox = new BoxModel
            {
                BoxName = BoxName,
                BoxDescription = BoxDescription
            };
            await _databaseService.SaveBoxAsync(newBox);
            IsNameIncorrect = false;
            requestClose?.Invoke(this, EventArgs.Empty);
        }

    }
}
