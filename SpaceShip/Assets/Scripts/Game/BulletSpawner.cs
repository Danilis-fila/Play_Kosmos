using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bullet1;
    public GameObject Bullet2;
    public float SpawnDelay;
    private GameObject bullet;
    private int type_of_bullet;
    private Quaternion rotation;

    void Start()
    {
        StartCoroutine(Fire());
        type_of_bullet = PlayerPrefs.GetInt("type of ship", 1);
        if (type_of_bullet == 1) {
            bullet = Bullet1;
        }
        else if (type_of_bullet == 2)
        {
            bullet = Bullet2;
        }
    }

    void Repeat()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                Instantiate(bullet, transform.TransformPoint(Vector3.forward), transform.rotation);
                yield return new WaitForSeconds(SpawnDelay);
            }
        }
        yield return 0;
        Repeat();
    }
}
    