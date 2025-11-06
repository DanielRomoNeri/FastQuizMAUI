using FastQuizMAUI.ViewModels;

namespace FastQuizMAUI.Pages;

public partial class QuizOptionsPage : ContentPage
{
    private readonly QuizOptionVM _quizOptionVM;

    public QuizOptionsPage(QuizOptionVM quizOptionVM)
	{
		InitializeComponent();
        _quizOptionVM = quizOptionVM;
        BindingContext = _quizOptionVM;
    }
}