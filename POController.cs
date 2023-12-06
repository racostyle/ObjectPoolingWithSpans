using UnityEngine;

namespace ObjectPooling
{
    public class POController : MonoBehaviour
    {
        //Default
        public GameObject GameObjectRef { get; private set; }
        public Transform TransformRef { get; private set; }
        //Needed
        public Enemy Enemy { get; private set; }
        public DistanceDiff DistanceDiff { get; private set; }
        public Health Health { get; private set; }
        public DoTSFX DoTSFX { get; private set; }

        private void Awake()
        {
            Enemy = GetComponent<Enemy>();
            DistanceDiff = GetComponent<DistanceDiff>();
            Health = GetComponent<Health>();
            DoTSFX = GetComponent<DoTSFX>();
            GameObjectRef = gameObject;
            TransformRef = transform;
        }

        internal void InitalizeOnStartup(AEventManager evm, Transform playerTransform, Vector3 newPos, float spawnDist)
        {
            Enemy.InitalizeOnStartup(evm);
            Init(playerTransform, newPos, spawnDist);
        }

        internal void Init(Transform playerTransform, Vector3 newPos, float spawnDist)
        {
            TransformRef.position = new Vector3(newPos.x * spawnDist, newPos.y, newPos.z * spawnDist);
            Enemy.PassPlayerTransform(playerTransform);
        }
    }
}
