using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    public GameObject gameOverMenu;
    public Text scoreText;
    public Text livesText;
    public Text timerText;

    private FroggerScript froggy;
    private HomeScript[] homes;
    private int score;
    private int lives;
    private int time;

    private void Awake()
    {
        froggy = FindObjectOfType<FroggerScript>();
        homes = FindObjectsOfType<HomeScript>();
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        gameOverMenu.SetActive(false);
        SetScore(0);
        SetLives(3);
        NewLevel();
    }

    private void NewLevel()
    {
        for (int i = 0; i < homes.Length; i++)
        {
            homes[i].enabled = false;
        }

        Respawn();
    }

    public void Died()
    {
        SetLives(lives - 1);

        if (lives > 0)
        {
            Invoke(nameof(Respawn), 1f);
        }
        else
        {
            Invoke(nameof(GameOver), 1f);
        }
    }

    private void GameOver()
    {
        froggy.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        bool playAgain = false;

        while (!playAgain)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                playAgain = true;
            }
            yield return null;
        }

        NewGame();
    }

    public void AdvanceRow()
    {
        SetScore(score + 10);
    }

    public void HomeOccupied()
    {
        froggy.gameObject.SetActive(false);

        int bonusPoints = time * 20;

        SetScore(score + bonusPoints + 50);

        if (Cleared())
        {
            SetScore(score + 1000);
            SetLives(lives + 1);
            Invoke(nameof(NewLevel), 1f);
        }
        else
        {
            Invoke(nameof(Respawn), 1f);
        }
    }

    private bool Cleared()
    {
        foreach (HomeScript home in homes)
        {
            if (!home.enabled)
            {
                return false;
            }
        }
        return true;
    }

    private void Respawn()
    {
        froggy.Respawn();
        StopAllCoroutines();
        StartCoroutine(Timer(30));
    }


    private IEnumerator Timer(int duration)
    {
        time = duration;
        timerText.text = time.ToString();

        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            timerText.text = time.ToString();
        }

        froggy.Death();
    }


    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = lives.ToString();
    }

}
