using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    InputHandle inputHandle;
    Animator anim;
    Collider col;
    Rigidbody rb;
    Weapons weapons;
    PlayerStat playerStat;

    public PlayerInfo info;

    [Header("Movement")]
    public float rotationSpeed, dashSpeed, timeSinceDash;
    public bool isMoving, isDashing;
    public GameObject dashTrail;

    [Header("Attack")]
    public Transform weaponHolder;
    public LayerMask targetLayer;
    public float AttackRange;
    public int currentAttack = 0;
    public bool isAttacking;
    public float timeAttack;
    private float timeSinceAttack;

    [Header("Enemies Detection")]
    public Transform detectionPoint;
    public float detectionRadius;
    public LayerMask detectionLayer;

    void Awake()
    {
        anim = GetComponent<Animator>();
        inputHandle = GetComponent<InputHandle>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        weapons = GetComponentInChildren<Weapons>();
        playerStat = GetComponent<PlayerStat>();

    }

    void Start()
    {

    }

    void Update()
    {
        timeSinceAttack += Time.deltaTime;
        timeSinceDash += Time.deltaTime;

        dashTrail.SetActive(isDashing);

        MoveAndRotate();
        EnemiesDetection();

        if (playerStat.isDie) anim.SetTrigger("Die");
    }

    public void MoveAndRotate()
    {
        Vector3 lookDirection = new Vector3(inputHandle.look.x, 0f, inputHandle.look.y);

        if (lookDirection != Vector3.zero && !playerStat.isDie)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), 0.15f);
        }

        Vector3 movement = new Vector3(inputHandle.move.x, 0f, inputHandle.move.y);

        if (movement != Vector3.zero && !playerStat.isDie)
        {
            transform.Translate(movement * info.speed * Time.deltaTime, Space.World);

            anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);

            isMoving = true;
        }
        else
        {
            anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);

            isMoving = false;
        }
    }

    public void Dash()
    {
        if (timeSinceDash > 0.75f && !playerStat.isDie)
        {
            Vector3 dashDir = new Vector3(inputHandle.move.x, 0f, inputHandle.move.y).normalized;

            dashDir.y = 0;

            rb.AddForce(dashDir * dashSpeed, ForceMode.VelocityChange);

            isDashing = true;

            col.enabled = false;

            timeSinceDash = 0;

            if (isDashing)
            {
                StartCoroutine(DelayDash(0.75f));
            }
        }
    }

    IEnumerator DelayDash(float delayTime)
    {
        isDashing = true;
        yield return new WaitForSeconds(delayTime);
        isDashing = false;
        col.enabled = true;
        rb.velocity = Vector3.zero;
    }

    public void EnemiesDetection()
    {
        Collider[] enemies = Physics.OverlapSphere(detectionPoint.position, detectionRadius, detectionLayer);

        foreach (Collider enemy in enemies)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (timeSinceAttack >= timeAttack && !playerStat.isDie)
        {
            currentAttack++;
            AttackHit();

            if (currentAttack > 4)
                currentAttack = 1;

            //Reset Attack When Time out
            if (timeSinceAttack > 1.0f)
                currentAttack = 1;

            //Call Trigger Attack Animation
            anim.SetTrigger("Attack" + currentAttack);

            //Reset Timer
            timeSinceAttack = 0;
        }
    }

    public void AttackHit()
    {
        Collider[] enemies = Physics.OverlapSphere(weaponHolder.position, AttackRange, targetLayer);

        foreach (Collider enemy in enemies)
        {
            enemy.GetComponent<EnemyStat>().TakeDamage(info.damage + weapons.damage);
            enemy.GetComponent<EffectHandle>().hitFx.Play();

            if (currentAttack == 4)
            {
                enemy.GetComponent<EnemyStat>().isKnockBack = true;

                Vector3 knockbackDirection = (transform.position - enemy.GetComponent<Enemy>().transform.position).normalized;

                enemy.GetComponent<Rigidbody>().AddForce(-knockbackDirection * enemy.GetComponent<Enemy>().knockBackForce, ForceMode.Impulse);
            }

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(weaponHolder.position, AttackRange);

        Gizmos.DrawWireSphere(detectionPoint.position, detectionRadius);
    }
}
