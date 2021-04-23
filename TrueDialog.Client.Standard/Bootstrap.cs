using Microsoft.Extensions.DependencyInjection;

using TrueDialog.Configuration;

namespace TrueDialog
{
    public static class Bootstrap
    {
        public static IServiceCollection UseTrueDialog(this IServiceCollection services, bool singleton = true)
        {
            if (singleton)
                return services
                    .AddSingleton<ITrueDialogConfigProvider, TrueDialogConfigProvider>()
                    .AddSingleton<ITrueDialogClient, TrueDialogClient>();
            else
                return services
                    .AddScoped<ITrueDialogConfigProvider, TrueDialogConfigProvider>()
                    .AddScoped<ITrueDialogClient, TrueDialogClient>();
        }

        public static IServiceCollection UseTrueDialog<T>(this IServiceCollection services, bool singleton = true)
            where T: ITrueDialogConfigProvider
        {
            if (singleton)
                return services
                    .AddSingleton(typeof(ITrueDialogConfigProvider), typeof(T))
                    .AddSingleton<ITrueDialogClient, TrueDialogClient>();
            else
                return services
                    .AddScoped(typeof(ITrueDialogConfigProvider), typeof(T))
                    .AddScoped<ITrueDialogClient, TrueDialogClient>();
        }
    }
}
