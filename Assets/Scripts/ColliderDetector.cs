using System;
using System.Threading.Tasks;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    
    [SerializeField] private GameObject  _gameoverPanel;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private AudioClip _audio;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] InterstitialAd _interstitialAd;

    private void Start()
    {
        _gameoverPanel.SetActive(false);
        _restartButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if it's touching a balloon
        if (other.CompareTag("balloon"))
        {
            _gameoverPanel.SetActive(true);
            _restartButton.SetActive(true);
            GameObject[] balloons = GameObject.FindGameObjectsWithTag("balloon");
            BalloonSpawner.StopSpawning();
            foreach (GameObject balloon in balloons)
            {
                Destroy(balloon);
            }
            _audioSource.clip = _audio;
            _audioSource.Play();
            _backgroundMusic.Stop();
            
            ShowAD();
        }
    }

    private async void ShowAD()
    {
        await Task.Delay(1000);
        _interstitialAd.ShowAd();
    }
}