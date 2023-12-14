using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    PlayerStat playerStat;
    public PlayerInfo info;

    [Header("Items Detection")]
    public float detectionRadius;
    public LayerMask detectionLayer;

    void Awake() 
    {
        playerStat = GetComponent<PlayerStat>();
    }

    void Update()
    {
        ItemsDetection();
    }

    public void ItemsDetection()
    {
        Collider[] items = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

        foreach (Collider item in items)
        {
            if(item.GetComponent<Items>().getItem == "Coin")
            {
                info.pocketCoins += item.GetComponent<Items>().coinValue;
                item.GetComponent<SoundFx>().playAudioClip(item.GetComponent<Items>().coinClip);
            }
            else
            {
                if(playerStat.currentHealth < (info.maxHealth * 0.5))
                {
                    playerStat.currentHealth += 25;
                }
                else
                {
                    playerStat.currentHealth += playerStat.currentHealth * 0.25f;
                }

                item.GetComponent<SoundFx>().playAudioClip(item.GetComponent<Items>().appleClip);
            }
            
            item.GetComponent<Items>().collider.enabled = false;

            item.GetComponent<Items>().DestroyItem(0.15f);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
