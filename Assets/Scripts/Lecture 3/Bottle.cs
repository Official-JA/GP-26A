using UnityEngine;


namespace AH3520
{
    public class Bottle : MonoBehaviour
    { 
        public Material bottleMaterial;
        public string bottleContents;
        [Range(0.0f, 1.0f)]
        public float liquidAmount;
        public bool hasCap = true;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeLiquidAmount(float changeAmount)
        {
            // Change the amount of liquid and safeguard against going below or over the capacity of the bottle
        }
    }
}
