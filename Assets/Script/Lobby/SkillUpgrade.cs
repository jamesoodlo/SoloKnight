using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillUpgrade : MonoBehaviour
{
    public PlayerInfo info;
    public CostInfo costInfo;
    public GameObject skillSelectPanel;

    [Header("Heal")]
    public GameObject healPanel;
    public Slider healSkillTimeBar;
    public Slider healRateBar;
    public TextMeshProUGUI healSkillTimeValue;
    public TextMeshProUGUI healRateValue;
    public TextMeshProUGUI healCostText;
    public TextMeshProUGUI healSkillTimeCostText;
    public TextMeshProUGUI healRateCostText;

    [Header("Barrier")]
    public GameObject barrierPanel;
    public Slider barrierSkillTimeBar;
    public Slider barrierReduceBar;
    public TextMeshProUGUI barrierSkillTimeValue;
    public TextMeshProUGUI barrierReduceValue;
    public TextMeshProUGUI barrierCostText;
    public TextMeshProUGUI barrierSkillTimeCostText;
    public TextMeshProUGUI reduceDamageCostText;

    [Header("Fire Slash")]
    public GameObject fireSlashPanel;
    public Slider fireSlashSkillTimeBar;
    public Slider fireSlashDamageBar;
    public TextMeshProUGUI fireSlashSkillTimeValue;
    public TextMeshProUGUI fireSlashDamageValue;
    public TextMeshProUGUI fireSlashCostText;
    public TextMeshProUGUI fireSkillTimeCostText;
    public TextMeshProUGUI fireSlashDamageCostText;

    void Start()
    {
        healSkillTimeBar.maxValue = 14;
        healRateBar.maxValue = 50;

        barrierSkillTimeBar.maxValue = 14;
        barrierReduceBar.maxValue = 60;

        fireSlashSkillTimeBar.maxValue = 15;
        fireSlashDamageBar.maxValue = 10;
    }

    void Update()
    {
        SetValue();
    }

    public void SetValue()
    {
        //Unlock Cost
        healCostText.text = costInfo.healCost.ToString();
        barrierCostText.text = costInfo.barrierCost.ToString();
        fireSlashCostText.text = costInfo.fireSlashCost.ToString();

        //Upgrade Cost
        healSkillTimeCostText.text = costInfo.healSkillTimeCost.ToString();
        healRateCostText.text = costInfo.healRateCost.ToString();

        barrierSkillTimeCostText.text = costInfo.barrierSkillTimeCost.ToString();
        reduceDamageCostText.text = costInfo.reduceDamageCost.ToString();

        fireSkillTimeCostText.text = costInfo.fireSkillTimeCost.ToString();
        fireSlashDamageCostText.text = costInfo.fireSlashDamageCost.ToString();

        //Bar Value
        healSkillTimeBar.value = info.healSkillTime;
        healRateBar.value = info.healRate;
        barrierSkillTimeBar.value = info.barrierSkillTime;
        barrierReduceBar.value = info.reduceDamage;
        fireSlashSkillTimeBar.value = info.fireSkillTime;
        fireSlashDamageBar.value = info.fireSlashDamage;

        //Text Value
        healSkillTimeValue.text = healSkillTimeBar.value.ToString();
        healRateValue.text = healRateBar.value.ToString();
        barrierSkillTimeValue.text = barrierSkillTimeBar.value.ToString();
        barrierReduceValue.text = barrierReduceBar.value.ToString();
        fireSlashSkillTimeValue.text = fireSlashSkillTimeBar.value.ToString();
        fireSlashDamageValue.text = fireSlashDamageBar.value.ToString();
    }

    public void UnlockSkill(string skillName)
    {
        if (skillName == "Heal")
        {
            if (info.haveHeal)
            {
                healPanel.SetActive(true);
                skillSelectPanel.SetActive(false);
                healCostText.gameObject.SetActive(false);
            }
            else
            {
                if (info.coins >= costInfo.healCost)
                {
                    info.coins -= costInfo.healCost;
                    healCostText.gameObject.SetActive(false);
                    info.haveHeal = true;
                }
            }
        }
        else if (skillName == "Barrier")
        {
            if (info.haveBarrier)
            {
                barrierPanel.SetActive(true);
                skillSelectPanel.SetActive(false);
                barrierCostText.gameObject.SetActive(false);
            }
            else
            {
                if (info.coins >= costInfo.barrierCost)
                {
                    info.coins -= costInfo.barrierCost;
                    barrierCostText.gameObject.SetActive(false);
                    info.haveBarrier = true;
                }
            }
        }
        else if (skillName == "FireSlash")
        {
            if (info.haveFireSlash)
            {
                fireSlashPanel.SetActive(true);
                skillSelectPanel.SetActive(false);
                fireSlashCostText.gameObject.SetActive(false);
            }
            else
            {
                if (info.coins >= costInfo.fireSlashCost)
                {
                    info.coins -= costInfo.fireSlashCost;
                    fireSlashCostText.gameObject.SetActive(false);
                    info.haveFireSlash = true;
                }
            }
        }
    }

    public void FireSlashUp(string skillName)
    {
        if (skillName == "SkillTime")
        {
            if (info.coins >= costInfo.fireSkillTimeCost && fireSlashSkillTimeBar.value < fireSlashSkillTimeBar.maxValue)
            {
                info.coins -= costInfo.fireSkillTimeCost;
                info.fireSkillTime += 5;
                costInfo.fireSkillTimeCost += 25;
            }
        }
        else if (skillName == "Damage")
        {
            if (info.coins >= costInfo.fireSlashDamageCost && fireSlashDamageBar.value < fireSlashDamageBar.maxValue)
            {
                info.coins -= costInfo.fireSlashDamageCost;
                info.fireSlashDamage += 1.5f;
                costInfo.fireSkillTimeCost += 30;
            }
        }
    }

    public void HealthUp(string skillName)
    {
        if (skillName == "SkillTime")
        {
            if (info.coins >= costInfo.healSkillTimeCost && healSkillTimeBar.value < healSkillTimeBar.maxValue)
            {
                info.coins -= costInfo.healSkillTimeCost;
                info.healSkillTime += 1.5f;
                costInfo.healSkillTimeCost += 20;
            }
        }
        else if (skillName == "HealRate")
        {
            if (info.coins >= costInfo.healRateCost && healRateBar.value < healRateBar.maxValue)
            {
                info.coins -= costInfo.healRateCost;
                info.healRate += 15;
                costInfo.healRateCost += 25;
            }
        }
    }

    public void BarrierUp(string skillName)
    {
        if (skillName == "SkillTime")
        {
            if (info.coins >= costInfo.barrierSkillTimeCost && healSkillTimeBar.value < healSkillTimeBar.maxValue)
            {
                info.coins -= costInfo.barrierSkillTimeCost;
                info.barrierSkillTime += 1.5f;
                costInfo.barrierSkillTimeCost += 20;
            }
        }
        else if (skillName == "Reduce")
        {
            if (info.coins >= costInfo.reduceDamageCost && barrierReduceBar.value < barrierReduceBar.maxValue)
            {
                info.coins -= costInfo.reduceDamageCost;
                info.reduceDamage += 15;
                costInfo.reduceDamageCost += 25;
            }
        }
    }
}
