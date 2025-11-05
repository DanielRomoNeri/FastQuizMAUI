using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using FastQuizMAUI.Models;
using FastQuizMAUI.Services;

namespace FastQuizMAUI.ViewModels
{
    [QueryProperty(nameof(ItemsToQuiz), "ItemsToQuiz")]
    public partial class QuizGameVM : ObservableObject
    {
        private readonly DatabaseService _databaseService;
        private readonly Random random = new Random();
        private List<int> indexLeft = new List<int>();
        public QuizGameVM(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void SetIndexLeft()
        {
            for (int i = 0; i < ItemsToQuiz.Length; i++)
            {
                indexLeft.Add(i);
            }
        }

        [ObservableProperty]
        private ItemsBoxModel[] _itemsToQuiz;

        [ObservableProperty]
        private ItemsBoxModel _currentItem;


        private void SetNewCard()
        {
            if(indexLeft.Count > 0)
            {
                int randomIndexFromList = random.Next(0, indexLeft.Count);

                int indexItem = indexLeft[randomIndexFromList];

                CurrentItem = ItemsToQuiz[indexItem];
                indexLeft.RemoveAt(randomIndexFromList);
            }

        }
    }
}
