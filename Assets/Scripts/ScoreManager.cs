using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public GameObject ball;
    public Button restartButton;
    private int score = 0;
    private int lives = 3;

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
        if (lives >= 1)
        {
            lives--; // Decrease lives
            livesText.text = "Lives: " + lives; // Update UI text
            ball.gameObject.transform.position = new Vector3(3.7f, 1.6f, 0.03f); // Reset ball position
        }
        else
        {
            gameOverText.gameObject.SetActive(true); // Show game over text
            restartButton.gameObject.SetActive(true); // Show restart button
            Time.timeScale = 0;
        }
    }
}
