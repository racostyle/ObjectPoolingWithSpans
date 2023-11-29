

using UnityEngine;

namespace ObjectPooling
{
    public class POController : MonoBehaviour
    {
        //Default
        public GameObject GameObjectRef { get; private set; }
        public Transform TransformRef { get; private set; }

        //add your own components

        private void Awake()
        {
            GameObjectRef = gameObject;
            TransformRef = transform;
        }
    }
}
