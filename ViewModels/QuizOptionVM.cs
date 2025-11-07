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
    [QueryProperty(nameof(ItemsToQuiz), "ItemsToQuiz")]
    public partial class QuizOptionVM : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        public QuizOptionVM(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        [ObservableProperty]
        private ItemsBoxModel[] _itemsToQuiz;

        [ObservableProperty]
        private int _orderValue;
        [ObservableProperty]
        private int _quantityValue;
        [ObservableProperty]
        private bool _showContext;

        [RelayCommand]
        private async Task StartQuizAsync()
        {
            var SelectedOptions = new OptionsModel
            {
                Items = ItemsToQuiz,
                Order = OrderValue,
                Qty = QuantityValue,
                ShowContext = ShowContext
            };
            var navigationParameter = new Dictionary<string, object>
            {
                { "Options", SelectedOptions }
            };
            await Shell.Current.GoToAsync(nameof(QuizGamePage), navigationParameter);
        }
    }
}
