using UnityEditor;
using UnityEngine;

namespace AH3520
{
    public class ObjectSpawner : ObjectManager
    {
        [SerializeField] private KeyCode spawnKey = KeyCode.T;

        protected override void SpawnObject()
        {
            Vector3 posBehind = transform.position - transform.forward * 1f;

            Instantiate(Card, posBehind, Quaternion.identity);
        }

        void Update()
        {
            if (Input.GetKeyDown(spawnKey))
            {
                SpawnObject();
            }
        }
    }
}
