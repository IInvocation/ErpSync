using BpNT;
using ErpSync.Bpl.Interop.Options;

namespace ErpSync.Bpl.Interop.Connection;

/// <summary>   An application task. </summary>
internal static class ApplicationTask
{
    private static readonly object Locker = new();

    /// <summary>   Wait and run. </summary>
    /// <param name="app">      The application. </param>
    /// <param name="options">  Options for controlling the operation. </param>
    /// <param name="action">   The action. </param>
    public static void WaitAndRun(Application app, BplOptions options, Action<Application> action)
    {
        var taken = false;
        try
        {
            Monitor.TryEnter(Locker, options.Connection.ConnectionTimeout, ref taken);
            if (taken)
            {
                var thread = new Thread(() => action(app));
#pragma warning disable CA1416 // Plattformkompatibilität überprüfen
                thread.SetApartmentState(ApartmentState.STA);
#pragma warning restore CA1416 // Plattformkompatibilität überprüfen
                thread.Start();
                thread.Join();
            }
            else
            {
                throw new TimeoutException(
                    "Could not execute task within timeout. Check for deadlocks and/or increase timeout");
            }
        }
        finally
        {
            if (taken)
            {
                Monitor.Exit(Locker);
            }
        }
    }
}