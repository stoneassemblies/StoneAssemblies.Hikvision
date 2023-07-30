namespace StoneAssemblies.Hikvision.Collections;

public class ConcurrentHashSet<T> : IDisposable
{
    private readonly ReaderWriterLockSlim syncObj = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

    private readonly HashSet<T> hashSet = new HashSet<T>();

    public bool Add(T item)
    {
        syncObj.EnterWriteLock();
        try
        {
            return hashSet.Add(item);
        }
        finally
        {
            if (syncObj.IsWriteLockHeld)
            {
                syncObj.ExitWriteLock();
            }
        }
    }

    public void Clear()
    {
        syncObj.EnterWriteLock();
        try
        {
            hashSet.Clear();
        }
        finally
        {
            if (syncObj.IsWriteLockHeld)
            {
                syncObj.ExitWriteLock();
            }
        }
    }

    public bool Contains(T item)
    {
        syncObj.EnterReadLock();
        try
        {
            return hashSet.Contains(item);
        }
        finally
        {
            if (syncObj.IsReadLockHeld)
            {
                syncObj.ExitReadLock();
            }
        }
    }

    public bool Remove(T item)
    {
        syncObj.EnterWriteLock();
        try
        {
            return hashSet.Remove(item);
        }
        finally
        {
            if (syncObj.IsWriteLockHeld)
            {
                syncObj.ExitWriteLock();
            }
        }
    }

    public int Count
    {
        get
        {
            syncObj.EnterReadLock();
            try
            {
                return hashSet.Count;
            }
            finally
            {
                if (syncObj.IsReadLockHeld)
                {
                    syncObj.ExitReadLock();
                }
            }
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            this.syncObj.Dispose();
        }
    }

    ~ConcurrentHashSet()
    {
        Dispose(false);
    }
}