using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private InterstitialAd _interstitialAd;
    // This function is called when the Restart button is clicked
    public void OnRestartButtonClick()
    {
        _interstitialAd.LoadAd();
        BalloonSpawner.StartSpawning();
        // Get the index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene by loading it again with its index
        SceneManager.LoadScene(currentSceneIndex);
    }
}