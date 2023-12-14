using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UILobby : MonoBehaviour
{
    public GameObject continueBtn;
    public GameObject[] swords;
    [Header("Info")]
    public PlayerInfo info;
    public CostInfo costInfo;
    public SettingInfo settingInfo;

    [Header("Text")]
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI coinsText;

    [Header("Audio Source")]
    public AudioSource musicSound;
    public AudioSource ambientSound;
    public AudioSource effectSound;

    [Header("Sound Slider")]
    public Slider musicSlider;
    public Slider effectSlider;
    public Slider ambientSlider;
    void Start()
    {
        SetAllSetting();
    }

    void Update()
    {
        highScoreText.text = settingInfo.HighScore.ToString();
        coinsText.text = info.coins.ToString();

        continueBtn.SetActive(settingInfo.notNewGame);

        if(info.swordsSelected == 0)
        {
            swords[0].SetActive(true);
            swords[1].SetActive(false);
        }
        else
        {
            swords[0].SetActive(false);
            swords[1].SetActive(true);
        }
    }

    public void EffectSetting()
    {
        settingInfo.effectSound = effectSlider.value;
        effectSound.volume = settingInfo.effectSound;
    }

    public void MusicSetting()
    {
        settingInfo.musicSound = musicSlider.value;
        musicSound.volume = settingInfo.musicSound;
    }

    public void AmbientSetting()
    {
        settingInfo.ambientSound = ambientSlider.value;
        ambientSound.volume = settingInfo.ambientSound;
    }

    public void SetAllSetting()
    {
        effectSound.volume = settingInfo.effectSound;
        effectSlider.value = effectSound.volume; 

        musicSound.volume = settingInfo.musicSound;
        musicSlider.value = musicSound.volume; 

        ambientSound.volume = settingInfo.ambientSound;
        ambientSlider.value = ambientSound.volume; 
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void NewGame()
    {
        //Player Stat
        info.maxHealth = 100;
        info.damage = 15;
        info.speed = 5;
        info.haveGlorySword = false;

        info.haveHeal = false;
        info.healRate = 5;
        info.healSkillTime = 6.5f;
    
        info.haveBarrier = false;
        info.reduceDamage = 15;
        info.barrierSkillTime = 6.5f;

        info.haveFireSlash = false;
        info.fireSlashDamage = 1;
        info.fireSkillTime = 5;

        //Cost Upgrade
        costInfo.healCost = 20;
        costInfo.damageCost = 35;
        costInfo.speedCost = 30;
        costInfo.healCost = 50;
        costInfo.barrierCost = 50;
        costInfo.fireSlashCost = 75;
        costInfo.healRateCost = 25;
        costInfo.healSkillTimeCost = 25;
        costInfo.reduceDamageCost = 25;
        costInfo.barrierSkillTimeCost = 25;
        costInfo.fireSlashDamageCost = 35;
        costInfo.fireSkillTimeCost = 35;

        //Game Value
        settingInfo.Score = 0;
        info.pocketCoins = 0;
        info.coins = 0;
        settingInfo.HighScore = 0;
        settingInfo.notNewGame = true;
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
