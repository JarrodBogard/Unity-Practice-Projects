using System.Collections;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

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

    private void NewGame()
    {
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

        NewRound();
    }

    public void HomeOccupied()
    {
        froggy.gameObject.SetActive(false);

        SetScore(score + 50);

        if (Cleared())
        {
            SetScore(score + 1000);
            Invoke(nameof(NewLevel), 1f);
        }
        else
        {
            Invoke(nameof(NewRound), 1f);
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

    private void NewRound()
    {
        Respawn();
    }

    private void Respawn()
    {
        froggy.Respawn();
        StartCoroutine(Timer(30));
    }


    private IEnumerator Timer(int duration)
    {
        time = duration;

        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }

        froggy.Death();
    }


    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

}
