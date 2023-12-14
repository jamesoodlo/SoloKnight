using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    Enemy enemy;
    Collider col;
    bool getScore = true;
    public SettingInfo settingInfo;
    public int score;
    enum DataType { Big, Normal, Small }
    [SerializeField] DataType enemyType;

    [Header("Status")]
    private bool isDie = false;
    public bool isKnockBack = false;
    public int hitCount = 0;
    public int maxHitCount;
    public float maxHealth = 75;
    public float currentHealth;

    [Header("Effect")]
    public GameObject destroyFx;
    public GameObject body;


    void Awake()
    {
        enemy = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    void Start()
    {
        getScore = true;
        destroyFx.SetActive(false);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isKnockBack) StartCoroutine(Reset(0.5f));
        if (isDie)
        {
            StartCoroutine(DelayDieFx(1.0f));
            StartCoroutine(DelayDestroy(1.2f));
        }

        if (transform.position == -transform.forward)
        {
            StartCoroutine(Reset(0.5f));
        }

        if (currentHealth > 0)
        {
            if (hitCount > maxHitCount && enemyType == DataType.Big)
            {
                anim.SetTrigger("Hit");
                hitCount = 0;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        hitCount++;

        if (currentHealth <= 0)
        {
            anim.SetTrigger("Die");
            Destroy(rb);
            Destroy(enemy);
            Destroy(col);
            isDie = true;

            if(getScore)
            {
                settingInfo.Score += score;
                getScore = false;
            }
        }
        else
        {
            if(enemyType == DataType.Normal)
            {
                anim.SetTrigger("Hit");
            }
        }
    }

    public void TakeDamageFireSlash(float damage, int maxHit)
    {
        currentHealth -= damage;
        maxHit -= 1;

        if(enemyType == DataType.Normal)
        {
            anim.SetTrigger("Hit");
        }
    }

    IEnumerator Reset(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
    }

    IEnumerator DelayDieFx(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(body);
        destroyFx.SetActive(true);
    }

    IEnumerator DelayDestroy(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(this.gameObject);
    }
}
