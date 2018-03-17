using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpell : BaseSpell {

    private float hitLength;
    private Transform hitOrigin;
    private LayerMask targetMask;
    private int level = 1;

    public AttackSpell()
    {
        cooldown = 0.75f;
        hitLength = 3.0f;
    }

    public void Start()
    {
        lastCast = Time.time - cooldown;
        hitOrigin = this.transform;
        targetMask = LayerMask.GetMask("Enemy");
    }

    public override void Action()
    {
        int damage = 5 * level;

        foreach(Collider c in Physics.OverlapSphere(hitOrigin.position, hitLength, targetMask))
        {
            EnemyStatus enemy = c.GetComponent<EnemyStatus>();
            enemy.TakeDamage(damage);
        }
    }
}
