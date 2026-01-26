using UnityEngine;
using AH3520;

namespace AA0000
{
    public class TestUser : MonoBehaviour
    {
        public TestingScript testingScript = null;
        public float x = 0.0f;
        [SerializeField] private Transform target;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            testingScript = FindFirstObjectByType<TestingScript>();
            if (testingScript == null)
            {
                Debug.Log("Did not find a testing script");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                x += 5.0f;
            }
        }
    }
}