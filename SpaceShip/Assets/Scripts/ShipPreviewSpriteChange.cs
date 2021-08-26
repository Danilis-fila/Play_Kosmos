using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPreviewSpriteChange : MonoBehaviour
{
    public Animator animator;
    public int type_of_ship = 1;
    public GameObject saver;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangePreviewSprite()
    {
        type_of_ship = 3 - type_of_ship;
        animator.SetInteger("Type of Ship", type_of_ship);
        saver.GetComponent<TypeOfShipSaver>().type_of_ship = type_of_ship;
    }
    
}
