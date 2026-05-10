using AH3520;
using UnityEngine;

namespace AH3520
    {
    public class ObjectRemove : ObjectDestroyer
    {
        [SerializeField] private KeyCode activate = KeyCode.Z;

        [SerializeField] private GameObject player;

        public override void DestroyAura()
        {   
            BoxCollider auraCollider;

            auraCollider = player.AddComponent<BoxCollider>();

            auraCollider.isTrigger = true;

            auraCollider.size = new Vector3(5f, 3f, 5f);

            auraCollider.center = new Vector3(0, 1f, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }

        void Update()
        {
            if (Input.GetKeyDown(activate))
            {
                DestroyAura();
            }
        }
    }
}