using FastQuizMAUI.Pages;

namespace FastQuizMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Registra de páginas en Shell
            Routing.RegisterRoute(nameof(InsideBoxPage), typeof(InsideBoxPage));
            Routing.RegisterRoute(nameof(EditItemForm), typeof(EditItemForm));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(QuizGamePage), typeof(QuizGamePage));
        }
    }
}
