using Microsoft.Extensions.DependencyInjection;

using TrueDialog.Configuration;

namespace TrueDialog
{
    public static class Bootstrap
    {
        public static IServiceCollection UseTrueDialog(this IServiceCollection services, bool singleton = true)
        {
            if (singleton)
                return services.AddSingleton<ITrueDialogClient, TrueDialogClient>();
            else
                return services.AddScoped<ITrueDialogClient, TrueDialogClient>();
        }

        public static IServiceCollection UseTrueDialog(this IServiceCollection services, IConfiguration config)
        {
            return services.AddSingleton<ITrueDialogClient>((sp) => { return new TrueDialogClient(config); });
        }
    }
}
