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
    public class BlackJackV2 : CasinoGames
    {
        [SerializeField] private KeyCode hitKey = KeyCode.Q;
        [SerializeField] private KeyCode standKey = KeyCode.E;
        [SerializeField] private KeyCode restartKey = KeyCode.R;
        [SerializeField] private Texture2D cardIcon;
        [SerializeField] private Texture2D dealerIcon;
        [SerializeField] private Texture2D chipIcon;

        List<string> cardList = new List<string> // List of strings (cards)
            {
                "Ace of Diamonds", "Two of Diamonds", "Three of Diamonds", "Four of Diamonds", "Five of Diamonds", "Six of Diamonds", "Seven of Diamonds", "Eight of Diamonds", "Nine of Diamonds", "Ten of Diamonds", "Jack of Diamonds", "Queen of Diamonds", "King of Diamonds",
                "Ace of Clubs", "Two of Clubs", "Three of Clubs", "Four of Clubs", "Five of Clubs", "Six of Clubs", "Seven of Clubs", "Eight of Clubs", "Nine of Clubs", "Ten of Clubs", "Jack of Clubs", "Queen of Clubs", "King of Clubs",
                "Ace of Hearts", "Two of Hearts", "Three of Hearts", "Four of Hearts", "Five of Hearts", "Six of Hearts", "Seven of Hearts", "Eight of Hearts", "Nine of Hearts", "Ten of Hearts", "Jack of Hearts", "Queen of Hearts", "King of Hearts",
                "Ace of Spades", "Two of Spades", "Three of Spades", "Four of Spades", "Five of Spades", "Six of Spades", "Seven of Spades", "Eight of Spades", "Nine of Spades", "Ten of Spades", "Jack of Spades", "Queen of Spades", "King of Spades",
            };

        List<string> playerHand = new List<string>();

        List<string> dealerHand = new List<string>();

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

        private string BuildHandString(List<string> hand) // Automatically adds " & " between strings in the list.
        {
            return string.Join(" & ", hand);
        }

        private string DrawHand(List<string> hand) // Takes a random string and adds it to the list.
        {
            string card = GetRandomString();
            hand.Add(card);
            cardList.Remove(card);
            return card;
        }

        private int CalculateHand(List<string> hand) // Calculates the value of the whole hand.
        {
            int total = 0;

            foreach (string card in hand)
            {
                total += GetCardValue(card);
            }
            return total;
        }

        void ResetGame() // Resets game
        {
            cardList = new List<string>
                {
                    "Ace of Diamonds", "Two of Diamonds", "Three of Diamonds", "Four of Diamonds", "Five of Diamonds", "Six of Diamonds", "Seven of Diamonds", "Eight of Diamonds", "Nine of Diamonds", "Ten of Diamonds", "Jack of Diamonds", "Queen of Diamonds", "King of Diamonds",
                    "Ace of Clubs", "Two of Clubs", "Three of Clubs", "Four of Clubs", "Five of Clubs", "Six of Clubs", "Seven of Clubs", "Eight of Clubs", "Nine of Clubs", "Ten of Clubs", "Jack of Clubs", "Queen of Clubs", "King of Clubs",
                    "Ace of Hearts", "Two of Hearts", "Three of Hearts", "Four of Hearts", "Five of Hearts", "Six of Hearts", "Seven of Hearts", "Eight of Hearts", "Nine of Hearts", "Ten of Hearts", "Jack of Hearts", "Queen of Hearts", "King of Hearts",
                    "Ace of Spades", "Two of Spades", "Three of Spades", "Four of Spades", "Five of Spades", "Six of Spades", "Seven of Spades", "Eight of Spades", "Nine of Spades", "Ten of Spades", "Jack of Spades", "Queen of Spades", "King of Spades",
                };

            playerHand.Clear();
            dealerHand.Clear();

            total = 0;
            total2 = 0;

            labelText = "";
            labelText2 = "";
            labelText3 = "";

            playerDone = false;

            Start();
        }

        private int total, total2;

        private string labelText, labelText2, labelText3;

        private bool playerDone;

        // Start
        void Start()
        {
            playerHand.Clear();
            dealerHand.Clear();

            DrawHand(playerHand);
            DrawHand(dealerHand);

            DrawHand(playerHand);
            DrawHand(dealerHand);

            total = CalculateHand(playerHand);
            total2 = CalculateHand(dealerHand);

            playerDone = false;
        }

        void Update()
        {
            if (Input.GetKeyDown(hitKey) && !playerDone) // When the player hits.
            {
                DrawHand(playerHand);

                total = CalculateHand(playerHand);

                if (total > 21)
                {
                    labelText = "Your hand: " + BuildHandString(playerHand) + " (Total: " + total + ")";
                    labelText3 = "Bust!";
                    playerDone = true;
                }
                else
                {
                    labelText = "Your hand: " + BuildHandString(playerHand) + " (Total: " + total + ")";
                }
            }
            
            if (Input.GetKeyDown(standKey) && !playerDone) // if the player decides to stand.
            {
                playerDone = true;

                while (CalculateHand(dealerHand) < 17)
                {
                    DrawHand(dealerHand);
                }
                
                total2 = CalculateHand(dealerHand);

                labelText2 = "Dealer's hand: " + BuildHandString(dealerHand) + " (Total: " + total2 + ")";

                if (total2 > 21)
                {
                    labelText3 = "Dealer bust! Player wins!";
                }
                if (total > total2)
                {
                    labelText3 = "Player wins!";
                }
                if (total < total2 && total2 < 22)
                {
                    labelText3 = "Dealer wins!";
                }
                if (total == 21 && total > total2)
                {
                    labelText3 = "Blackjack! Player wins!";
                }
                if (total == total2)
                {
                    labelText3 = "Push!";
                }
                if (total2 == 21 && total < total2)
                {
                    labelText3 = "Dealer wins! Totally not rigged XOXO";
                }
            }

            if(Input.GetKeyDown(restartKey))
            {
                ResetGame();
            }
        }

        void OnGUI() // Everything UI related goes here, also everything here updates the last and once per frame.
        { 
            GUIStyle headStyle = new GUIStyle(GUI.skin.label);
            headStyle.fontSize = 70;
            Font myFont = (Font)Resources.Load("Fonts/CasinoF", typeof(Font)); // Font is taken from a path "Resources/Fonts/CasinoF/" in the project window
            headStyle.font = myFont;

            GUIStyle secondStyle = new GUIStyle(GUI.skin.label);
            secondStyle.fontSize = 70;
            secondStyle.font = myFont;

            GUIStyle thirdStyle = new GUIStyle(GUI.skin.label);
            thirdStyle.fontSize = 70;
            thirdStyle.font = myFont;

            if (string.IsNullOrEmpty(labelText))
            {
                labelText = "Your hand: " + BuildHandString(playerHand) + " (Total: " + total + ")";
                labelText2 = "Dealer's hand: " + dealerHand[0] + " & " + "_____ (Total: __)";
                labelText3 = "*Outcome*";
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




