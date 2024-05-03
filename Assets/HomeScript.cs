using UnityEngine;

public class HomeScript : MonoBehaviour
{
    public GameObject homeFrog;

    private void OnEnable()
    {
        homeFrog.SetActive(true);
    }

    private void OnDisable()
    {
        homeFrog.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enabled = true;
            FindObjectOfType<GameManagerScript>().HomeOccupied();


            // other.gameObject.SetActive(false);
            // FroggerScript froggy = other.GetComponent<FroggerScript>();
            // froggy.Invoke(nameof(froggy.Respawn), 1f);
        }
    }
}
