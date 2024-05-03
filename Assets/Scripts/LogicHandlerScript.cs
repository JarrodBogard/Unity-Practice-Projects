using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicHandlerScript : MonoBehaviour
{

    public Text scoreText;
    public Text highScore;
    public GameObject gameOverScreen;
    public int playerScore;

    void Start()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    [ContextMenu("Increase Score")]
    public void AddToScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();

        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScore.text = "High Score: " + playerScore.ToString();
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "High Score: 0";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
