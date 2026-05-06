using System.Collections.Generic;
using UnityEngine;

namespace AA0000
{
    public class ExampleScript : MonoBehaviour
	{
        #region Variables
        public Transform m_TestTransform;
        public List<GameObject> gameObjects;
        [SerializeField] private GameObject dummyObject;
        public float testFloat = 5.0f;
        public double testDouble = 5.0d;
        public int testInteger = 5; 
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            m_TestTransform = FindFirstObjectByType<Transform>();
            //Transform temporaryTransform = transform;
            //m_TestTransform = transform;
        }

        // Update is called once per frame
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                testInteger += 1;
                CustomMethod();
            }
        }

        public void CustomMethod()
        { 
            testDouble += 10.0d;
            testFloat += 100.0f;
        }
    }
}