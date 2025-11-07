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
    [QueryProperty(nameof(Options), "Options")]
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
            SetFlashcardsCount();
            SetFlashCardsOrder();
            await SetNewCard();

        }

        public EventHandler ResetCardPos;

        private List<ItemsBoxModel> SortedFLashcardsList = [];

        [ObservableProperty]
        private OptionsModel _options = new();

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CountFormat))]
        private int _quantityOption;
        public string CountFormat => $"{CardsCount}/{QuantityOption}";

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CountFormat))]
        private int _cardsCount;

        [ObservableProperty]
        private bool _isBackTextActive = false;

        [ObservableProperty]
        private ItemsBoxModel[] _itemsToQuiz;

        [ObservableProperty]
        private ItemsBoxModel _currentItem;

        private void SetFlashCardsOrder()
        {
            if (Options.Order == 1)
            {
                SortedFLashcardsList = ItemsToQuiz.OrderBy(i => i.Level).ToList();
            }
            else
            {
                SortedFLashcardsList = ItemsToQuiz.ToList();
            }
        }
        private void SetFlashcardsCount()
        {

            if (Options.Qty == 0)
            {
                QuantityOption = ItemsToQuiz.Length;
            }
            else if (Options.Qty == 1)
            {
                QuantityOption = 30;
            }
            else if (Options.Qty == 2)
            {
                QuantityOption = 50;
            }
            else if (Options.Qty == 3)
            {
                QuantityOption = 100;
            }
        }
        [RelayCommand]
        private async Task SetNewCard()
        {

            IsBackTextActive = false;
            ResetCardPos?.Invoke(this, EventArgs.Empty);

            if (CardsCount + 1 <= QuantityOption)
            {
                CardsCount++;
                if (Options.Order == 0)
                {

                    if (indexLeft.Count == 0)
                    {
                        for (int i = 0; i < ItemsToQuiz.Length; i++)
                        {
                            indexLeft.Add(i);
                        }
                        
                    }
                    int randomIndexFromList = random.Next(0, indexLeft.Count);

                    int indexItem = indexLeft[randomIndexFromList];

                    CurrentItem = SortedFLashcardsList[indexItem];
                    indexLeft.RemoveAt(randomIndexFromList);
                }
                else
                {
                    if (SortedFLashcardsList.Count == 0)
                    {
                        SetFlashCardsOrder();
                        

                    }
                    CurrentItem = SortedFLashcardsList[0];
                    SortedFLashcardsList.RemoveAt(0);
                }

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
