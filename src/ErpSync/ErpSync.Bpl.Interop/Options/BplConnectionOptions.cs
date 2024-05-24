namespace ErpSync.Bpl.Interop.Options;

/// <summary>   A bpl connection options. </summary>
public class BplConnectionOptions
{
    /// <summary>   Gets or sets the maximum connections. </summary>
    /// <value> The maximum connections. </value>
    public short MaximumConnections { get; set; } = 1;

    /// <summary>   Gets or sets the connection timeout. </summary>
    /// <value> The connection timeout. </value>
    public TimeSpan ConnectionTimeout { get; set; } = TimeSpan.FromMinutes(2);

    /// <summary>   Gets or sets the retry time. </summary>
    /// <value> The retry time. </value>
    public TimeSpan RetryTime { get; set; } = TimeSpan.FromSeconds(5);

    /// <summary>   Gets or sets the query limit. </summary>
    /// <value> The query limit. </value>
    public short QueryRecordLimit { get; set; } = 500;
}