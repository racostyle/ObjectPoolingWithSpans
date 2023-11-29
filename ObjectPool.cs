using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    internal class ObjectPool<T> : APool<T> where T : POController
    {
        private GameObject _reference;
        //object pool
        private T[] _poPool;
        private int _poolSize;
        private int _poolIncreciment;
        private Transform _container;
        private PoolSpawnerMono _objectSpawner;
        //stack
        private Stack<int> _spawnStack;

        internal override void Init(GameObject reference, PoolSpawnerMono objectSpawner, Transform container, int maxSize, int poolIncreciment = 10)
        {
            _reference = reference;
            _poolIncreciment = poolIncreciment;
            _poPool = new T[maxSize];
            _objectSpawner = objectSpawner;
            _container = container;

            IncreasePoolSize(_container);
        }
        internal override Span<T> GetObjectsInPool()
        {
            Span<T> span = new Span<T>(_poPool);
            return span;
        }

        internal override int GetPoolSize()
        {
            return _poolSize;
        }

        internal override SSpawnData SpawnOrEnableObject()
        {
            int index = 0;
            Span<T> span = new Span<T>(_poPool);
            while (index < _poolSize)
            {
                if (!_poPool[index].GameObjectRef.activeSelf)
                {
                    var obj = EnableFirstAvailableObject(index, span);
                    if (obj != null)
                        return new SSpawnData { PooledObject = obj, IsNew = false };
                }
                index++;
            }
            int objToActivate = IncreasePoolSize(_container);
            return new SSpawnData { PooledObject = EnableFirstAvailableObject(objToActivate, span), IsNew = true };
        }

        protected override T EnableFirstAvailableObject(int objToActivate, Span<T> span)
        {
            if (objToActivate > -1)
            {
                span[objToActivate].GameObjectRef.SetActive(true);
                return span[objToActivate];
            }
            return null;
        }

        protected override int IncreasePoolSize(Transform container)
        {
            int objectToActivate = -1;
            if (_poolSize < _poPool.Length)
            {
                int i = _poolSize;
                objectToActivate = i;

                _poolSize += _poolIncreciment;
                if (_poolSize > _poPool.Length)
                    _poolSize = _poPool.Length;

                while (i < _poolSize)
                {
                    GameObject obj = _objectSpawner.CreateNewObject(_reference, container);
                    _poPool[i] = obj.GetComponent<T>();
                    _poPool[i].GameObjectRef.SetActive(false);
                    i++;
                }
            }
            return objectToActivate;
        }

        internal override void Terminate()
        {
            _objectSpawner.Terminate(_poPool);
        }
    }
}

