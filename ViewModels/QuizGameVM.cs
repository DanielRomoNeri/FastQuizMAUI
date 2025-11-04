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

        public QuizGameVM(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        [ObservableProperty]
        private ItemsBoxModel[] _itemsToQuiz;

        [ObservableProperty]
        private ItemsBoxModel _currentItem;

    }
}
