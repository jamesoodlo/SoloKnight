using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private Enemy[] enemy;
    public int enemyCount;
    public AudioClip musicClip, battleClip;
    public AudioSource ambientSound, musicSound;
    void Start()
    {
        musicSound.clip = musicClip;
        musicSound.Play();
    }

    void Update()
    {
        enemy = FindObjectsOfType<Enemy>();

        enemyCount = enemy.Length;

        if (enemyCount > 0)
        {
            if (musicSound.clip != battleClip)
            {
                musicSound.clip = battleClip;
                musicSound.Play();
            }
        }
        else
        {
            if (musicSound.clip != musicClip)
            {
                musicSound.clip = musicClip;
                musicSound.Play();
            }
        }

    }
}
