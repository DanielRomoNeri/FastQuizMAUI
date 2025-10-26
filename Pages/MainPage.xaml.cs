using System.Threading.Tasks;
using FastQuizMAUI.ViewModels;

namespace FastQuizMAUI.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly MainPageVM _mainPageVM;

        public MainPage(IServiceProvider serviceProvider, MainPageVM mainPageVM)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _mainPageVM = mainPageVM;
            BindingContext = _mainPageVM;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _mainPageVM.InitAsync();


        }

        private async void btnNewBox_Clicked(object sender, EventArgs e)
        {
            var page = _serviceProvider.GetRequiredService<CreateBoxForm>();
            await Navigation.PushModalAsync(page);
        }
    }

}
