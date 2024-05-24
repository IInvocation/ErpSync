namespace ErpSync.Bpl.Interop.Options;

/// <summary>   A bpl login options. </summary>
public class BplLoginOptions
{
    /// <summary>   Gets or sets the username. </summary>
    /// <value> The username. </value>
    public string Username { get; set; } = string.Empty;

    /// <summary>   Gets or sets the password. </summary>
    /// <value> The password. </value>
    public string Password { get; set; } = string.Empty;

    /// <summary>   Gets or sets the client. </summary>
    /// <value> The client. </value>
    public string Client { get; set; } = string.Empty;
}