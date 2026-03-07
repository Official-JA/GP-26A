using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.ProBuilder.MeshOperations;
using Random = UnityEngine.Random;

namespace AH3520
{
    public class BlackJack : MonoBehaviour
    {
        public KeyCode hitKey = KeyCode.Q;
        public KeyCode standKey = KeyCode.E;
        public KeyCode restartKey = KeyCode.R;
        public Texture2D cardIcon;
        public Texture2D dealerIcon;
        public Texture2D chipIcon;

        List<string> cardList = new List<string> // List of strings (cards)
            {
                "Ace of Diamonds", "Two of Diamonds", "Three of Diamonds", "Four of Diamonds", "Five of Diamonds", "Six of Diamonds", "Seven of Diamonds", "Eight of Diamonds", "Nine of Diamonds", "Ten of Diamonds", "Jack of Diamonds", "Queen of Diamonds", "King of Diamonds",
                "Ace of Clubs", "Two of Clubs", "Three of Clubs", "Four of Clubs", "Five of Clubs", "Six of Clubs", "Seven of Clubs", "Eight of Clubs", "Nine of Clubs", "Ten of Clubs", "Jack of Clubs", "Queen of Clubs", "King of Clubs",
                "Ace of Hearts", "Two of Hearts", "Three of Hearts", "Four of Hearts", "Five of Hearts", "Six of Hearts", "Seven of Hearts", "Eight of Hearts", "Nine of Hearts", "Ten of Hearts", "Jack of Hearts", "Queen of Hearts", "King of Hearts",
                "Ace of Spades", "Two of Spades", "Three of Spades", "Four of Spades", "Five of Spades", "Six of Spades", "Seven of Spades", "Eight of Spades", "Nine of Spades", "Ten of Spades", "Jack of Spades", "Queen of Spades", "King of Spades",
            };

        enum Rank // Assigns a numeric value to specific strings.
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

        public string GetRandomString() // Takes a random string (card) from the list.
        {
            int randomIndex = Random.Range(0, cardList.Count);
            return cardList[randomIndex];
        }

        static int GetCardValue(string card) // Reads the substring before "of" and assigns it its specfic value based on the enum.
        {
            string rankPart = card.Split(" of ")[0];

            if (Enum.TryParse(rankPart, true, out Rank rank))
            {
                return (int)rank;
            }

            return -1;
        }

        void ResetGame()
        {
            cardList = new List<string>
                {
                    "Ace of Diamonds", "Two of Diamonds", "Three of Diamonds", "Four of Diamonds", "Five of Diamonds", "Six of Diamonds", "Seven of Diamonds", "Eight of Diamonds", "Nine of Diamonds", "Ten of Diamonds", "Jack of Diamonds", "Queen of Diamonds", "King of Diamonds",
                    "Ace of Clubs", "Two of Clubs", "Three of Clubs", "Four of Clubs", "Five of Clubs", "Six of Clubs", "Seven of Clubs", "Eight of Clubs", "Nine of Clubs", "Ten of Clubs", "Jack of Clubs", "Queen of Clubs", "King of Clubs",
                    "Ace of Hearts", "Two of Hearts", "Three of Hearts", "Four of Hearts", "Five of Hearts", "Six of Hearts", "Seven of Hearts", "Eight of Hearts", "Nine of Hearts", "Ten of Hearts", "Jack of Hearts", "Queen of Hearts", "King of Hearts",
                    "Ace of Spades", "Two of Spades", "Three of Spades", "Four of Spades", "Five of Spades", "Six of Spades", "Seven of Spades", "Eight of Spades", "Nine of Spades", "Ten of Spades", "Jack of Spades", "Queen of Spades", "King of Spades",
                };

            total = 0;
            total2 = 0;

            labelText = "";
            labelText2 = "";
            labelText3 = "";

            hasExecuted = false;
            playerDone = false;

            Start();
        }


        private int total, total2, cardValue, cardValue2, hitCardValue, hitCardValue2, hitCardValue3, dealerCardValue, dealerCardValue2, dealerCardValue3;

        private string randomCard, randomCard2, hitCard, hitCard2, hitCard3, dealerCard, dealerCard2, dealerCard3, labelText, labelText2, labelText3;

        private bool hasExecuted, playerDone;

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
            
            dealerCard = GetRandomString();
            dealerCardValue = GetCardValue(dealerCard);
            cardList.Remove(dealerCard);

