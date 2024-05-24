using ErpSync.Bpl.Interop.Connection;
using ErpSync.Bpl.Interop.Options;
using ErpSync.Bpl.Interop.Services;
using ErpSync.Bpl.SchemaConsole.Commands;
using FluiTec.AppFx.Console.Hosting;
using FluiTec.AppFx.Console.Modularization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ErpSync.Bpl.SchemaConsole;

/// <summary>
///     A startup.
/// </summary>
public class Startup : DefaultStartup
{
    /// <summary>
    ///     Configure services.
    /// </summary>
    /// <param name="context">  The context. </param>
    /// <param name="services"> The services. </param>
    public override void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddHostedService<HostedProgram>();
        services.AddLogging();

        services.Configure<BplOptions>(context.Configuration.GetSection("BPL"));

        services.AddSingleton<ISchemaService, SchemaService>();
        services.AddSingleton<IBplConnection, BplConnection>();
        services.AddTransient<IConsoleCommand, PrintSchemasCommand>();
    }
}