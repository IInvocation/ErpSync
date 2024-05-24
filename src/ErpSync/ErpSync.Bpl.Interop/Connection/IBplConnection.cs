using BpNT;
using ErpSync.Bpl.Interop.Options;

namespace ErpSync.Bpl.Interop.Connection;

/// <summary>   Interface for bpl connection. </summary>
public interface IBplConnection
{
    /// <summary>   Gets options for controlling the operation. </summary>
    /// <value> The options. </value>
    BplOptions Options { get; }

    /// <summary>   Runs the given application. </summary>
    /// <param name="app">  The application. </param>
    Task Run(Action<Application> app);
}