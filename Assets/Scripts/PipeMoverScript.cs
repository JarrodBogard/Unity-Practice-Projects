using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoverScript : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float deadZone = -45f;

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }
}
