using UnityEngine;

namespace AH3520
{
    public class ObjectManager : MonoBehaviour
    {        
        [SerializeField] protected GameObject Card;
        
        private GameObject Spawner;

        private float distance = 1.0f;
                
        protected virtual void SpawnObject()
        {
            Vector3 posForward = transform.position + (transform.forward * distance);

            Instantiate(Card, posForward, Quaternion.identity);
        }
    }
}
