using FastQuizMAUI.ViewModels;

namespace FastQuizMAUI.Pages;

public partial class AddItemForm : ContentPage
{
    private readonly AddItemFormVM _addItemFormVM;

    public AddItemForm(AddItemFormVM addItemFormVM)
	{
		InitializeComponent();
        _addItemFormVM = addItemFormVM;
        BindingContext = _addItemFormVM;
    }
}