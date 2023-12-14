using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    UnityEngine.AI.NavMeshAgent navAi;
    public bool isMoving;
    public float knockBackForce = 10;

    [Header("A.I. Settings")]
    public float detectionRadius = 5;
    public float moveSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float rotateSpeed;
    public float distanceFromTarget;
    public float maximumDetectionAngle = 50;
    public float minimumDetectionAngle = -50;
    public float maximumAggroRadius;
    public float viewableAngle;
    public LayerMask detectionLayer;
    public PlayerController target;

    [Header("Attack")]
    public bool isAttacking = false;
    public float damage;
    public Transform weaponHolder;
    public LayerMask targetLayer;
    public float attackRadius;
    public int currentAttack = 0;
    public int maxAttack;
    public float timeAttack;
    private float timeSinceAttack;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        navAi = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Start()
    {
        navAi.stoppingDistance = maximumAggroRadius;
        navAi.speed = moveSpeed;

        target = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        timeSinceAttack += Time.deltaTime;
    
        IdleState();
    }

    private void IdleState()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            PlayerController player = colliders[i].transform.GetComponent<PlayerController>();

            if (player != null)
            {
                Vector3 targetDirection = player.transform.position - transform.position;
                viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                if (viewableAngle > minimumDetectionAngle && viewableAngle < maximumDetectionAngle)
                {
                    target = player;
                }
            }
        }

        if (target != null)
        {
            PursueTargetState();
        }
        else
        {
            anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
        }
    }

    private void PursueTargetState()
    {
        Vector3 targetDirection = target.transform.position - transform.position;
        distanceFromTarget = Vector3.Distance(target.transform.position, this.transform.position);
        float viewableAngle = Vector3.SignedAngle(targetDirection, transform.forward, Vector3.up);

        Quaternion rotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed / Time.deltaTime);

        navAi.speed = moveSpeed;

        if (target == null)
        {
            anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            isMoving = false;
        }
        else if (distanceFromTarget <= maximumAggroRadius)
        {
            AttackState();
        }
        else 
        { 
            navAi.updatePosition = true;
            navAi.isStopped = false;
            navAi.SetDestination(target.transform.position);

            if(distanceFromTarget > 10)
            {
                moveSpeed = runSpeed;
                anim.SetFloat("Vertical", 2, 0.1f, Time.deltaTime);
                isMoving = true;
            }
            else
            {
                moveSpeed = walkSpeed;
                anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
                isMoving = true;
            }
            
        }
    }

    private void AttackState()
    {
        isMoving = false;
        
        if (timeSinceAttack > timeAttack)
        {
            currentAttack++;
            AttackHit();
            isAttacking = true;

            if (currentAttack > maxAttack)
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
        Collider[] playerCol = Physics.OverlapSphere(weaponHolder.position, attackRadius, targetLayer);

        foreach (Collider player in playerCol)
        {
            player.GetComponent<PlayerStat>().TakeDamage(damage);
            isAttacking = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(weaponHolder.position, attackRadius);
    }

}
