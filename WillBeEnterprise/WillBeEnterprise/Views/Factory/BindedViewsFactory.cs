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
            throw NoSuchViewException.CreateException(typeof(View));
        }

        private static ViewModel CreateViewModel<ViewModel>() where ViewModel : BaseViewModel
        {
            return IoCcontainer.Resolve<ViewModel>();
        }
    }
}