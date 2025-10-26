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
    [QueryProperty(nameof(BoxToDisplay), "SelectedBox")]
    public partial class InsideBoxVM : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        public InsideBoxVM(DatabaseService databaseService)
        {
            _databaseService = databaseService;

        }

        [ObservableProperty]
        BoxModel _boxToDisplay;
    }

}
