using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipShopRender : MonoBehaviour
{
    public static ShipShopRender instanse;
    public Text emeraldsText;
    private int emeralds;

    private void Awake()
    {
        instanse = this;
    }

    public bool SpendEmeralds(int amount)
    {
        if (emeralds > amount)
        {
            emeralds -= amount;
            emeraldsText.text = emeralds.ToString();
            PlayerPrefs.SetInt("emeralds", emeralds);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Render()
    {
        // render amount of player's emeralds
        emeralds = PlayerPrefs.GetInt("emeralds", 0);
        emeraldsText.text = emeralds.ToString();

        // render every cage
        for (int i = 1; i < 5; i++)
        {
            GameObject.Find(string.Format("Cage{0}", i)).GetComponent<ShopBuyShipButton>().Render();
        }
    }
}
