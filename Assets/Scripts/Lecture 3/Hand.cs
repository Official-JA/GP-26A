using UnityEngine;

namespace AH3520
{
    public class Hand : MonoBehaviour
    {
        public DeckOfCards deckOfCards;

        [Range(-1, 1)]
        public int amountValue;

        [Range(0, 5)]
        public int handAmount;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (handAmount < 5)
                {
                    RemoveValueAmountOfTargetContainer();
                }
                else
                {
                    Debug.Log("Hand full!");
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (handAmount > 0 && handAmount <= 5)
                {
                    IncreaseValueAmountOfTargetContainer();
                }
                else
                {
                    Debug.Log("Empty hand!");
                }
            }

        }

        public void RemoveValueAmountOfTargetContainer()
        {
            deckOfCards.RemoveCard(amountValue);

            handAmount += 1;
        }


        public void IncreaseValueAmountOfTargetContainer()
        {
            deckOfCards.AddCard(amountValue);

            handAmount -= 1;
        }

    }
}