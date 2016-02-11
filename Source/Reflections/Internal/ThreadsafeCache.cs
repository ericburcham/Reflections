using System.Collections.Generic;
using System.Threading;

namespace Reflections
{
    internal class ThreadsafeCache<TKey, TValue>
    {
        public ThreadsafeCache()
        {
            Cache = new Dictionary<TKey, TValue>();
            CacheLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);

            CacheLock.EnterUpgradeableReadLock();
            try
            {
                return Cache.TryGetValue(key, out value);
            }
            finally
            {
                CacheLock.ExitUpgradeableReadLock();
            }
        }

        public bool TryAdd(TKey key, TValue value)
        {
            CacheLock.EnterUpgradeableReadLock();

            try
            {
                if (Cache.DoesNotContainKey(key))
                {
                    CacheLock.EnterWriteLock();

                    try
                    {
                        Cache.Add(key, value);
                        return true;
                    }
                    finally
                    {
                        CacheLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                CacheLock.ExitUpgradeableReadLock();
            }

            return false;
        }

        protected Dictionary<TKey, TValue> Cache { get; }

        protected ReaderWriterLockSlim CacheLock { get; }

    }
}