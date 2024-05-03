using UnityEngine;

public class FrogScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    LogicManagerScript logic;

    bool isFrogAlive = true;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManagerScript>();
    }

    void Update()
    {
        if (!isFrogAlive) { return; }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime; // new Vector3(0, 1, 0)
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime; // new Vector3(0, -1, 0)
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime; // new Vector3(-1, 0, 0)
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime; // new Vector3(1, 0, 0)
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isFrogAlive = false;
        logic.GameOver();
    }


}
