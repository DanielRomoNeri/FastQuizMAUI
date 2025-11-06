using FastQuizMAUI.ViewModels;

namespace FastQuizMAUI.Pages;

public partial class QuizGamePage : ContentPage
{
    private readonly QuizGameVM _quizGameVM;

    public QuizGamePage(QuizGameVM quizGameVM)
	{
		InitializeComponent();
        _quizGameVM = quizGameVM;
        _quizGameVM.ResetCardPos += (s, e) => ResetCardPos();
        BindingContext = _quizGameVM;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _quizGameVM.Initialize();
    }   
    private void ResetCardPos()
    {
        borderFrontCard.RotationY = 0;
        borderBackCard.RotationY = 270;
        borderFrontCard.Scale = 1;
        borderBackCard.Scale = 0.5;
        borderFrontCard.IsVisible = true;
        borderBackCard.IsVisible = false;
    }
    private async void borderFrontCard_Tapped(object sender, TappedEventArgs e)
    {
        await borderFrontCard.ScaleTo(0.5, 100);
        await borderFrontCard.RotateYTo(90, 150, Easing.Linear);
        borderFrontCard.IsVisible = false;
        borderBackCard.IsVisible = true;
        await borderBackCard.RotateYTo(360, 150, Easing.Linear);
        await borderBackCard.ScaleTo(1, 100);
        _quizGameVM.ShowDifficultySelectionCommand.Execute(null);

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