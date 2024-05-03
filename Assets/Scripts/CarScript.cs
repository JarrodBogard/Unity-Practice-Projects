using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float moveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -34 || transform.position.x > 35)
        {
            Destroy(gameObject);
        }
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
