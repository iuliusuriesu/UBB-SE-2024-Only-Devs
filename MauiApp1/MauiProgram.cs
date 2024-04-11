using MauiApp1.Model;
using MauiApp1.ViewModel;
using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<Repository>(serviceProvider =>
            {
                string usersResource = "MauiApp1.Data.users.xml";
                string chatsResource = "MauiApp1.Data.chats.xml";
                return new Repository(usersResource, chatsResource);
            });

            builder.Services.AddSingleton<Service>(serviceProvider =>
            {
                var repo = serviceProvider.GetRequiredService<Repository>();
                return new Service(repo);
            });

            builder.Services.AddTransient<MainPageViewModel>(serviceProvider =>
            {
                var service = serviceProvider.GetRequiredService<Service>();
                return new MainPageViewModel(service);
            });

            builder.Services.AddTransient<MainPage>(serviceProvider =>
            {
                var viewModel = serviceProvider.GetRequiredService<MainPageViewModel>();
                return new MainPage(viewModel);
            });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
