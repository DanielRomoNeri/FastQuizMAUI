using FastQuizMAUI.ViewModels;

namespace FastQuizMAUI.Pages;

public partial class AddItemForm : ContentPage
{
    private readonly AddItemFormVM _addItemFormVM;

    public AddItemForm(AddItemFormVM addItemFormVM)
	{
		InitializeComponent();
        _addItemFormVM = addItemFormVM;
        _addItemFormVM.RequestHideKeyboard += (s, e) => HideKeyboard();
        _addItemFormVM.RequestCloseForm += (s, e) => CloseForm();
        BindingContext = _addItemFormVM;
    }

    public int BoxId { set; get; }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _addItemFormVM.SetBoxId(BoxId);
    }

    private void HideKeyboard()
    {
        //In order to hide keyboard the TextBoxes must be disabled and enabled again
        tbFrontText.IsEnabled = false;
        tbBackText.IsEnabled = false;
        tbContext.IsEnabled = false;
        tbFrontText.IsEnabled = true;
        tbBackText.IsEnabled = true;
        tbContext.IsEnabled = true;
    }
    private async void CloseForm()
    {
        await Navigation.PopModalAsync();
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        CloseForm();
    }
}