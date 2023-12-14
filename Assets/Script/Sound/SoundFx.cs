using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFx : MonoBehaviour
{
    public GameObject PlayerOrEntity;
    enum DataType { Player, Entity, Item , ETC}
    [SerializeField] DataType objectType;
    public SettingInfo settingInfo;
    public AudioSource audio;

    void Start()
    {
        
    }

    void Update()
    {
        audio.volume = settingInfo.effectSound;
    }

    public void playAudioClip(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }

    public void dashSfx(AudioClip clip)
    {
        if(objectType == DataType.Player)
        {
            PlayerController player;

            player = PlayerOrEntity.GetComponent<PlayerController>();
            
            if(player.isDashing) audio.PlayOneShot(clip);
        }
    }

    public void footStepSfx(AudioClip clip)
    {
        if(objectType == DataType.Player)
        {
            PlayerController player;

            player = PlayerOrEntity.GetComponent<PlayerController>();
            
            if(player.isMoving) audio.PlayOneShot(clip);
        }
        else
        {
            Enemy enemy;

            enemy = PlayerOrEntity.GetComponent<Enemy>();

            if(enemy.isMoving) audio.PlayOneShot(clip);
        }
    }

    public void gethitSfx(AudioClip clip)
    {
        if(objectType == DataType.Player)
        {
            PlayerController player;

            player = PlayerOrEntity.GetComponent<PlayerController>();
            
            audio.PlayOneShot(clip);
        }
        else
        {
            Enemy enemy;

            enemy = PlayerOrEntity.GetComponent<Enemy>();

            audio.PlayOneShot(clip);
        }
    }
}
