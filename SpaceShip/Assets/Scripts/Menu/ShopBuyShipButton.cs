using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuyShipButton : MonoBehaviour
{
    public int cageNumber;
    public int cost;

    public Sprite selectedCage;
    public Sprite notSelectedCage;

    private int state;
    private GameObject cage;
    private ShipShopRender render;


    private void Start()
    {
        state = PlayerPrefs.GetInt(string.Format("Cage{0}", cageNumber));
        render = GameObject.Find("ShipShop").GetComponent<ShipShopRender>();
    }


    public void Render()
    {
        // -1 - not exists yet
        // 0 - not available
        // 1 - available
        // 2 - selected
        
        string pathToCostText = string.Format("Cage{0}/Cost/CostText", cageNumber);
        string pathToLock = string.Format("Cage{0}/Lock", cageNumber);
        string pathToEmeraldIcon = string.Format("Cage{0}/Cost/EmeraldIcon", cageNumber);
        string pathToBorder = string.Format("Cage{0}/Border", cageNumber);

        // render cost
        Text costText = GameObject.Find(pathToCostText).GetComponent<Text>();
        state = PlayerPrefs.GetInt(string.Format("Cage{0}", cageNumber));
        if (state == 1 || state == 2)
        {
            costText.text = "Available ";
        }
        else if (state == -1)
        {
            costText.text = "None";
        }
        else if (state == 0)
        {
            costText.text = cost.ToString();
        }

        // show/hide lock and emerald
        if (state == 1 || state == 2)
        {
            try
            {
                GameObject.Find(pathToLock).SetActive(false);
                GameObject.Find(pathToEmeraldIcon).SetActive(false);
            }
            catch
            {
                // then things already deactive
            }
        }
        else
        {
            GameObject.Find(pathToLock).SetActive(true);
            GameObject.Find(pathToEmeraldIcon).SetActive(true);
        }

        // select/deselect cage
        if (state == 2)
        {
            GameObject.Find(pathToBorder).GetComponent<SpriteRenderer>().sprite = selectedCage;
        }
        else
        {
            GameObject.Find(pathToBorder).GetComponent<SpriteRenderer>().sprite = notSelectedCage;
        }
    }


    public void Select()
    {
        if (state == 0)
        {
            Buy();
        }

        if (state == 0 || state == -1)
        {
            return;
        }

        int prevSelectedCageIdx = 0;
        for (int i = 1; i <= 4; i++)
        {
            if (PlayerPrefs.GetInt("Cage" + i) == 2)
            {
                prevSelectedCageIdx = i;
            }
        }

        if (prevSelectedCageIdx == cageNumber)
        {
            return
        }

        // select new ship and deselect previous
        PlayerPrefs.SetInt(string.Format("Cage{0}", cageNumber), 2);
        PlayerPrefs.SetInt(string.Format("Cage{0}", prevSelectedCageIdx), 1);

        // save select
        PlayerPrefs.SetInt("type of ship", cageNumber);

        // show changes
        render.Render();
    }


    public void Buy()
    {
        int playersEmeralds = PlayerPrefs.GetInt("emeralds");
        if (playersEmeralds >= cost)
        {
            // spend emeralds
            PlayerPrefs.SetInt("emeralds", playersEmeralds - cost);
            PlayerPrefs.SetInt(string.Format("Cage{0}", cageNumber), 2);
            state = 2;
            Select();
        }
        else
        {
            // TODO: "you dont have enough MONEY MONEY MONEY MONEY MONEY AH YEAH"
        }
    }
}
