using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.AppCompat.App;

namespace FastQuizMAUI
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Android.OS.Bundle savedInstanceState)
        {
            // --- Agrega esta línea ---
            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;

            base.OnCreate(savedInstanceState);
        }
    }
}
