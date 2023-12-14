using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public PlayerInfo info;
    public SettingInfo settingInfo;
    public GameManager gameManager;
    public GameObject settingPanel;
    public bool isPause;

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
       settingPanel.SetActive(isPause);
    }

    public void Pause()
    {
        if(!isPause)
        {
            Time.timeScale = 0;
            isPause = true;
        }
        else
        {
            Time.timeScale = 1;
            isPause = false;
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

    public void Lobby()
    {
        settingInfo.Score = 0;
        info.pocketCoins = 0;
        gameManager.numOfWave = 0;
        SceneManager.LoadScene("Lobby");
    }

    public void Quit()
    {
        settingInfo.Score = 0;
        info.pocketCoins = 0;
        gameManager.numOfWave = 0;
        Application.Quit();
    }
}
