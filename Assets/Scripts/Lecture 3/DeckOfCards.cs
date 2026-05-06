using UnityEngine;

namespace AH3520
{
    public class DeckOfCards : MonoBehaviour
    {
        public Material deckMaterial;

        [Range(0, 52)]
        public int fullDeckAmount;

        // Update is called once per frame
        void Update()
        {

        }


        public void RemoveCard(int deckAmount)
        {
            fullDeckAmount -= 1;
        }

        public void AddCard(int deckAmount) 
        { 
            fullDeckAmount += 1;
        }

    }
}