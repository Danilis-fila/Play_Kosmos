using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject Asteroid1;
    public GameObject Asteroid2;
    public GameObject Asteroid3;
    public float SpawnDelay;

   void Start()
   {
       StartCoroutine(SpawnAsteroid());
   }

    void Repeat()
    {
        StartCoroutine(SpawnAsteroid());
    }

    IEnumerator SpawnAsteroid()
    {
        yield return new WaitForSeconds(SpawnDelay);
        int random_num = Random.Range(0, 3);
        if (random_num == 0) Instantiate(Asteroid1, transform.position, Quaternion.identity);
        if (random_num == 1) Instantiate(Asteroid2, transform.position, Quaternion.identity);
        if (random_num == 2) Instantiate(Asteroid3, transform.position, Quaternion.identity);
        Repeat();
    }
}
