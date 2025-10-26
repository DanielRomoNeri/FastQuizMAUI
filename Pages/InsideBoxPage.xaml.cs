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
        _serviceProvider = serviceProvider;
        BindingContext = _insideBoxVM;
    }

    private async void btnNewItem_Clicked(object sender, EventArgs e)
    {
        var page = _serviceProvider.GetRequiredService<AddItemForm>();
        await Navigation.PushModalAsync(page);
    }
}