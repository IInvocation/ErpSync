using ErpSync.Bpl.Interop.Options;
using Microsoft.Extensions.ObjectPool;

namespace ErpSync.Bpl.Interop.Connection.Pooling;

/// <summary>   A bpl application pool policy. </summary>
public class BplApplicationPoolPolicy : IPooledObjectPolicy<BplApplication>
{
    /// <summary>   Gets options for controlling the operation. </summary>
    /// <value> The options. </value>
    public BplOptions Options { get; }

    /// <summary>   Constructor. </summary>
    /// <param name="options">  The options. </param>
    public BplApplicationPoolPolicy(BplOptions options)
    {
        Options = options;
    }

    /// <summary>   Create a <typeparamref name="T" />. </summary>
    /// <returns>   The <typeparamref name="T" /> which was created. </returns>
    public BplApplication Create() => new(Options);

    /// <summary>
    ///     Runs some processing when an object was returned to the pool. Can be used to reset the
    ///     state of an object and indicate if the object should be returned to the pool.
    /// </summary>
    /// <param name="obj">  The object to return to the pool. </param>
    /// <returns>
    ///     <see langword="true" /> if the object should be returned to the pool. <see langword="false" />
    ///     if it's not possible/desirable for the pool to keep the object.
    /// </returns>
    public bool Return(BplApplication obj) => true;
}