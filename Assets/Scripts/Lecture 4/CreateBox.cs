using UnityEngine;

namespace AH3520
{
    public class CreateBox : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            GameObject gameObject = new GameObject("Example", typeof(Rigidbody), typeof(BoxCollider));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
