using Microsoft.Extensions.ObjectPool;
using System.Runtime.CompilerServices;

namespace ErpSync.Bpl.Interop.Connection.Pooling;

/// <summary>   A maximum object pool. </summary>
/// <typeparam name="T">    Generic type parameter. </typeparam>
public class MaximumObjectPool<T> : ObjectPool<T>, IDisposable where T : class, IDisposable
{
    private protected readonly ObjectWrapper[] Items;
    private protected readonly IPooledObjectPolicy<T> Policy;
    private readonly object _locker = new();

    /// <summary>
    /// Creates an instance of <see cref="DefaultObjectPool{T}"/>.
    /// </summary>
    /// <param name="policy">The pooling policy to use.</param>
    /// <param name="maximum">The maximum number of objects in the pool.</param>
    public MaximumObjectPool(IPooledObjectPolicy<T> policy, int maximum)
    {
        Policy = policy ?? throw new ArgumentNullException(nameof(policy));
        Items = new ObjectWrapper[maximum];

        for (var i = 0; i < maximum; i++)
            Items[i] = new ObjectWrapper { InUse = false, Element = Create() };
    }

    /// <inheritdoc />
    public override T Get()
    {
        lock (_locker)
        {
            var item = Items.First(i => !i.InUse);
            item.InUse = true;
            return item.Element!;
        }
    }

    // Non-inline to improve its code quality as uncommon path
    [MethodImpl(MethodImplOptions.NoInlining)]
    private T Create() => Policy.Create();

    /// <inheritdoc />
    public override void Return(T obj)
    {
        lock (_locker)
        {
            for (var i = 0; i < Items.Length; i++)
                if (Items[i].Element == obj)
                    Items[i].InUse = false;
        }
    }

    /// <summary>   Determine if we can get. </summary>
    /// <returns>   True if we can get, false if not. </returns>
    public bool CanGet()
    {
        lock (_locker)
        {
            return Items.Any(i => !i.InUse);
        }
    }

    /// <summary>   An object wrapper. </summary>
    private protected struct ObjectWrapper
    {
        public bool InUse;
        public T? Element;
    }

    /// <summary>
    ///     Performs application-defined tasks associated with freeing, releasing, or resetting
    ///     unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        foreach (var item in Items)
        {
            item.Element?.Dispose();
        }
    }
}