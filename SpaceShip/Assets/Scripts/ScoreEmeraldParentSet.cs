using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEmeraldParentSet : MonoBehaviour
{
    void Start()
    {
        gameObject.transform.SetParent(GameObject.Find("Canvas").transform, false);
    }
}
