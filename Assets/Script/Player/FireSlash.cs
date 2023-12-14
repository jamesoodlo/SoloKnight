using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSlash : MonoBehaviour
{
    public PlayerInfo info;
    public float speed;
    public int maxHit = 3;
    public float damage;
    public LayerMask targetLayer;
    public float attackRadius;
    private float timeSinceShoot;

    void Start() 
    {
        maxHit = 3;

        damage = info.fireSlashDamage;
    }

    void Update()
    {
        timeSinceShoot += Time.deltaTime;

        if (timeSinceShoot > 3.0f || maxHit <= 0)
        {
            Destroy(this.gameObject);
        }

        gameObject.transform.position += speed * gameObject.transform.forward;

        AttackHit();
    }

    public void AttackHit()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, attackRadius, targetLayer);

        foreach (Collider enemy in enemies)
        {
            if(maxHit > 0)
            {
                enemy.GetComponent<EnemyStat>().TakeDamageFireSlash(damage, maxHit);
                
                enemy.GetComponent<EffectHandle>().hitFireFx.Play();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
