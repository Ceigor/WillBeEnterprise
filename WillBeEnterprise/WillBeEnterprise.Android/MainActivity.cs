﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Platform;

namespace WillBeEnterprise.Droid
{
    [Activity(Label = "WillBeEnterprise", Icon = "@mipmap/icon", Theme = "@style/SplashScreenTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            CachedImageRenderer.Init(true);
            SetMainTheme();
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private void SetMainTheme()
        {
            base.SetTheme(Resource.Style.MainTheme);
            base.Window.RequestFeature(WindowFeatures.ActionBar);
        }
    }
}

