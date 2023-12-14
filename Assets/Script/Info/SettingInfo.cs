using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingInfo", menuName = "TowerDefender/SettingInfo", order = 0)]
public class SettingInfo : ScriptableObject
{
    [Header("Game Value")]
    public bool notNewGame;
    public int HighScore;
    public int Score; 

    [Header("Setting")]
    public float effectSound;
    public float musicSound;
    public float ambientSound;
}

