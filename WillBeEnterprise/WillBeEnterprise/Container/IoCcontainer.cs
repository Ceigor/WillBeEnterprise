using Autofac;
using WillBeEnterprise.Services.Http;
using WillBeEnterprise.Services.Navigation;
using WillBeEnterprise.ViewModels;

namespace WillBeEnterprise.Container
{
    public static class IoCcontainer
    {
        private static readonly IContainer container;

        static IoCcontainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<HttpService>().As<IHttpService>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<SetYourGoalViewModel>();
            builder.RegisterType<VideoPlayerViewModel>();
            builder.RegisterType<AudioPlayerViewModel>();
            builder.RegisterType<ChartsViewModel>();
            container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

    }
}
