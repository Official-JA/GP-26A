using UnityEngine;
//using AA0000;
//using Random = System.Random;

namespace AA0000
{
	public class TestUser : MonoBehaviour
	{
		public ExampleScript exampleScript;
		public TestingScript testingScript = null;
		public float x = 0.0f;
		[SerializeField] private Transform target; // This is not initialized and even if you drag-n-drop a transform into this, it will be overridden by this game objects' transform in the Start-method

		// Start is called once before the first execution of Update after the MonoBehaviour is created
		void Start()
		{
			exampleScript = FindFirstObjectByType<ExampleScript>();
			testingScript = FindFirstObjectByType<TestingScript>();
			if (testingScript == null)
			{
				Debug.Log("Did not find a testing script");
			}
			else
			{
				Debug.Log("Did find a testing script");
			}

			target = transform;
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Y))
			{
				x += 5.0f;
				exampleScript.CustomMethod();
			}
		}
	} 
}