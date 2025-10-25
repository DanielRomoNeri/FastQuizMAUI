using System.Threading.Tasks;
using FastQuizMAUI.ViewModels;

namespace FastQuizMAUI.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly CreateBoxForm _createBoxForm;
        private readonly MainPageVM _mainPageVM;

        public MainPage(CreateBoxForm createBoxForm, MainPageVM mainPageVM)
        {
            InitializeComponent();
            _createBoxForm = createBoxForm;
            _mainPageVM = mainPageVM;
            BindingContext = _mainPageVM;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _mainPageVM.LoadBoxesAsync();
        }
        private async void btnNewBox_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(_createBoxForm);
        }
    }

}
