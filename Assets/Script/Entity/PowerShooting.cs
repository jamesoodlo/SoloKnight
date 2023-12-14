using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShooting : MonoBehaviour
{
    Enemy enemy;
    public GameObject bullet;
    public float timeSinceShoot;

    void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    void Start()
    {

    }

    void Update()
    {
        timeSinceShoot += Time.deltaTime;

        if (enemy.distanceFromTarget <= enemy.maximumAggroRadius)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (timeSinceShoot >= enemy.timeAttack)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timeSinceShoot = 0;
        }
    }


}
