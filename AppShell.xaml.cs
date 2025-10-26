using FastQuizMAUI.Pages;

namespace FastQuizMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Registra la página de detalle
            Routing.RegisterRoute(nameof(InsideBoxPage), typeof(InsideBoxPage));
        }
    }
}
