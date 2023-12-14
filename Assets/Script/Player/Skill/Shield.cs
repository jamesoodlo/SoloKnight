using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public ParticleSystem hitFx;
    public LayerMask targetLayer;
    public float radius;
    void Start()
    {
        
    }
    void Update()
    {
        GetHit();
    }

    public void GetHit()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, radius, targetLayer);

        foreach (Collider enemy in enemies)
        {
            if(enemy.GetComponent<Enemy>().isAttacking)
            {
                hitFx.Play();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
