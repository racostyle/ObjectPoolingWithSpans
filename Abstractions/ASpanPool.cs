using System;
using UnityEngine;

namespace ObjectPooling
{
    internal abstract class APool<T>
    {
        internal abstract void Init(GameObject reference, PoolSpawnerMono objectSpawner, Transform container, int maxSize, int poolIncreciment);
        internal abstract int GetPoolSize();
        internal abstract SSpawnData SpawnOrEnableObject();
        internal abstract void Terminate();
        internal abstract Span<T> GetObjectsInPool();

        //only used in pool
        protected virtual T EnableFirstAvailableObject(int objToActivate, Span<T> span)
        {
            throw new NotImplementedException();
        }
        protected virtual int IncreasePoolSize(Transform container)
        {
            throw new NotImplementedException();
        }
    }
}
