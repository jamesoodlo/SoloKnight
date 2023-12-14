using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public PlayerInfo info;
    public GameObject fireEnchant;
    public float damage;
    public int swordsSelected;
    public GameObject[] swords;

    void Start() 
    {
        for (int i = 0; i < swords.Length; i++)
        {
            swords[i].SetActive(false);
        }
    }

    void Update() 
    {
        swords[info.swordsSelected].SetActive(true);

        if(info.swordsSelected == 0)
        {
            damage = 15;
        }
        else
        {
            damage = 30;
        }
    }
}
