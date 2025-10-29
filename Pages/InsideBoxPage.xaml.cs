using System.Threading.Tasks;
using FastQuizMAUI.ViewModels;

namespace FastQuizMAUI.Pages;

public partial class InsideBoxPage : ContentPage
{
    
	private readonly InsideBoxVM _insideBoxVM;
    private readonly IServiceProvider _serviceProvider;

    public InsideBoxPage(InsideBoxVM insideBoxVM, IServiceProvider serviceProvider)
	{
		InitializeComponent();
        _insideBoxVM = insideBoxVM;
        _insideBoxVM.RequestOpenForm += OpenForm;
        _serviceProvider = serviceProvider;
        BindingContext = _insideBoxVM;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _insideBoxVM.InitAsync();

    }
    private async void OpenForm(object s, EventArgs e)
    {
        var page = _serviceProvider.GetRequiredService<AddItemForm>();
        page.BoxId = _insideBoxVM.BoxToDisplay.Id;
        await Navigation.PushModalAsync(page);
    }
}