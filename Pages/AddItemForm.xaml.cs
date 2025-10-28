using FastQuizMAUI.ViewModels;

namespace FastQuizMAUI.Pages;

public partial class AddItemForm : ContentPage
{
    private readonly AddItemFormVM _addItemFormVM;

    public AddItemForm(AddItemFormVM addItemFormVM)
	{
		InitializeComponent();
        _addItemFormVM = addItemFormVM;
        _addItemFormVM.RequestUnfocus += UnfocusEdition;
        BindingContext = _addItemFormVM;
    }

    private void UnfocusEdition(object sender, EventArgs e)
    {
        tbFrontText.Unfocus();
        tbBackText.Unfocus();
        tbContext.Unfocus();
    }
}