using Microsoft.Maui.Controls.Platform;

#if ANDROID
using Android.Content;
using Android.Views.InputMethods;
#elif WINDOWS
using Windows.UI.ViewManagement;
#endif
namespace FastQuizMAUI.Helpers
{
    public static class KeyboardHelper
    {
        public static void HideKeyboard()
        {
#if ANDROID
        var context = Platform.CurrentActivity;
        if (context == null) return;

        var inputMethodManager = context.GetSystemService(Context.InputMethodService) as InputMethodManager;
        if (inputMethodManager == null) return;

        // El 'Activity.CurrentFocus' puede ser nulo si Unfocus() ya se llamó
        var currentFocus = context.CurrentFocus;
        
        // Si no hay foco, creamos una vista temporal para obtener el token
        // Esto es crucial para que funcione después de un Unfocus()
        var token = currentFocus?.WindowToken ?? new Android.Views.View(context).WindowToken;

        if (token != null)
        {
            inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);
        }

        
#elif WINDOWS
            var inputPane = InputPane.GetForCurrentView();
            if (inputPane != null && inputPane.Visible)
            {
                inputPane.TryHide();
            }
#endif
        }
    }

}
