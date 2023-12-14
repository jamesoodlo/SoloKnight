using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttributeUpgrade : MonoBehaviour
{
    public PlayerInfo info;
    public CostInfo costInfo;
    
    [Header("Health")]
    public Slider healthBar;
    public TextMeshProUGUI healthValue;
    public TextMeshProUGUI healthCostText;

    [Header("Damage")]
    public Slider damageBar;
    public TextMeshProUGUI damageValue;
    public TextMeshProUGUI damageCostText;

    [Header("Speed")]
    public Slider speedBar;
    public TextMeshProUGUI speedValue;
    public TextMeshProUGUI speedCostText;
    void Start()
    {
        healthBar.maxValue = 600;
        damageBar.maxValue = 70;
        speedBar.maxValue = 10;
    }

    void Update()
    {
        SetValue();
    }

    public void SetValue()
    {
        healthBar.value = info.maxHealth;
        damageBar.value = info.damage;
        speedBar.value = info.speed;

        healthValue.text = healthBar.value.ToString();
        damageValue.text = damageBar.value.ToString();
        speedValue.text = speedBar.value.ToString();

        if(healthBar.value >= healthBar.maxValue)
        {
            healthBar.value = healthBar.maxValue;
            healthCostText.text = "Max";
        }
        else
        {
            healthCostText.text = costInfo.healthCost.ToString();
        }

        if(damageBar.value >= damageBar.maxValue)
        {
            damageBar.value = damageBar.maxValue;
            damageCostText.text = "Max";
        }
        else
        {
            damageCostText.text = costInfo.damageCost.ToString();
        }

        if(speedBar.value >= speedBar.maxValue)
        {
            speedBar.value = speedBar.maxValue;
            speedCostText.text = "Max";
        }
        else
        {
            speedCostText.text = costInfo.speedCost.ToString();
        }
    }

    public void HealthUp()
    {
        if(info.coins >= costInfo.healthCost && healthBar.value < healthBar.maxValue)
        {
            info.coins -= costInfo.healthCost;
            info.maxHealth += 100;
            costInfo.healthCost += 25;
        }
    }

    public void DamageUp()
    {
        if(info.coins >= costInfo.damageCost && damageBar.value < damageBar.maxValue)
        {
            info.coins -= costInfo.damageCost;
            info.damage += 15;
            costInfo.healthCost += 30;
        }
    }

    public void SpeedUp()
    {
        if(info.coins >= costInfo.speedCost && speedBar.value < speedBar.maxValue)
        {
            info.coins -= costInfo.speedCost;
            info.speed += 1;
            costInfo.healthCost += 30;
        }
    }
}
