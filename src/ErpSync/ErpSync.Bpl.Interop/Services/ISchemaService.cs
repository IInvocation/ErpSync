namespace ErpSync.Bpl.Interop.Services;

/// <summary>   Interface for schema service. </summary>
public interface ISchemaService
{
    /// <summary>   Count data sets asynchronous. </summary>
    /// <returns>   The count data sets. </returns>
    Task<int> CountDataSetsAsync();
}