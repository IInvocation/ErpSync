using ErpSync.Bpl.Interop.Connection;

namespace ErpSync.Bpl.Interop.Services;

/// <summary>   A service for accessing schemas information. </summary>
public class SchemaService : ISchemaService
{
    /// <summary>   Constructor. </summary>
    /// <param name="connection">   The connection. </param>
    public SchemaService(IBplConnection connection)
    {
        Connection = connection;
    }

    /// <summary>   Gets the connection. </summary>
    /// <value> The connection. </value>
    public IBplConnection Connection { get; }

    /// <summary>   Count data sets asynchronous. </summary>
    /// <returns>   The count data sets. </returns>
    public async Task<int> CountDataSetsAsync()
    {
        var count = 0;
        await Connection.Run(app =>
        {
            count = app.DataSetInfos.Count;
        });
        return count;
    }
}