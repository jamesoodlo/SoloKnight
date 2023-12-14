using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CostInfo", menuName = "TowerDefender/CostInfo", order = 0)]
public class CostInfo : ScriptableObject 
{
    [Header("Weapons Cost")]
    public int glorySwordCost;

    [Header("Upgrade Attribute Cost")]
    public int healthCost;
    public int damageCost;
    public int speedCost;

    [Header("Unlock Skill Cost")]
    public int healCost;
    public int barrierCost;
    public int fireSlashCost;

    [Header("Upgrade Skill Cost")]
    [Header("Heal")]
    public int healRateCost;
    public int healSkillTimeCost;
    
    [Header("Barrier")]
    public int reduceDamageCost;
    public int barrierSkillTimeCost;

    [Header("Fire Slash")]
    public int fireSlashDamageCost;
    public int fireSkillTimeCost;
}

