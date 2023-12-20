using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    bool isGameOver = false;
    bool getScore = true;
    public GameObject gameOverPanel;

    [Header("Info")]
    public PlayerInfo info;
    public SettingInfo settingInfo;

    [Header("Player")]
    public GameObject player;
    public GameObject healSkill;
    public GameObject barrierSkill;
    public GameObject fireSlashSkill;

    [Header("Enemies Spawn")]
    private string targetTag = "Enemy";
    public int enemiesCount;
    public EnemiesSpawnPoint[] enemiesSpawns;
    public int numOfStage;
    public bool startWave = true;
    public int numOfWave = 1;
    public float timeCount;

    [Header("Text")]
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI scroreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI pocketCoinsText;
    void Awake()
    {
        enemiesSpawns = GetComponentsInChildren<EnemiesSpawnPoint>();
    }

    void Start()
    {
        numOfWave = 1;
        getScore = true;
        isGameOver = false;
    }

    void Update()
    {
        gameOverPanel.SetActive(isGameOver);

        enemiesCount = CountObjectsWithLayer(targetTag);

        waveStart();
        GameOver();
        TextSet();

        healSkill.SetActive(info.haveHeal);
        barrierSkill.SetActive(info.haveBarrier);
        fireSlashSkill.SetActive(info.haveFireSlash);
    }

    public void TextSet()
    {
        waveText.text = numOfWave.ToString();
        scroreText.text = settingInfo.Score.ToString();
        highScoreText.text = settingInfo.HighScore.ToString();
        pocketCoinsText.text = info.pocketCoins.ToString();
    }

    public void waveStart()
    {
        for (int i = 0; i < enemiesSpawns.Length; i++)
        {
            if (numOfWave == 1)
            {
                enemiesSpawns[i].unlockEnemeis = 2;
            }
            else if (numOfWave == 2)
            {
                enemiesSpawns[i].unlockEnemeis = 3;
            }
            else if (numOfWave == 3)
            {
                enemiesSpawns[i].unlockEnemeis = 4;
            }

            if (startWave)
            {
                timeCount += Time.deltaTime;

                enemiesSpawns[i].InstantiateObjectsAtRandomPoints();

                if (timeCount >= 0.05f)
                {
                    timeCount = 0;
                    startWave = false;
                }
            }
            else
            {
                if (enemiesCount <= 0 && timeCount <= 0f)
                {
                    numOfWave++;
                    player.transform.position = new Vector3(0, 0, 0);
                    startWave = true;
                }
            }
        }
    }

    int CountObjectsWithLayer(string tagName)
    {
        GameObject[] objectsWithLayer = GameObject.FindGameObjectsWithTag(tagName);

        return objectsWithLayer.Length;
    }

    public void GameOver()
    {
        if (player.GetComponent<PlayerStat>().currentHealth <= 0)
        {
            isGameOver = true;

            Destroy(player.GetComponent<Inventory>());

            if (getScore)
            {
                settingInfo.Score += settingInfo.Score + numOfWave;
                info.coins += info.pocketCoins;

                if (settingInfo.Score > settingInfo.HighScore)
                {
                    settingInfo.HighScore = settingInfo.Score;
                }

                getScore = false;
            }
        }
    }
}
