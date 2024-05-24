using BpNT;
using ErpSync.Bpl.Interop.Connection.Pooling;
using ErpSync.Bpl.Interop.Options;

namespace ErpSync.Bpl.Interop.Connection;

public class BplConnection : IBplConnection
{
    /// <summary>   Gets options for controlling the operation. </summary>
    /// <value> The options. </value>
    public BplOptions Options { get; }

    /// <summary>   Gets the application pool. </summary>
    /// <value> The application pool. </value>
    private MaximumObjectPool<BplApplication> ApplicationPool { get; }

    public BplConnection(BplOptions options)
    {
        Options = options;
        ApplicationPool = new MaximumObjectPool<BplApplication>(
            new BplApplicationPoolPolicy(options),
            options.Connection.MaximumConnections
        );
    }

    /// <summary>   Runs the given application. </summary>
    /// <param name="app">  The application. </param>
    public Task Run(Action<Application> app)
    {
        return Task.Run(() =>
        {
            while (!ApplicationPool.CanGet())
            {
                Task.Delay(Options.Connection.RetryTime);
            }
            var appWrapper = ApplicationPool.Get();
            ApplicationTask.WaitAndRun(appWrapper.BpApp!, Options, app);
        });
    }
}