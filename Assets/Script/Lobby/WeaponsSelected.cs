using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponsSelected : MonoBehaviour
{
    public PlayerInfo info;
    public CostInfo costInfo;
    public TextMeshProUGUI[] selectedText;

    void Update()
    {
        if (info.swordsSelected == 0)
        {
            selectedText[0].text = "Selected";
            selectedText[1].text = "Select";
        }
        else
        {
            selectedText[0].text = "Select";
            selectedText[1].text = "Selected";
        }

        if (!info.haveGlorySword)
        {
            info.swordsSelected = 0;
            selectedText[1].text = costInfo.glorySwordCost + " Coin";
        }
    }

    public void weaponSelect(int numOfWeapons)
    {
        if (numOfWeapons == 0)
        {
            info.swordsSelected = 0;
            selectedText[0].text = "Selected";
            selectedText[1].text = "Select";
        }
        else
        {
            if (!info.haveGlorySword)
            {
                if (info.coins >= costInfo.glorySwordCost)
                {
                    info.coins -= costInfo.glorySwordCost;
                    info.haveGlorySword = true;
                }
            }
            else
            {
                info.swordsSelected = 1;
                selectedText[0].text = "Select";
                selectedText[1].text = "Selected";
            }
        }
    }
}
