using UnityEngine;
using UnityEngine.SceneManagement;


namespace AH3520
{ 
    public class SimpleScript : MonoBehaviour
    {
        public SimpleScript simpleScript;

        public Material objectMaterial;

        public string objectName;

        // Update is called once per frame
        void Start()
        {
            simpleScript = FindFirstObjectByType<SimpleScript>();

            if (simpleScript == true)
            {
                Debug.Log(objectName + " was found");
            }
        }
    }
}