using System.Collections;
using UnityEngine;

namespace AH3520
{
    public class Cutscene : MonoBehaviour
    {
        [SerializeField] GameObject playerPrefab;
        [SerializeField] GameObject cameraPrefab;
        
        private AudioSource audioSource;
        
        private string title = "";

        IEnumerator DelayTime(float delay)
        {
            yield return new WaitForSeconds(delay);
            audioSource.Play();
            title = "gambling.";
        }

        IEnumerator ActivatePlayer(float delay)
        {
            yield return new WaitForSeconds(delay);
            playerPrefab.SetActive(true);
            cameraPrefab.SetActive(false);
        }

        // Start 
        void Start()
        {
            audioSource = GetComponent<AudioSource>();

            StartCoroutine(DelayTime(2f));

            StartCoroutine(ActivatePlayer(5f));
        }

        private void OnGUI()
        {
            GUIStyle headStyle = new GUIStyle(GUI.skin.label);
            headStyle.fontSize = 300;
            Font myFont = (Font)Resources.Load("Fonts/Oregon", typeof(Font));
            headStyle.font = myFont;

            GUI.Label(new Rect(750, 600, 2000, 2000), title, headStyle);
        }
    }
}
