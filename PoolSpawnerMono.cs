using UnityEngine;

namespace ObjectPooling
{
    public class PoolSpawnerMono : MonoBehaviour
    {
        internal GameObject CreateNewObject(GameObject reference, Transform container)
        {
            GameObject obj = Instantiate(reference, container);
            return obj;
        }

        internal void Terminate(POController[] pool)
        {
            foreach (POController obj in pool)
                Destroy(obj);
        }
    }
}

