using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEProjectileStatus : ProjectileStatus {

    private LayerMask targetMask;

    private void Start()
    {
        targetMask = LayerMask.GetMask("Enemy");

    }

    public override void HitTarget()
    {
        foreach (Collider c in Physics.OverlapSphere(this.transform.position, 2.0f, targetMask))
        {
            EnemyStatus enemy2 = c.GetComponent<EnemyStatus>();
            enemy2.TakeDamage(damage);
        }
        
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);

        Destroy(gameObject);
    }
}
