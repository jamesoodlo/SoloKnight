using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "TowerDefender/PlayerInfo", order = 0)]
public class PlayerInfo : ScriptableObject 
{
    public int coins;
    public int pocketCoins;

    [Header("Attribute")]
    public float maxHealth;
    public float damage;
    public float speed;

    [Header("Armory")]
    public int swordsSelected;
    public bool haveSteelSword;
    public bool haveGlorySword;
    
    [Header("Skill")]

    [Header("Heal")]
    public bool haveHeal;
    public float healRate;
    public float healSkillTime;
    
    [Header("Barrier")]
    public bool haveBarrier;
    public float reduceDamage;
    public float barrierSkillTime;

    [Header("Fire Slash")]
    public bool haveFireSlash;
    public float fireSlashDamage;
    public float fireSkillTime;
}

