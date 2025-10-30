using FastQuizMAUI.ViewModels;

namespace FastQuizMAUI.Pages;

public partial class EditItemForm : ContentPage
{
    private readonly EditItemFormVM _editItemFormVM;

    public EditItemForm(EditItemFormVM editItemFormVM)
	{
		InitializeComponent();
        _editItemFormVM = editItemFormVM;
        BindingContext = _editItemFormVM;
    }
}