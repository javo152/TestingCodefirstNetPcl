using Microsoft.Extensions.Logging;

namespace TestingCodefirstNetPcl
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

            // Register Database Context (shared connection).
            // Table initialization is deferred to the first repository call via Lazy<Task>.
            builder.Services.AddSingleton<Framework.DatabaseContext>();

            // Register Repositories
            builder.Services.AddSingleton<Data.CompanyRepository>();
            builder.Services.AddSingleton<Data.DepartmentRepository>();
            builder.Services.AddSingleton<Data.EmployeeRepository>();
            builder.Services.AddSingleton<Data.ProjectRepository>();
            builder.Services.AddSingleton<Data.TaskItemRepository>();

            // Register pages/viewmodels as needed
            builder.Services.AddTransient<MainPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
