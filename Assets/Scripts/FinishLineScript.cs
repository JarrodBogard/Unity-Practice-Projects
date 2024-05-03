using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    LogicManagerScript logic;
    public int points = 1;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManagerScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        logic.AddToScore(points);
        logic.RestartGame();
        // TODO: use method from logic for loading next level //
    }
}
