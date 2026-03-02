using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AH3520
{
    public class BlackJack : MonoBehaviour
    {

        public KeyCode hitKey = KeyCode.Q;

        public KeyCode standKey = KeyCode.E;

        // List of strings (cards)
        List<string> cardList = new List<string>
            {
                "Ace of Diamonds", "Two of Diamonds", "Three of Diamonds", "Four of Diamonds", "Five of Diamonds", "Six of Diamonds", "Eight of Diamonds", "Nine of Diamonds", "Ten of Diamonds", "Jack of Diamonds", "Queen of Diamonds", "King of Diamonds",
                "Ace of Clubs", "Two of Clubs", "Three of Clubs", "Four of Clubs", "Five of Clubs", "Six of Clubs", "Eight of Clubs", "Nine of Clubs", "Ten of Clubs", "Jack of Clubs", "Queen of Clubs", "King of Clubs",
                "Ace of Hearts", "Two of Hearts", "Three of Hearts", "Four of Hearts", "Five of Hearts", "Six of Hearts", "Eight of Hearts", "Nine of Hearts", "Ten of Hearts", "Jack of Hearts", "Queen of Hearts", "King of Hearts",
                "Ace of Spades", "Two of Spades", "Three of Spades", "Four of Spades", "Five of Spades", "Six of Spades", "Eight of Spades", "Nine of Spades", "Ten of Spades", "Jack of Spades", "Queen of Spades", "King of Spades",
            };

        enum Rank
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 10,
            Queen = 10,
            King = 10,
            Ace = 11
        }

        // Takes a random string (card) from the list
        public string GetRandomString()
        {
            int randomIndex = Random.Range(0, cardList.Count);
            return cardList[randomIndex];
        }

        static int GetCardValue(string card)
        {
            string rankPart = card.Split(" of ")[0];

            if (Enum.TryParse(rankPart, true, out Rank rank))
            {
                return (int)rank;
            }

            return -1;
        }

        int total;

        int cardValue;

        int cardValue2;

        string randomCard;

        string randomCard2;

        string hitCard;
        
        string hitCard2;

        int hitCardValue;

        int hitCardValue2;

        string labelText;

        // Start
        void Start()
        {
            randomCard = GetRandomString();

            cardValue = GetCardValue(randomCard);

            cardList.Remove(randomCard);
            
            randomCard2 = GetRandomString();

            cardValue2 = GetCardValue(randomCard2);

            cardList.Remove(randomCard2);

            total = cardValue + cardValue2;




            


            




        }

        void Update()
        {
            if (Input.GetKeyDown(hitKey))
            {
                hitCard = GetRandomString();

                hitCardValue = GetCardValue(hitCard);

                cardList.Remove(hitCard);

                total += hitCardValue;


                if (total < 22)
                {
                    labelText = "Your hand: " + randomCard + " & " + randomCard2 + " & " + hitCard + " (Total: " + total + ")";
                }
                else if (Input.GetKeyDown(hitKey)) // if the player hits again
                {
                    hitCard2 = GetRandomString();

                    hitCardValue2 = GetCardValue(hitCard2);

                    cardList.Remove(hitCard2);

                    total += hitCardValue2;

                    if (total < 22)
                    {
                        labelText = "Your hand: " + randomCard + " & " + randomCard2 + " & " + hitCard + " & " + hitCard2 + " (Total: " + total + ")";
                    }
                    else 
                    {
                        labelText = "Your hand: " + randomCard + " & " + randomCard2 + " & " + hitCard + " & " + hitCard2 + " (Total: " + total + ")" + " Bust!";
                    }
                }
            }

            if (Input.GetKeyDown(standKey))
            {


            }



        }

        
 
        void OnGUI()
        {
            GUIStyle headStyle = new GUIStyle();
            
            headStyle.fontSize = 60;

            if (string.IsNullOrEmpty(labelText))
            {
                labelText = "Your hand: " + randomCard + " & " + randomCard2 + " (Total: " + total + ")";
            }

            GUI.Label(new Rect(100, 100, 2000, 2000), labelText, headStyle);

        }
     
    }
}

//{
    //labelText = "Your hand: " + randomCard + " & " + randomCard2 + " & " + hitCard + " (Total: " + total + ")" + "Bust!";
//}