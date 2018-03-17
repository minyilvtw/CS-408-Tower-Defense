using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOESpell : BaseSpell {

    private float hitLength;
    private Transform hitOrigin;
    private LayerMask targetMask;
    private int level = 1;

    public AOESpell()
    {
        cooldown = 15f;
        hitLength = 8.0f;
    }

    void Start () {
        lastCast = Time.time - cooldown;
        hitOrigin = this.transform;
        targetMask = LayerMask.GetMask("Enemy");
    }

    public override void Action()
    {
        int damage = 40 * level;

        foreach (Collider c in Physics.OverlapSphere(hitOrigin.position, hitLength, targetMask))
        {
            EnemyStatus enemy = c.GetComponent<EnemyStatus>();
            enemy.TakeDamage(damage);
        }
    }
}
