using Dark.Net;
using FiscOrganizer.Contracts;
using FiscOrganizer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FiscOrganizer;

/// <summary>
/// Provides the main entry point and service configuration for the FiscOrganizer application.
/// </summary>
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    ///  Initializes application configuration, sets default font, applies theme, configures services, and runs the main form.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.SetDefaultFont(new Font("Century Gothic", 10F));

        DarkNet.Instance.SetCurrentProcessTheme(Theme.Auto);

        var services = new ServiceCollection();
        ConfigureServices(services);

        using var serviceProvider = services.BuildServiceProvider();

        var mainForm = serviceProvider.GetRequiredService<MainForm>();
        DarkNet.Instance.SetWindowThemeForms(mainForm, Theme.Auto);
        Application.Run(mainForm);
    }

    /// <summary>
    /// Configures dependency injection services for the application.
    /// Registers forms and service implementations for use throughout the application.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainForm>();

        services.AddTransient<IOrganizeService, OrganizeService>();
        services.AddTransient<IFileRecognizerService, FileRecognizerService>();
        services.AddTransient<IFileProcessor, EcfFileProcessor>();
        services.AddTransient<IFileProcessor, EcdFileProcessor>();
        services.AddTransient<IFileProcessor, EfdIcmsIpiFileProcessor>();
        services.AddTransient<IFileProcessor, EfdContribuicoesFileProcessor>();
    }
}