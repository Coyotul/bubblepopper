using TMPro;
using UnityEngine;

public class HighscoreController : MonoBehaviour
{
    private string highscoreKey = "Highscore";
    private int highscore = 0;
    private static TMP_Text scoreText; // Use TMP_Text instead of Text


    void Start()
    {
        scoreText = GetComponent<TMP_Text>(); // Use GetComponent<TMP_Text>() instead of GetComponent<Text>()
        // Load the highscore from PlayerPrefs when the game starts
        LoadHighscore();
    }

    void Update()
    {
        // Check for a new highscore and update it if necessary
        UpdateHighscore();
        LoadHighscore();
    }

    private void UpdateHighscore()
    {
        // Check if the current score is greater than the saved highscore and update it if true
        if (ScoreTextController.GetScore() > highscore)
        {
            highscore = ScoreTextController.GetScore();
            // Save the updated highscore to PlayerPrefs
            SaveHighscore();
        }
    }

    private void LoadHighscore()
    {
        // Load the saved highscore from PlayerPrefs
        highscore = PlayerPrefs.GetInt(highscoreKey, 0);
        scoreText.text = "HIGHSCORE: " + highscore;

    }

    private void SaveHighscore()
    {
        // Save the current highscore to PlayerPrefs
        PlayerPrefs.SetInt(highscoreKey, highscore);
        // Save the changes made to PlayerPrefs
        PlayerPrefs.Save();
    }
}