using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Ship;

    void Update()
    {
        transform.position = Ship.transform.position.normalized * 1.35f;
    }
}
