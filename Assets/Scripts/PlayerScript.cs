using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public LogicHandlerScript logicHandler;
    public float flapStrength;
    public bool playerIsAlive = true;

    void Start()
    {
        logicHandler = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<LogicHandlerScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if (transform.position.y > 20 || transform.position.y < -25)
        {
            logicHandler.GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        logicHandler.GameOver();
        playerIsAlive = false;
    }
}
