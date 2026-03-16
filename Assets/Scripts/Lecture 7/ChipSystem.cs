using UnityEngine;

namespace AH3520
{
    public class ChipSystem : BlackJackV2
    {
        [SerializeField] private int chipAmount = 100;
        
        private string chipText;

        void Start()
        {

        }

        
        void Update()
        {

        }

        private void OnGUI()
        {
            GUIStyle headStyle = new GUIStyle(GUI.skin.label);
            headStyle.fontSize = 70;
            Font myFont = (Font)Resources.Load("Fonts/Louvre", typeof(Font));
            headStyle.font = myFont;

            chipText = "Chip Amount : " + chipAmount;

            GUI.Label(new Rect(1800, 1300, 2000, 2000), chipText, headStyle);
        }
    }
}
