using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private int score = 0;

    void Awake()
    {
        // Ensure only one instance of ScoreManager exists
        if (instance == null)
            instance = this;
        gameOverText.gameObject.SetActive(false); // Hide game over text
        restartButton.gameObject.SetActive(false); // Hide restart button

    }

    public void AddPoint()
    {
        score++; // Increase score
        scoreText.text = "Score: " + score; // Update UI text
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true); // Show game over text
        restartButton.gameObject.SetActive(true); // Show restart button
        Time.timeScale = 0;
    }
}
