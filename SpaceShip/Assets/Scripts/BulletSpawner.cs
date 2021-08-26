using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bullet1;
    public GameObject Bullet2;
    public float SpawnDelay;
    private int type_of_bullet;

    void Start()
    {
        StartCoroutine(Fire());
        //type_of_bullet = 
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
                Instantiate(Bullet1, transform.TransformPoint(Vector3.forward), transform.rotation );// * Quaternion.AngleAxis(90, Vector3.forward));
                yield return new WaitForSeconds(SpawnDelay);
            }
        }
        yield return 0;
        Repeat();
    }
}
    