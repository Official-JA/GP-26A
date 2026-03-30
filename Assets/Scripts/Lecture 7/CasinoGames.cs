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

        void Start()
        {
            
        }

        void Update()
        {
            if (chipAmount > 0)
            {
                if (Input.GetKeyDown(increaseBet) && betAmount < chipAmount)
                {
                    betAmount += 10;
                }

                if (Input.GetKeyDown(decreaseBet) && 10 < betAmount)
                {
                    betAmount -= 10;
                }
            }

            if (chipAmount == 0)
            {
                betAmount = 0;
            }
        }

        private void OnGUI()
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
