using UnityEditor;
using UnityEngine;

namespace AH3520
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject Card;

        [SerializeField] private KeyCode spawnKey = KeyCode.T;
        
        private GameObject Spawner;

        private float distance = 1.0f;

        protected virtual void SpawnObject()
        {
            Vector3 pos = transform.position + (transform.forward * distance); 

            Instantiate(Card, pos, Quaternion.identity);
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
