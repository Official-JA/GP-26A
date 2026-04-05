using UnityEngine;

namespace AH3520
{
    public class CasinoGames : MonoBehaviour
    {
        [SerializeField] public float chipAmount = 100f; 
        [SerializeField] public float betAmount = 10f;
        [SerializeField] private KeyCode increaseBet = KeyCode.UpArrow;
        [SerializeField] private KeyCode decreaseBet = KeyCode.DownArrow;

        private string chipText, betText;

        void Update()
        {
            if (chipAmount > 0) // Can't bet with 0 chips
            {
                if (Input.GetKeyDown(increaseBet) && betAmount < chipAmount) // Increasing the bet, can't bet more than you own
                {
                    betAmount += 10;
                }

                if (Input.GetKeyDown(decreaseBet) && 10 < betAmount) // Decreasing the bet, min. amount to bet is 10
                {
                    betAmount -= 10;
                }
            }

            if (chipAmount == 0 || chipAmount < betAmount) // Fixes contradictions
            {
                betAmount = chipAmount;
            }
        }

        private void OnGUI() // UI stuff goes here, updates last and once per frame
        {
            GUIStyle headStyle = new GUIStyle(GUI.skin.label);
            headStyle.fontSize = 70;
            Font myFont = (Font)Resources.Load("Fonts/Louvre", typeof(Font));
            headStyle.font = myFont;

            chipText = "Chip Amount : " + chipAmount;
            betText = "Bet Amount : " + betAmount;

            GUI.Label(new Rect(1800, 1300, 2000, 2000), chipText, headStyle);            
            GUI.Label(new Rect(1800, 1200, 2000, 2000), betText, headStyle);
        }
    }
}
