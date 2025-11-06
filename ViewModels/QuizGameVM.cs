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
    [QueryProperty(nameof(Options), "SelectedOptions")]
    public partial class QuizGameVM : ObservableObject
    {
        private readonly DatabaseService _databaseService;
        private readonly Random random = new Random();
        private List<int> indexLeft = new List<int>();
        public QuizGameVM(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task Initialize()
        {
            ItemsToQuiz = Options.Items;

            for (int i = 0; i < ItemsToQuiz.Length; i++)
            {
                indexLeft.Add(i);
            }
            if (Options.Qty == 1)
            {
                quantityOption = ItemsToQuiz.Length;
            }
            else if (Options.Qty == 2)
            {
                quantityOption = 30;
            }
            else if (Options.Qty == 3)
            {
                quantityOption = 50;
            }
            else if (Options.Qty == 4)
            {
                quantityOption = 100;
            }
            await SetNewCard();

        }

        public EventHandler ResetCardPos;
        private OptionsModel Options = new();
        private int quantityOption = 1;
        public string CountFormat => $"{CardsCount}/{quantityOption}";

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CountFormat))]
        private int _cardsCount;

        [ObservableProperty]
        private bool _isBackTextActive = false;

        [ObservableProperty]
        private ItemsBoxModel[] _itemsToQuiz;

        [ObservableProperty]
        private ItemsBoxModel _currentItem;

        [RelayCommand]
        private async Task SetNewCard()
        {
            IsBackTextActive = false;
            ResetCardPos?.Invoke(this, EventArgs.Empty);
            if (indexLeft.Count > 0)
            {
                int randomIndexFromList = random.Next(0, indexLeft.Count);

                int indexItem = indexLeft[randomIndexFromList];

                CurrentItem = ItemsToQuiz[indexItem];
                indexLeft.RemoveAt(randomIndexFromList);
            }
            else
            {
                await Shell.Current.DisplayAlert("Quiz Finished", "You have completed the quiz!", "OK");
                await Shell.Current.GoToAsync("..");
            }

        }
        [RelayCommand]
        private async Task SetNewLevel(string points)
        {
            int pointsInt = int.Parse(points);
            CardsCount++;
            CurrentItem.Level += pointsInt;
            if (CurrentItem.Level < 0)
            {
                CurrentItem.Level = 0;
            }
            else if (CurrentItem.Level > 100)
            {
                CurrentItem.Level = 100;
            }
            await _databaseService.UpdateItemAsync(CurrentItem);
            await SetNewCard();
        }
        [RelayCommand]
        private void ShowDifficultySelection()
        {
            IsBackTextActive = true;
        }
    }
}
