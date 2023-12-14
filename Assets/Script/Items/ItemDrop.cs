using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    EnemyStat enemyStat;
    public GameObject items;
    void Awake() 
    {
        enemyStat = GetComponent<EnemyStat>();
    }

    void Update()
    {
        if(enemyStat.currentHealth <= 0)
        {
            Instantiate(items, transform.position, Quaternion.identity);
            Destroy(this);
        }
    }
}
