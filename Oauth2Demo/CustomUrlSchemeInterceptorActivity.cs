
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using System;

namespace Oauth2Demo
{
    [Activity(Label = "CustomUrlSchemeInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(
    new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataSchemes = new[] { "https://github.com" },
    DataPath = "/oauth2redirect")]
    public class CustomUrlSchemeInterceptorActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var uri = new Uri(Intent.Data.ToString());
            MainActivity activity = new MainActivity();
            activity.autenthicator.OnPageLoading(uri);
            Finish();
        }
    }
}