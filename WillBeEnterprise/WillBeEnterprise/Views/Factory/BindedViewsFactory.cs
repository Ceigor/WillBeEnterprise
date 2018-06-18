﻿using WillBeEnterprise.Container;
using WillBeEnterprise.Exceptions;
using WillBeEnterprise.ViewModels.Base;
using Xamarin.Forms;

namespace WillBeEnterprise.Views.Factory
{
    public static class BindedViewsFactory
    {
        public static View CreateBindedView<View, ViewModel>()
            where View : Page
            where ViewModel : BaseViewModel
        {
            var view = CreateView<View>();
            view.BindingContext = CreateViewModel<ViewModel>();
            return view;
        }

        private static View CreateView<View>() where View : Page
        {
            if (typeof(View) == typeof(MainView))
                return (new MainView() as View);
            if (typeof(View) == typeof(LoginView))
                return (new LoginView() as View);
            if (typeof(View) == typeof(SetYourGoalView))
                return (new SetYourGoalView() as View);
            if (typeof(View) == typeof(SetYourGoalFirstView))
                return (new SetYourGoalFirstView() as View);
            if (typeof(View) == typeof(VideoPlayerView))
                return (new VideoPlayerView() as View);
            if (typeof(View) == typeof(AudioPlayerView))
                return (new AudioPlayerView() as View);
            if (typeof(View) == typeof(ChartsView))
                return (new ChartsView() as View);
            throw NoSuchViewException.CreateException(typeof(View));
        }

        private static ViewModel CreateViewModel<ViewModel>() where ViewModel : BaseViewModel
        {
            return IoCcontainer.Resolve<ViewModel>();
        }
    }
}
