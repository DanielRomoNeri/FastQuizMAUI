using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using FastQuizMAUI.ViewModels;

namespace FastQuizMAUI.Pages;

public partial class ItemDetailPage : ContentPage
{
    private readonly ItemDetailVM _itemDetailVM;

    public ItemDetailPage(ItemDetailVM itemDetailVM)
	{
		InitializeComponent();
        _itemDetailVM = itemDetailVM;
        BindingContext = _itemDetailVM;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        if (_itemDetailVM.IsDataOutDated)
        {
            await _itemDetailVM.ReloadItem();
        }
        _itemDetailVM.SetStatus();
    }

    private async void borderFrontCard_Tapped(object sender, TappedEventArgs e)
    {
        await borderFrontCard.ScaleTo(0.5, 100);
        await borderFrontCard.RotateYTo(90, 150, Easing.Linear);
        borderFrontCard.IsVisible = false;
        borderBackCard.IsVisible = true;
        await borderBackCard.RotateYTo(360, 150, Easing.Linear);
        await borderBackCard.ScaleTo(1, 100);

    }

    private async void borderBackCard_Tapped(object sender, TappedEventArgs e)
    {
        await borderBackCard.ScaleTo(0.5, 100);
        await borderBackCard.RotateYTo(270, 150, Easing.Linear);
        borderBackCard.IsVisible = false;
        borderFrontCard.IsVisible = true;
        await borderFrontCard.RotateYTo(0, 150, Easing.Linear);
        await borderFrontCard.ScaleTo(1, 100);

    }
}