            dealerCard2 = GetRandomString();
            dealerCardValue2 = GetCardValue(dealerCard2);
            cardList.Remove(dealerCard2);

            hasExecuted = false;
            playerDone = false;
        }

        void Update()
        {
            if (Input.GetKeyDown(hitKey) && !hasExecuted && playerDone == false) // Gives the player a card if they hit
            {
                hitCard = GetRandomString();

                hitCardValue = GetCardValue(hitCard);

                cardList.Remove(hitCard);

                total += hitCardValue;

                if (total < 22)
                {
                    labelText = "Your hand: " + randomCard + " & " + randomCard2 + " & " + hitCard + " (Total: " + total + ")";
                    hasExecuted = true;
                }
                else
                {
                    labelText = "Your hand: " + randomCard + " & " + randomCard2 + " & " + hitCard + " (Total: " + total + ")";
                    labelText3 = "Bust!";
                    playerDone = true;

                }
            }
            else if (Input.GetKeyDown(hitKey) && hasExecuted && playerDone == false) // if the player hits again
            {
                hitCard2 = GetRandomString();

                hitCardValue2 = GetCardValue(hitCard2);

                cardList.Remove(hitCard2);

                total += hitCardValue2;

                if (total < 22)
                {
                    labelText = "Your hand: " + randomCard + " & " + randomCard2 + " & " + hitCard + " & " + hitCard2 + " (Total: " + total + ")";
                    hasExecuted = false;
                }
                else
                {
                    labelText = "Your hand: " + randomCard + " & " + randomCard2 + " & " + hitCard + " & " + hitCard2 + " (Total: " + total + ")";
                    labelText3 = "Bust!";
                    playerDone = true;
                }  
            }

            if (Input.GetKeyDown(standKey) && playerDone == false) // if the player decides to stand
            {
                playerDone = true;

                dealerCard3 = GetRandomString();
                dealerCardValue3 = GetCardValue(dealerCard3);
                cardList.Remove(dealerCard3);
                
                total2 = dealerCardValue + dealerCardValue2;

                labelText2 = "Dealer's hand: " + dealerCard + " & " + dealerCard2 + " (Total: " + total2 + ")";

                if (total2 < 17)
                {
                    total2 += dealerCardValue3;

                    labelText2 = "Dealer's hand: " + dealerCard + " & " + dealerCard2 + " & " + dealerCard3 + " (Total: " + total2 + ")";
                }
                
                if (total2 > 22)
                {
                    labelText3 = "Dealer bust! Player wins!";
                }
                if (total > total2)
                {
                    labelText3 = "Player wins!";
                }
                else if (total < total2 && total2 < 22)
                {
                    labelText3 = "Dealer wins!";
                }
                if (total == 21 && total > total2)
                {
                    labelText3 = "Blackjack! Player wins!";
                }
            }

            if(Input.GetKeyDown(restartKey))
            {
                ResetGame();
            }
        }

        void OnGUI() // Everything UI related goes here
        { 
            GUIStyle headStyle = new GUIStyle(GUI.skin.label);
            headStyle.fontSize = 70;
            Font myFont = (Font)Resources.Load("Fonts/CasinoF", typeof(Font));
            headStyle.font = myFont;

            GUIStyle secondStyle = new GUIStyle(GUI.skin.label);
            secondStyle.fontSize = 70;
            secondStyle.font = myFont;

            GUIStyle thirdStyle = new GUIStyle(GUI.skin.label);
            thirdStyle.fontSize = 70;
            thirdStyle.font = myFont;

            if (string.IsNullOrEmpty(labelText))
            {
                labelText = "Your hand: " + randomCard + " & " + randomCard2 + " (Total: " + total + ")";
                labelText2 = "Dealer's hand: " + dealerCard + " & " + "_____ (Total: __)";
            }

            GUI.Label(new Rect(220, 100, 2000, 2000), labelText, headStyle);
            GUI.DrawTexture(new Rect(10, 100, 200, 200), cardIcon);

            GUI.Label(new Rect(220, 400, 2000, 2000), labelText2, secondStyle);
            GUI.DrawTexture(new Rect(10, 400, 200, 200), dealerIcon);

            GUI.Label(new Rect(220, 750, 3000, 2000), labelText3, thirdStyle);
            GUI.DrawTexture(new Rect(10, 700, 200, 200), chipIcon);
        }
     
    }
}




