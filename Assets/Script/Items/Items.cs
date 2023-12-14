using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    
    GameManager gameManager;
    [SerializeField] private float timeToGet;
    public Collider collider;
    public string[] randomItems;
    public string getItem;
    public GameObject target;
    public float speed;

    [Header("Apple")]
    public AudioClip appleClip;
    public GameObject holyApple;
    
    [Header("Coin")]
    public AudioClip coinClip;
    public GameObject goldCoin;
    public int coinValue;

    void Awake() 
    {

    }
    void Start()
    {
        collider.enabled = false;
        coinValue = Random.Range(1, 25);
        getItem = randomItems[Random.Range(0, randomItems.Length)];
    }
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        timeToGet += Time.deltaTime;

        if(timeToGet > 2.0f) collider.enabled = true;

        if(getItem == "Coin")
        {
            goldCoin.SetActive(true);
            holyApple.SetActive(false);
        }
        else
        {
            goldCoin.SetActive(false);
            holyApple.SetActive(true);
        }

        followPlayer();
    }

    public void DestroyItem(float delayTime)
    {
        StartCoroutine(DelayDestroy(delayTime));
    }

    IEnumerator DelayDestroy(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(this.gameObject);
    }

    public void followPlayer()
    {
        if(gameManager.startWave) target = GameObject.Find("Player");
        
        if(target != null) transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
