using FluiTec.AppFx.Console.Modularization;
using System.CommandLine;
using ErpSync.Bpl.Interop.Services;

namespace ErpSync.Bpl.SchemaConsole.Commands;

/// <summary>   A greet command. </summary>
public class PrintSchemasCommand : IConsoleCommand
{
    /// <summary>   Gets the schema service. </summary>
    /// <value> The schema service. </value>
    public ISchemaService SchemaService { get; }

    /// <summary>   Constructor. </summary>
    /// <param name="schemaService">    The schema service. </param>
    public PrintSchemasCommand(ISchemaService schemaService)
    {
        SchemaService = schemaService;
    }

    /// <summary>   Configure command. </summary>
    /// <returns>   A Command. </returns>
    public Command ConfigureCommand()
    {
        var cmd = new Command("--printall", "Print all Schemas");
        cmd.SetHandler(_ =>
        {
            Console.WriteLine($"Avaiable Schemas: {SchemaService.CountDataSetsAsync()}");
        });
        return cmd;
    }
}