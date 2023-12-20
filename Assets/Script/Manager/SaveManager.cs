using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    [Header("Data")]
    public PlayerInfo info;
    public SettingInfo settingInfo;
    public CostInfo costInfo;

    public SaveData saveData;

    private void Start() 
    {
        LoadGameSetting();
        LoadGame();
    }

    private void Update()
    {
        
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();

        data.maxHealth = info.maxHealth;
        data.damage = info.damage;
        data.speed = info.speed;

        data.swordsSelected = info.swordsSelected;
        data.haveSteelSword = info.haveSteelSword;
        data.haveGlorySword = info.haveGlorySword;

        data.haveHeal = info.haveHeal;
        data.healRate = info.healRate;
        data.healSkillTime = info.healSkillTime;

        data.haveBarrier = info.haveBarrier;
        data.reduceDamage = info.reduceDamage;
        data.barrierSkillTime = info.barrierSkillTime;

        data.haveFireSlash = info.haveFireSlash;
        data.fireSlashDamage = info.fireSlashDamage;
        data.fireSkillTime = info.fireSkillTime;


        data.healthCost = costInfo.healthCost;
        data.damageCost = costInfo.damageCost;
        data.speedCost = costInfo.speedCost;

        data.healCost = costInfo.healCost;
        data.barrierCost = costInfo.barrierCost;
        data.fireSlashCost = costInfo.fireSlashCost;

        data.healRateCost = costInfo.healRateCost;
        data.healSkillTimeCost = costInfo.healSkillTimeCost;

        data.reduceDamageCost = costInfo.reduceDamageCost;
        data.barrierSkillTimeCost = costInfo.barrierSkillTimeCost;

        data.fireSlashDamageCost = costInfo.fireSlashDamageCost;
        data.fireSkillTimeCost = costInfo.fireSkillTimeCost;

        data.notNewGame = settingInfo.notNewGame;
        data.HighScore = settingInfo.HighScore;

        data.musicSound = settingInfo.musicSound;
        data.ambientSound = settingInfo.ambientSound;
        data.effectSound = settingInfo.effectSound;


        string saveDataString = JsonUtility.ToJson(data);

        PlayerPrefs.SetString("Save", saveDataString);
        PlayerPrefs.Save();

        //bf.Serialize(file, data);
        //file.Close();
        Debug.Log("Game data saved!");

    }

    public void LoadGame()
    {
        string loadDataString = PlayerPrefs.GetString("Save");
        SaveData loadSave = JsonUtility.FromJson<SaveData>(loadDataString);

        if (loadSave != null)
        {

            info.maxHealth = loadSave.maxHealth;
            info.damage = loadSave.damage;
            info.speed = loadSave.speed;

            info.swordsSelected = loadSave.swordsSelected;
            info.haveSteelSword = loadSave.haveSteelSword;
            info.haveGlorySword = loadSave.haveGlorySword;

            info.haveHeal = loadSave.haveHeal;
            info.healRate = loadSave.healRate;
            info.healSkillTime = loadSave.healSkillTime;

            info.haveBarrier = loadSave.haveBarrier;
            info.reduceDamage = loadSave.reduceDamage;
            info.barrierSkillTime = loadSave.barrierSkillTime;

            info.haveFireSlash = loadSave.haveFireSlash;
            info.fireSlashDamage = loadSave.fireSlashDamage;
            info.fireSkillTime = loadSave.fireSkillTime;


            costInfo.healthCost = loadSave.healthCost;
            costInfo.damageCost = loadSave.damageCost;
            costInfo.speedCost = loadSave.speedCost;

            costInfo.healCost = loadSave.healCost;
            costInfo.barrierCost = loadSave.barrierCost;
            costInfo.fireSlashCost = loadSave.fireSlashCost;

            costInfo.healRateCost = loadSave.healRateCost;
            costInfo.healSkillTimeCost = loadSave.healSkillTimeCost;

            costInfo.reduceDamageCost = loadSave.reduceDamageCost;
            costInfo.barrierSkillTimeCost = loadSave.barrierSkillTimeCost;

            costInfo.fireSlashDamageCost = loadSave.fireSlashDamageCost;
            costInfo.fireSkillTimeCost = loadSave.fireSkillTimeCost;

            settingInfo.notNewGame = loadSave.notNewGame;
            settingInfo.HighScore = loadSave.HighScore;

            settingInfo.musicSound = loadSave.musicSound;
            settingInfo.ambientSound = loadSave.ambientSound;
            settingInfo.effectSound = loadSave.effectSound;

            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.LogError("There is no save data!");
        }
    }

    public void LoadGameSetting()
    {
        string loadDataString = PlayerPrefs.GetString("Save");
        SaveData loadSave = JsonUtility.FromJson<SaveData>(loadDataString);

        if (loadSave != null)
        {
            //File.Exists(Application.persistentDataPath + "/MySaveData.dat") //in IF
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            //SaveData data = (SaveData)bf.Deserialize(file);
            //file.Close();
            settingInfo.notNewGame = loadSave.notNewGame;
            settingInfo.musicSound = loadSave.musicSound;
            settingInfo.ambientSound = loadSave.ambientSound;
            settingInfo.effectSound = loadSave.effectSound;

            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.LogError("There is no save data!");
        }
    }
}

[Serializable]
public class SaveData
{
    [Header("Base Status")]
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

    [Header("Game Value")]
    public bool notNewGame;
    public int HighScore;

    [Header("All Setting")]
    public float musicSound;
    public float ambientSound;
    public float effectSound;

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
