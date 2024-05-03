using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    AudioSource scoringSFX;

    void Start()
    {
        scoringSFX = GetComponent<AudioSource>();
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        scoringSFX.Play();
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
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
