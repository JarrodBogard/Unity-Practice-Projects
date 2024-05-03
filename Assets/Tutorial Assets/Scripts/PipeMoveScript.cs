using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float deadZone = -45f;

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }
}
