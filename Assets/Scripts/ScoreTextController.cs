using TMPro;
using UnityEngine;

public class ScoreTextController : MonoBehaviour
{
    private static int score = 0;
    private static TMP_Text scoreText; // Use TMP_Text instead of Text

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>(); // Use GetComponent<TMP_Text>() instead of GetComponent<Text>()
        score = 0;
        UpdateScoreText();
    }

    public static void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    public static int GetScore()
    {
        return score;
    }

    private static void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}