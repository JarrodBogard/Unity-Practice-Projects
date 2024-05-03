using System.Collections;
using UnityEngine;

public class CarSpawnScript : MonoBehaviour
{
    public GameObject vehicle;
    public float shortestSpawnTime = .5f;
    public float longestSpawnTime = 3f;

    bool isSpawning = false;

    void Update()
    {
        if (!isSpawning)
        {
            StartCoroutine(StartSpawning());
        }
    }

    IEnumerator StartSpawning()
    {
        isSpawning = true;
        SpawnCar();
        yield return new WaitForSeconds(Random.Range(shortestSpawnTime, longestSpawnTime));
        isSpawning = false;
    }

    void SpawnCar()
    {
        Instantiate(vehicle, transform.position, transform.rotation);
    }
}
