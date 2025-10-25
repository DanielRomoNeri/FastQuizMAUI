using FastQuizMAUI.ViewModels;

namespace FastQuizMAUI.Pages;

public partial class CreateBoxForm : ContentPage
{
    private readonly CreateBoxFormVM _createBoxFormVM;
    public CreateBoxForm(CreateBoxFormVM createBoxFormVM)
	{
		InitializeComponent();
        _createBoxFormVM = createBoxFormVM;
        _createBoxFormVM.requestClose += (s, e) => CloseForm();
        BindingContext = _createBoxFormVM;

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