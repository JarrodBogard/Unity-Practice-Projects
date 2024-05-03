using UnityEngine;

public class ScoreHandlingScript : MonoBehaviour
{
    public LogicHandlerScript logicHandler;

    void Start()
    {
        logicHandler = GameObject.FindGameObjectWithTag("LogicHandler").GetComponent<LogicHandlerScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            logicHandler.AddToScore(1);
        }
    }
}
