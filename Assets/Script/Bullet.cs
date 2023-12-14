using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public LayerMask targetLayer;
    public bool destroyWhenDetect;
    public float attackRadius;
    private float timeSinceShoot;

    void Update()
    {
        timeSinceShoot += Time.deltaTime;

        if(timeSinceShoot > 5.0f)
        {
            Destroy(this.gameObject);
        }

        gameObject.transform.position += speed * gameObject.transform.forward;

        AttackHit();
        
    }

    public void AttackHit()
    {
        Collider[] playerCol = Physics.OverlapSphere(transform.position, attackRadius, targetLayer);

        foreach (Collider player in playerCol)
        {
            player.GetComponent<PlayerStat>().TakeDamage(damage);
            if(destroyWhenDetect) Destroy(this.gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
