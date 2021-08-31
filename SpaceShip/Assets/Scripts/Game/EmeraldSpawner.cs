using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmeraldSpawner : MonoBehaviour
{
    public GameObject Emerald;
    public float SpawnDelay;
    private Vector2 centre = new Vector2(Screen.width / 2, Screen.height / 2);

    void Start()
    {
        StartCoroutine(SpawnEmerald());
    }

    void Repeat()
    {
        StartCoroutine(SpawnEmerald());
    }

    IEnumerator SpawnEmerald()
    {
        yield return new WaitForSeconds(SpawnDelay);
        Vector2 pos = Random.insideUnitCircle.normalized * 1.42f;
        Instantiate(Emerald, pos, Quaternion.identity);
        Repeat();
    }
}
