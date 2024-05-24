namespace ErpSync.Bpl.Interop.Options;

/// <summary>   A bpl options. </summary>
public class BplOptions
{
    /// <summary>   Gets or sets the login. </summary>
    /// <value> The login. </value>
    public BplLoginOptions Login { get; set; } = null!;

    /// <summary>   Gets or sets the connection. </summary>
    /// <value> The connection. </value>
    public BplConnectionOptions Connection { get; set; } = null!;
}