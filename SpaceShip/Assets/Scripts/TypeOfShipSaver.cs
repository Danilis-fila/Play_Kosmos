using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfShipSaver : MonoBehaviour
{
    public int type_of_ship;
    public static TypeOfShipSaver control;

    void Awake()
    {
        control = this;
        DontDestroyOnLoad(transform.gameObject);
    }
}
