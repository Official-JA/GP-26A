using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;

namespace AH3520
{
    public class BlackJack : MonoBehaviour
    {
        public KeyCode hitKey = KeyCode.Q;

        public KeyCode standKey = KeyCode.E;

        List<string> cardList = new List<string>
            {
                "Ace of Diamonds", "Two of Diamonds", "Three of Diamonds", "Four of Diamonds", "Five of Diamonds", "Six of Diamonds", "Eight of Diamonds", "Nine of Diamonds", "Ten of Diamonds", "Jack of Diamonds", "Queen of Diamonds", "King of Diamonds",
                "Ace of Clubs", "Two of Clubs", "Three of Clubs", "Four of Clubs", "Five of Clubs", "Six of Clubs", "Eight of Clubs", "Nine of Clubs", "Ten of Clubs", "Jack of Clubs", "Queen of Clubs", "King of Clubs",
                "Ace of Hearts", "Two of Hearts", "Three of Hearts", "Four of Hearts", "Five of Hearts", "Six of Hearts", "Eight of Hearts", "Nine of Hearts", "Ten of Hearts", "Jack of Hearts", "Queen of Hearts", "King of Hearts",
                "Ace of Spades", "Two of Spades", "Three of Spades", "Four of Spades", "Five of Spades", "Six of Spades", "Eight of Spades", "Nine of Spades", "Ten of Spades", "Jack of Spades", "Queen of Spades", "King of Spades",
            };

        public string GetRandomString()
        {
            int randomIndex = Random.Range(0, cardList.Count);
            return cardList[randomIndex];
        }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            string randomCard = GetRandomString();

            string randomCard2 = GetRandomString();

            Debug.Log("Your hand: {0} & {1}", randomCard, randomCard2);




        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(hitKey))
            {
                
            }

            if (Input.GetKeyDown(standKey))
            {

            }


        }

        

    }
}