using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    Barrier barrier;
    Heal heal;
    public PlayerInfo info;
    public bool isDie;

    [Header("UI")]
    public Slider healthBar;

    [Header("Status")]
    public float currentHealth;

    void Awake()
    {
        barrier = GetComponentInChildren<Barrier>();
        heal = GetComponentInChildren<Heal>();
    }

    void Start()
    {
        healthBar.maxValue = info.maxHealth;
        currentHealth = info.maxHealth;
        isDie = false;
    }

    void Update()
    {
        healthBar.value = currentHealth;
        if(currentHealth > info.maxHealth) currentHealth = info.maxHealth;

        if(heal.isUsed)
        {
            currentHealth += heal.healRate * Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        if(barrier.isUsed)
        {
            currentHealth -= (damage - (damage * barrier.reduceDamage / 100));
        }
        else
        {
            currentHealth -= damage;
        }

        if (currentHealth <= 0)
        {
           isDie = true;
        }
    }
}
