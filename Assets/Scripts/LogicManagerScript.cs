using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManagerScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text scoreText;

    int playerScore;

    void Start()
    {
        playerScore = PlayerPrefs.GetInt("CurrentScore", 0);
        scoreText.text = "Score: " + playerScore;
    }

    public void AddToScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        if (playerScore > PlayerPrefs.GetInt("CurrentScore", 0))
        {
            scoreText.text = "Score: " + playerScore;
            PlayerPrefs.SetInt("CurrentScore", playerScore);

        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    // TODO: add method for loading next level //

    public void GameOver()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetInt("CurrentScore", 0);
        gameOverScreen.SetActive(true);
    }
}
