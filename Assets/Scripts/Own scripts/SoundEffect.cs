using UnityEngine;

namespace AH3520
{
    public class SoundEffect : MonoBehaviour
    {
        AudioSource audioSource;

        [SerializeField] private CasinoGames casinoGames;

        private bool audioPlayed = false;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        void Update()
        {
            if (!audioPlayed && casinoGames.chipAmount == 0)
            {
                audioSource.Play();
                audioPlayed = true;
            }
        }
    }
}
