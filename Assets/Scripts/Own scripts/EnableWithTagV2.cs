using UnityEngine;
using AH3520;

namespace AH3520
{
    public class EnableWithTagV2 : MonoBehaviour
    {
        [SerializeField] private BlackJackV2 blackJackScript;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                blackJackScript.enabled = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                blackJackScript.enabled = false;
            }
        }

    }
}