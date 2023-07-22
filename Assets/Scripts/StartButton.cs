using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        BalloonSpawner.StartSpawning();
        // Get the index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene by loading it again with its index
        SceneManager.LoadScene(currentSceneIndex+1);
    }
}
